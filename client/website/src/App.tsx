import { createBrowserRouter, RouterProvider } from "react-router-dom";
import { AuthProvider } from "./features/users/context/AuthContext";
import { AuthLayout } from "./layouts/AuthLayout";
import { AppLayout } from "./layouts/AppLayout";
import { LoginView } from "./features/users/views/LoginView/LoginView";
import { RegisterView } from "./features/users/views/RegisterView/RegisterView";
import { ItemsView } from "./features/inventory/views/ItemsView/ItemsView";

const router = createBrowserRouter([
    {
        // Auth routes (login, register, forgot password)
        path: "/",
        element: <AuthLayout />,
        children: [
            {
                path: "login",
                element: <LoginView />,
            },
            {
                path: "register",
                element: <RegisterView />,
            },
            {
                path: "items",
                element: <ItemsView />,
            },
        ],
    },
    {
        // Protected app routes
        path: "/",
        element: <AppLayout />,
        children: [
            {
                index: true,
                element: <div>Dashboard</div>,
            },

            // ... other protected routes
        ],
    },
]);

function App() {
    return (
        <AuthProvider>
            <RouterProvider router={router} />
        </AuthProvider>
    );
}

export default App;
