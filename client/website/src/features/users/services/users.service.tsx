import { api } from "../../../core/api/axiosInstance.config";
import { API_CONFIG } from "../../../core/config/apiEndpoints.config";
import {
    RegisterRequest,
    RegisterResponse,
    LoginRequest,
    LoginResponse,
} from "../types/users.types";

export const usersService = {
    register: async (data: RegisterRequest): Promise<RegisterResponse> => {
        const response = await api.post<RegisterResponse>(
            API_CONFIG.endpoints.users.users.register,
            data
        );
        return response.data;
    },
    login: async (data: LoginRequest): Promise<LoginResponse> => {
        const response = await api.post(
            API_CONFIG.endpoints.users.users.login,
            data
        );
        return response.data;
    },
};
