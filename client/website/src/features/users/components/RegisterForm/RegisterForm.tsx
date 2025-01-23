import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import * as yup from "yup";
import { RegisterDto } from "../../types/users.types";
import { usersService } from "../../services/users.service";
import styles from "./RegisterForm.module.css";
import { useState } from "react";

const schema = yup.object({
    email: yup.string().email("Invalid email").required("Email is required"),
    password: yup
        .string()
        .min(6, "Password must be at least 6 characters")
        .required("Password is required"),
    confirmPassword: yup
        .string()
        .oneOf([yup.ref("password")], "Passwords must match")
        .required("Confirm password is required"),
    phoneNumber: yup.string().required("Phone number is required"),
    firstName: yup.string().required("First name is required"),
    lastName: yup.string().required("Last name is required"),
});

export const RegisterForm = () => {
    const [apiError, setApiError] = useState<string | null>(null);
    const {
        register,
        handleSubmit,
        formState: { errors, isSubmitting },
        setError,
    } = useForm<RegisterDto>({
        resolver: yupResolver(schema),
    });

    const onSubmit = async (data: RegisterDto) => {
        try {
            setApiError(null); // Clear previous error
            const response = await usersService.register(data);
            console.log("Registration successful:", response);
            // Here you can:
            // 1. Show success message
            // 2. Redirect to login
            // 3. Automatically log them in
        } catch (error: any) {
            // Extract the detail message from the error response
            const errorMessage =
                error.response?.data?.detail ||
                "Registration failed. Please try again.";

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
                        {...register("email")}
                        type="email"
                        placeholder="Enter your email"
                        className={styles.input}
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
                        {...register("password")}
                        type="password"
                        placeholder="Enter your password"
                        className={styles.input}
                    />
                    {errors.password && (
                        <span className={styles.error}>
                            {errors.password.message}
                        </span>
                    )}
                </div>
                <div className={styles.formGroup}>
                    <label className={styles.label}>Confirm Password</label>
                    <input
                        {...register("confirmPassword")}
                        type="password"
                        placeholder="Confirm your password"
                        className={styles.input}
                    />
                    {errors.confirmPassword && (
                        <span className={styles.error}>
                            {errors.confirmPassword.message}
                        </span>
                    )}
                </div>
                <div className={styles.formGroup}>
                    <label className={styles.label}>Phone Number</label>
                    <input
                        {...register("phoneNumber")}
                        type="tel"
                        placeholder="Enter your phone number"
                        className={styles.input}
                    />
                    {errors.phoneNumber && (
                        <span className={styles.error}>
                            {errors.phoneNumber.message}
                        </span>
                    )}
                </div>
                <div className={styles.formGroup}>
                    <label className={styles.label}>First Name</label>
                    <input
                        {...register("firstName")}
                        placeholder="Enter your first name"
                        className={styles.input}
                    />
                    {errors.firstName && (
                        <span className={styles.error}>
                            {errors.firstName.message}
                        </span>
                    )}
                </div>
                <div className={styles.formGroup}>
                    <label className={styles.label}>Last Name</label>
                    <input
                        {...register("lastName")}
                        placeholder="Enter your last name"
                        className={styles.input}
                    />
                    {errors.lastName && (
                        <span className={styles.error}>
                            {errors.lastName.message}
                        </span>
                    )}
                </div>
                <button
                    type="submit"
                    className={styles.submitButton}
                    disabled={isSubmitting}
                >
                    {isSubmitting ? "Creating Account..." : "Create Account"}
                </button>
            </form>
        </>
    );
};
