import { useState } from "react";
import { useForm } from "react-hook-form";
import * as yup from "yup";
import { yupResolver } from "@hookform/resolvers/yup";
import { LoginRequest } from "../../types/users.types";
import { usersService } from "../../services/users.service";
import styles from "./LoginForm.module.css";
import { useNavigate } from "react-router-dom";
import { useAuth } from "../../context/AuthContext";

const schema = yup
    .object({
        email: yup
            .string()
            .email("Enter a valid email")
            .required("Email is required"),
        password: yup.string().required("Password is required"),
    })
    .required();

export const LoginForm = () => {
    const [apiError, setApiError] = useState<string | null>(null);
    const {
        register,
        handleSubmit,
        formState: { errors, isSubmitting },
    } = useForm<LoginRequest>({
        resolver: yupResolver(schema),
    });
    const navigate = useNavigate();
    const { login } = useAuth();

    const onSubmit = async (data: LoginRequest) => {
        try {
            setApiError(null);
            const response = await usersService.login(data);
            login(response.value);

            // Navigate to root instead of /dashboard
            navigate("/");

            // Here we can add navigation to the dashboard or home page
            console.log("Login successful:", response);
        } catch (error: any) {
            const errorMessage =
                error.response?.data?.detail ||
                "Something went wrong. Please try again.";
            setApiError(errorMessage);
        }
    };

    return (
        <>
            {apiError && <div className={styles.errorMessage}>{apiError}</div>}
            <form
                className={styles.formContainer}
                onSubmit={handleSubmit(onSubmit)}
            >
                <div className={styles.formGroup}>
                    <label className={styles.label}>Email</label>
                    <input
                        type="email"
                        className={styles.input}
                        placeholder="Enter your email"
                        {...register("email")}
                    />
                    {errors.email && (
                        <span className={styles.error}>
                            {errors.email.message}
                        </span>
                    )}
                </div>

                <div className={styles.formGroup}>
                    <label className={styles.label}>Password</label>
                    <input
                        type="password"
                        className={styles.input}
                        placeholder="Enter your password"
                        {...register("password")}
                    />
                    {errors.password && (
                        <span className={styles.error}>
                            {errors.password.message}
                        </span>
                    )}
                </div>

                <button
                    type="submit"
                    className={styles.submitButton}
                    disabled={isSubmitting}
                >
                    {isSubmitting ? "Logging in..." : "Login"}
                </button>
            </form>
        </>
    );
};
