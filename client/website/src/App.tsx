import { BrowserRouter, Routes, Route, Navigate } from "react-router-dom";
import { ProtectedLayout } from "./layouts/ProtectedLayout/ProtectedLayout";
import { PublicLayout } from "./layouts/PublicLayout";
import { Login } from "./features/users/views/Login/Login";
import { Register } from "./features/users/views/RegisterView/Register";
import { ItemsView } from "./features/inventory/views/ItemsView/ItemsView";
import { AuthProvider } from "./features/users/context/AuthContext";

export const App = () => {
    return (
        <AuthProvider>
            <BrowserRouter>
                <Routes>
                    {/* Public routes */}
                    <Route element={<PublicLayout />}>
                        <Route path="/login" element={<Login />} />
                        <Route path="/register" element={<Register />} />
                    </Route>

                    {/* Protected routes */}
                    <Route element={<ProtectedLayout />}>
                        <Route path="/items" element={<ItemsView />} />
                        {/* Add other protected routes here */}
                    </Route>

                    {/* Redirect root to items */}
                    <Route path="/" element={<Navigate to="/items" />} />
                </Routes>
            </BrowserRouter>
        </AuthProvider>
    );
};

export default App;
