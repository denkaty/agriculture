import { createBrowserRouter, RouterProvider } from "react-router-dom";
import { AuthProvider } from "./features/users/context/AuthContext";
import { AuthLayout } from "./layouts/AuthLayout";
import { AppLayout } from "./layouts/AppLayout";
import { LoginView } from "./features/users/views/LoginView/LoginView";
import { RegisterView } from "./features/users/views/RegisterView/RegisterView";

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
            {
                path: "products",
                element: <div>Products</div>,
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
