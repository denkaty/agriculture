export interface InventoryDetail {
    id: string;
    itemId: string;
    warehouseId: string;
    warehouseName: string;
    quantity: number;
    createdAt: string;
    updatedAt: string;
}

export interface InventoryResponse {
    data: InventoryDetail[];
}
