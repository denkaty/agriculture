export interface Supplier {
    id: string;
    name: string;
    address: string;
    phoneNumber: string;
    contactPerson: string;
    createdAt: string;
    updatedAt: string;
}

export interface SuppliersResponse {
    data: Supplier[];
    page: number;
    pageSize: number;
    totalCount: number;
    hasNextPage: boolean;
    hasPreviousPage: boolean;
}
