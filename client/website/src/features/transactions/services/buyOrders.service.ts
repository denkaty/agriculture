import { api } from "../../../core/api/axiosInstance.config";
import { API_CONFIG } from "../../../core/config/apiEndpoints.config";
import {
    BuyOrdersResponse,
    BuyOrderDetail,
    ItemDetail,
} from "../types/buyOrders.types";

export const buyOrdersService = {
    getBuyOrders: async (
        page: number,
        pageSize: number
    ): Promise<BuyOrdersResponse> => {
        const response = await api.get(
            `${API_CONFIG.endpoints.transactions.buyOrders.base}?page=${page}&pageSize=${pageSize}`
        );
        return response.data;
    },

    getBuyOrderById: async (id: string): Promise<BuyOrderDetail> => {
        const response = await api.get(
            `${API_CONFIG.endpoints.transactions.buyOrders.base}/${id}`
        );
        return response.data;
    },

    getItemsByIds: async (
        itemIds: string[]
    ): Promise<{ data: ItemDetail[] }> => {
        const response = await api.post(
            API_CONFIG.endpoints.inventory.items.byItemsIds,
            itemIds
        );
        return response.data;
    },
};
