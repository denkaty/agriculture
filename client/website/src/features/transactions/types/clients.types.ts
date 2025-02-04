export interface Client {
    id: string;
    name: string;
    address: string;
    phoneNumber: string;
    contactPerson: string;
    createdAt: string;
    updatedAt: string;
}

export interface ClientsResponse {
    data: Client[];
    page: number;
    pageSize: number;
    totalCount: number;
    hasNextPage: boolean;
    hasPreviousPage: boolean;
}
