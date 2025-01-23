import { api } from "../../../core/api/axiosInstance.config";
import { API_CONFIG } from "../../../core/config/apiEndpoints.config";
import { RegisterDto, RegisterResponse } from "../types/users.types";

export const usersService = {
    register: async (data: RegisterDto): Promise<RegisterResponse> => {
        const response = await api.post<RegisterResponse>(
            API_CONFIG.endpoints.users.users.register,
            data
        );
        return response.data;
    },
};
