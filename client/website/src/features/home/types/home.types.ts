export interface HomeStats {
    monthlySales: number;
    currentSales: {
        salesOrders: number;
        orders: number;
    };
    currentPurchases: {
        purchaseOrders: number;
    };
    transfers: {
        notShipped: number;
        shipped: number;
    };
}
