export interface BuyOrder {
    id: string;
    supplierName: string;
    orderDate: string;
    totalAmount: number;
    createdAt: string;
    updatedAt: string;
}

export interface BuyOrderDetail {
    id: string;
    supplierId: string;
    orderDate: string;
    totalAmount: number;
    items: BuyOrderItem[];
}

export interface BuyOrderItem {
    itemId: string;
    warehouseId: string;
    quantity: number;
    unitPrice: number;
    subTotal: number;
}

export interface ItemDetail {
    id: string;
    catalogNumber: string;
    name: string;
    description: string;
}

export interface BuyOrdersResponse {
    data: BuyOrder[];
    page: number;
    pageSize: number;
    totalCount: number;
    hasNextPage: boolean;
    hasPreviousPage: boolean;
}
