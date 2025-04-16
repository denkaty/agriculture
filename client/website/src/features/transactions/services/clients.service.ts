import { api } from "../../../core/api/axiosInstance.config";
import { API_CONFIG } from "../../../core/config/apiEndpoints.config";
import { ClientsResponse } from "../types/clients.types";

export const clientsService = {
    getClients: async (
        page: number,
        pageSize: number
    ): Promise<ClientsResponse> => {
        const response = await api.get(
            `${API_CONFIG.endpoints.transactions.clients.base}?page=${page}&pageSize=${pageSize}`
        );
        return response.data;
    },
};
