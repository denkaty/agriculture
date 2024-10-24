﻿using Agriculture.Shared.Common.Utilities;
using Agriculture.Shared.Web.Extensions;
using Agriculture.Shared.Web.Models.Options;
using Agriculture.Shared.Web.Utilities;
using Asp.Versioning;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Security.Claims;
using System.Text.Json.Serialization;

namespace Agriculture.Shared.Web
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApiControllers(this IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                });

            return serviceCollection;
        }

        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = JwtBearerDefaults.AuthenticationScheme,
                    BearerFormat = "JWT",
                    Description = "Enter your token in the text input below."
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = JwtBearerDefaults.AuthenticationScheme
                                }
                            },
                            Array.Empty<string>()
                        }
                    });
            });

            return services;
        }

        public static IServiceCollection AddJwtBearer(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddOptions<AccessTokenOptions>()
                .BindConfiguration(nameof(AccessTokenOptions))
                .ValidateDataAnnotations()
                .ValidateOnStart();

            var jwtOptions = configuration
                .GetSection(nameof(AccessTokenOptions))
                .Get<AccessTokenOptions>();

            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtOptions.Issuer,
                        ValidAudience = jwtOptions.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(jwtOptions.SecretKeyByteArray)
                    };

                    options.Events = new JwtBearerEvents
                    {
                        OnChallenge = context =>
                        {
                            context.HandleResponse();
                            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                            context.Response.ContentType = "application/json";

                            var traceId = context.HttpContext.TraceIdentifier;
                            var response = new
                            {
                                Type = "https://datatracker.ietf.org/doc/html/rfc9110#name-401-unauthorized",
                                Title = "Unauthorized",
                                Status = 401,
                            };
                            return context.Response.WriteAsJsonAsync(response);
                        },
                        OnForbidden = context =>
                        {
                            context.Response.StatusCode = StatusCodes.Status403Forbidden;
                            context.Response.ContentType = "application/json";

                            var traceId = context.HttpContext.TraceIdentifier;
                            var response = new
                            {
                                Type = "https://datatracker.ietf.org/doc/html/rfc9110#name-403-forbidden",
                                Title = "Forbidden",
                                Status = 403,
                            };
                            return context.Response.WriteAsJsonAsync(response);
                        }
                    };
                });

            return services;
        }

        public static IServiceCollection AddAuthorizationPolicies(this IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddAuthorization(options =>
                {
                    options.DefaultPolicy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .RequireClaim(ClaimTypes.NameIdentifier)
                    .Build();

                    options.AddPolicy(AppPolicies.EmployeePolicy, policy => policy.RequireRole(AppRoles.Employee));
                });

            return serviceCollection;
        }

        public static IServiceCollection AddVersioning(this IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddApiVersioning(options =>
                {
                    options.DefaultApiVersion = new ApiVersion(1);
                    options.ReportApiVersions = true;
                    options.ApiVersionReader = new UrlSegmentApiVersionReader();
                })
                .AddMvc()
                .AddApiExplorer(options =>
                {
                    options.GroupNameFormat = "'v'V";
                    options.SubstituteApiVersionInUrl = true;
                });

            serviceCollection.ConfigureOptions<ConfigureSwaggerGenOptions>();

            return serviceCollection;
        }

        //public static IServiceCollection AddExceptionHandler(this IServiceCollection serviceCollection)
        //{
        //    serviceCollection.AddProblemDetails();
        //    serviceCollection.AddExceptionHandler<AppExceptionHandler>();

        //    return serviceCollection;
        //}

    }
}
