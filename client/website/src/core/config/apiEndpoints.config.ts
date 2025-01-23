export const API_CONFIG = {
    baseUrl: import.meta.env.VITE_API_GATEWAY_URL,
    endpoints: {
        users: {
            users: {
                base: "/api/v1/users",
                register: "/api/v1/users/register",
                login: "/api/v1/users/login",
            },
        },
        inventory: {
            items: {
                base: "/api/v1/items",
                // specific item endpoints here
            },
            warehouses: {
                base: "/api/v1/warehouses",
                // specific warehouse endpoints here
            },
        },
        transactions: {
            clients: {
                base: "/api/v1/clients",
                // specific client endpoints here
            },
            suppliers: {
                base: "/api/v1/suppliers",
                // specific supplier endpoints here
            },
            buyOrders: {
                base: "/api/v1/buy-orders",
                // specific buy order endpoints here
            },
            sellOrders: {
                base: "/api/v1/sell-orders",
                // specific sell order endpoints here
            },
        },
    },
};
