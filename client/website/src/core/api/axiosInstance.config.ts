import axios from "axios";
import { API_CONFIG } from "../config/apiEndpoints.config";

export const api = axios.create({
    baseURL: API_CONFIG.baseUrl,
    headers: {
        "Content-Type": "application/json",
    },
});

// Add request interceptor for auth token
api.interceptors.request.use(
    (config) => {
        const token = localStorage.getItem("token");
        if (token) {
            config.headers.Authorization = `Bearer ${token}`;
        }
        return config;
    },
    (error) => {
        return Promise.reject(error);
    }
);

// Add response interceptor for error handling
api.interceptors.response.use(
    (response) => response,
    (error) => {
        if (error.response?.status === 401) {
            // Handle unauthorized access
            localStorage.removeItem("token");
            window.location.href = "/login";
        }
        return Promise.reject(error);
    }
);
