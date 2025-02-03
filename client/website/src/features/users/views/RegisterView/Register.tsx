import { Link } from "react-router-dom";
import { RegisterForm } from "../../components/RegisterForm/RegisterForm";
import styles from "./Register.module.css";

export const Register = () => {
    return (
        <div className={styles.container}>
            <div className={styles.content}>
                <div className={styles.header}>
                    <h1 className={styles.title}>Create Account</h1>
                    <p className={styles.subtitle}>
                        Enter your details to create your account
                    </p>
                </div>
                <RegisterForm />
                <div className={styles.linkContainer}>
                    <Link to="/login" className={styles.link}>
                        Already have an account? Login here
                    </Link>
                </div>
            </div>
        </div>
    );
};
