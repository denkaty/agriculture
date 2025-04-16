import { Navigate, Outlet } from "react-router-dom";
import { useEffect } from "react";
import { AppHeader } from "../../shared/components/AppHeader/AppHeader";
import { SubHeader } from "../../shared/components/SubHeader/SubHeader";
import styles from "./ProtectedLayout.module.css";
import { useAuth } from "../../features/users/context/AuthContext";
import { tokenService } from "../../lib/token";

export const ProtectedLayout = () => {
    const { isAuthenticated, logout } = useAuth();

    useEffect(() => {
        // Check token validity on mount and when isAuthenticated changes
        if (isAuthenticated && !tokenService.isTokenValid()) {
            logout();
        }
    }, [isAuthenticated, logout]);

    if (!isAuthenticated || !tokenService.isTokenValid()) {
        return <Navigate to="/login" replace />;
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
