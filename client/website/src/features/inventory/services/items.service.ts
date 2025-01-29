import { api } from "../../../core/api/axiosInstance.config";
import { API_CONFIG } from "../../../core/config/apiEndpoints.config";
import { ItemsResponse } from "../types/items.types";
import { InventoryResponse } from "../types/inventory.types";
import axios from "axios";

export const itemsService = {
    getItems: async (
        page: number = 1,
        pageSize: number = 10
    ): Promise<ItemsResponse> => {
        const response = await api.get<ItemsResponse>(
            `${API_CONFIG.endpoints.inventory.items.base}?page=${page}&pageSize=${pageSize}`
        );
        return response.data;
    },

    getInventoryDetailsByItemId: async (
        itemId: string
    ): Promise<InventoryResponse> => {
        try {
            const response = await api.get<InventoryResponse>(
                `${API_CONFIG.endpoints.inventory.inventories.byItemId}/${itemId}`
            );
            return response.data;
        } catch (error) {
            if (axios.isAxiosError(error)) {
                throw new Error(
                    error.response?.data?.message ||
                        "Failed to fetch inventory details"
                );
            }
            throw error;
        }
    },
};
