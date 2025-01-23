import { Outlet, Navigate } from "react-router-dom";
import { useAuth } from "../features/users/context/AuthContext";

export const AppLayout = () => {
    const { isAuthenticated } = useAuth();

    if (!isAuthenticated) {
        return <Navigate to="/login" replace />;
    }

    return (
        <div className="app-layout">
            {/* Add your navigation, sidebar, etc. here */}
            <Outlet />
        </div>
    );
};
