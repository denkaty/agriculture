import { api } from "../../../core/api/axiosInstance.config";
import { API_CONFIG } from "../../../core/config/apiEndpoints.config";
import { ItemsResponse, Item } from "../types/items.types";
import { InventoryResponse } from "../types/inventory.types";
import axios from "axios";

interface ErrorResponse {
    type: string;
    title: string;
    status: number;
    detail: string;
    errors: Record<string, string[]>;
}

export const itemsService = {
    getItems: async (
        page: number = 1,
        pageSize: number = 10,
        searchTerm?: string
    ): Promise<ItemsResponse> => {
        const params = new URLSearchParams({
            page: page.toString(),
            pageSize: pageSize.toString(),
        });

        if (searchTerm) {
            params.append("searchTerm", searchTerm);
        }

        const response = await api.get<ItemsResponse>(
            `${API_CONFIG.endpoints.inventory.items.base}?${params.toString()}`
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

    createItem: async (itemData: Partial<Item>): Promise<Item> => {
        try {
            const response = await api.post<Item>(
                API_CONFIG.endpoints.inventory.items.base,
                itemData
            );
            return response.data;
        } catch (error) {
            if (axios.isAxiosError(error)) {
                const errorResponse = error.response?.data as ErrorResponse;
                throw new Error(
                    errorResponse?.detail || "Failed to create item"
                );
            }
            throw error;
        }
    },

    deleteItem: async (itemId: string): Promise<void> => {
        try {
            await api.delete(
                `${API_CONFIG.endpoints.inventory.items.base}/${itemId}`
            );
        } catch (error) {
            if (axios.isAxiosError(error)) {
                const errorResponse = error.response?.data as ErrorResponse;
                throw new Error(
                    errorResponse?.detail || "Failed to delete item"
                );
            }
            throw error;
        }
    },
};
