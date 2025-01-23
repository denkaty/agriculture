import { RegisterForm } from "../../components/RegisterForm/RegisterForm";
import styles from "./RegisterView.module.css";

export const RegisterView = () => {
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
            </div>
        </div>
    );
};
