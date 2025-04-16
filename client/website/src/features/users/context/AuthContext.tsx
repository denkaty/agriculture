import {
    createContext,
    useContext,
    ReactNode,
    useState,
    useEffect,
} from "react";
import { tokenService } from "../../../lib/token";

interface AuthContextType {
    isAuthenticated: boolean;
    login: (token: string) => void;
    logout: () => void;
}

const AuthContext = createContext<AuthContextType | null>(null);

export const AuthProvider = ({ children }: { children: ReactNode }) => {
    const [isAuthenticated, setIsAuthenticated] = useState(() => {
        return tokenService.isTokenValid();
    });

    const login = (token: string) => {
        tokenService.setToken(token);
        setIsAuthenticated(true);
    };

    const logout = () => {
        tokenService.removeToken();
        setIsAuthenticated(false);
        window.location.href = "/login";
    };

    useEffect(() => {
        const checkAuth = () => {
            const isValid = tokenService.isTokenValid();
            if (!isValid && isAuthenticated) {
                logout();
            }
        };

        // Check immediately
        checkAuth();

        // Check more frequently (every 30 seconds)
        const interval = setInterval(checkAuth, 30 * 1000);

        // Add event listener for storage changes
        const handleStorageChange = (e: StorageEvent) => {
            if (e.key === "auth_token") {
                checkAuth();
            }
        };

        window.addEventListener("storage", handleStorageChange);

        return () => {
            clearInterval(interval);
            window.removeEventListener("storage", handleStorageChange);
        };
    }, [isAuthenticated]);

    return (
        <AuthContext.Provider value={{ isAuthenticated, login, logout }}>
            {children}
        </AuthContext.Provider>
    );
};

export const useAuth = () => {
    const context = useContext(AuthContext);
    if (!context) {
        throw new Error("useAuth must be used within an AuthProvider");
    }
    return context;
};
