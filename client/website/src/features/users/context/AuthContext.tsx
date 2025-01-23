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
    };

    useEffect(() => {
        // Revalidate token whenever the component mounts
        const interval = setInterval(() => {
            setIsAuthenticated(tokenService.isTokenValid());
        }, 60 * 1000); // Check every 1 minute

        return () => clearInterval(interval);
    }, []);

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
