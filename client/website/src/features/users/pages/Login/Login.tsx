import { Link } from "react-router-dom";
import { LoginForm } from "../../components/LoginForm/LoginForm";
import styles from "./Login.module.css";
import { Spinner } from "../../../../shared/components/Spinner/Spinner";
import { useState } from "react";

export const Login = () => {
    const [isLoading, setIsLoading] = useState(false);

    return (
        <div className={styles.container}>
            {isLoading && <Spinner variant="fullscreen" />}
            <div className={styles.content}>
                <div className={styles.header}>
                    <h1 className={styles.title}>Login</h1>
                    <p className={styles.subtitle}>
                        Enter your credentials to access your account
                    </p>
                </div>
                <LoginForm />
                <div className={styles.linkContainer}>
                    <Link to="/register" className={styles.link}>
                        Don't have an account? Register here
                    </Link>
                </div>
            </div>
        </div>
    );
};
