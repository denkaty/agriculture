import { Navigate, Outlet } from "react-router-dom";
import { useAuth } from "../features/users/context/AuthContext";

export const PublicLayout = () => {
    const { isAuthenticated } = useAuth();

    if (isAuthenticated) {
        return <Navigate to="/items" />;
    }

    return <Outlet />;
};
