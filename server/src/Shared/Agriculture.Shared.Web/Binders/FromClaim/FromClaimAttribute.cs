﻿using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Agriculture.Shared.Web.Binders.FromClaim
{
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Property, AllowMultiple = false)]
    public class FromClaimAttribute : Attribute, IBindingSourceMetadata, IModelNameProvider
    {
        public FromClaimAttribute(string name)
        {
            Name = name;
        }

        public BindingSource BindingSource => FromClaimBindingSource.Claim;

        public string Name { get; }
    }

}
