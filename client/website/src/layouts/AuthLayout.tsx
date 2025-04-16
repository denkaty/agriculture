import { Outlet, Navigate } from "react-router-dom";
import { useAuth } from "../features/users/context/AuthContext";

export const AuthLayout = () => {
    const { isAuthenticated } = useAuth();

    if (isAuthenticated) {
        return <Navigate to="/" replace />;
    }

    return (
        <div className="auth-layout">
            <Outlet />
        </div>
    );
};
