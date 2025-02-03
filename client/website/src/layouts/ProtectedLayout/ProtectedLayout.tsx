import { Navigate, Outlet } from "react-router-dom";
import { AppHeader } from "../../shared/components/AppHeader/AppHeader";
import { SubHeader } from "../../shared/components/SubHeader/SubHeader";
import styles from "./ProtectedLayout.module.css";
import { useAuth } from "../../features/users/context/AuthContext";

export const ProtectedLayout = () => {
    const { isAuthenticated } = useAuth();

    if (!isAuthenticated) {
        return <Navigate to="/login" />;
    }

    return (
        <div className={styles.layout}>
            <AppHeader />
            <SubHeader />
            <main className={styles.main}>
                <Outlet />
            </main>
        </div>
    );
};
