import { Outlet } from "react-router-dom";
import { AppHeader } from "../shared/components/AppHeader/AppHeader";

export const AppLayout = () => {
    return (
        <div>
            <AppHeader />
            <main>
                <Outlet />
            </main>
        </div>
    );
};
