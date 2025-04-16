import { api } from "../../../core/api/axiosInstance.config";
import { API_CONFIG } from "../../../core/config/apiEndpoints.config";
import { SuppliersResponse } from "../types/suppliers.types";

export const suppliersService = {
    getSuppliers: async (
        page: number = 1,
        pageSize: number = 10
    ): Promise<SuppliersResponse> => {
        const response = await api.get<SuppliersResponse>(
            `${API_CONFIG.endpoints.transactions.suppliers.base}?page=${page}&pageSize=${pageSize}`
        );
        return response.data;
    },

    getSupplierById: async (supplierId: string) => {
        const response = await api.get(
            `${API_CONFIG.endpoints.transactions.suppliers.base}/${supplierId}`
        );
        return response.data;
    },
};
