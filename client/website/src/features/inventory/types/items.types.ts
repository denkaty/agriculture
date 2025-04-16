export interface Item {
    id: string;
    catalogNumber: string;
    name: string;
    description: string;
    createdAt: string;
    updatedAt: string;
}

export interface ItemsResponse {
    data: Item[];
    page: number;
    pageSize: number;
    totalCount: number;
    hasNextPage: boolean;
    hasPreviousPage: boolean;
}
