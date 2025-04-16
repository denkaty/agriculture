import { jwtDecode } from "jwt-decode";

const TOKEN_KEY = "auth_token";

interface DecodedToken {
    exp: number; // Expiration timestamp (in seconds)
    [key: string]: any; // Additional claims
}

export const tokenService = {
    setToken(token: string) {
        localStorage.setItem(TOKEN_KEY, token);
    },

    getToken(): string | null {
        return localStorage.getItem(TOKEN_KEY);
    },

    removeToken() {
        localStorage.removeItem(TOKEN_KEY);
    },

    isTokenValid(): boolean {
        const token = this.getToken();

        if (!token) {
            return false;
        }

        try {
            const decoded: DecodedToken = jwtDecode(token);
            const now = Date.now() / 1000; // Current time in seconds
            return decoded.exp > now; // Token is valid if expiration time is in the future
        } catch (error) {
            console.error("Invalid token:", error);
            return false;
        }
    },
};
