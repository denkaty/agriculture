import { useEffect, useState } from "react";
import { buyOrdersService } from "../../services/buyOrders.service";
import { BuyOrder } from "../../types/buyOrders.types";
import { Spinner } from "../../../../shared/components/Spinner/Spinner";
import { BuyOrdersTable } from "../../components/BuyOrdersTable/BuyOrdersTable";
import { ItemsListPagination } from "../../../inventory/components/ItemsListPagination/ItemsListPagination";
import styles from "./BuyOrders.module.css";

export const BuyOrders = () => {
    const [buyOrders, setBuyOrders] = useState<BuyOrder[]>([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState<string | null>(null);
    const [selectedBuyOrderId, setSelectedBuyOrderId] = useState<string | null>(
        null
    );
    const [pagination, setPagination] = useState({
        page: 1,
        pageSize: 10,
        totalCount: 0,
        hasNextPage: false,
        hasPreviousPage: false,
    });

    useEffect(() => {
        const fetchBuyOrders = async () => {
            try {
                const response = await buyOrdersService.getBuyOrders(
                    pagination.page,
                    pagination.pageSize
                );
                setBuyOrders(response.data);
                setPagination({
                    ...pagination,
                    totalCount: response.totalCount,
                    hasNextPage: response.hasNextPage,
                    hasPreviousPage: response.hasPreviousPage,
                });
            } catch (err) {
                setError("Failed to fetch buy orders. Please try again later.");
            } finally {
                setLoading(false);
            }
        };

        fetchBuyOrders();
    }, [pagination.page]);

    const handleRowClick = async (buyOrder: BuyOrder) => {
        setSelectedBuyOrderId(buyOrder.id);
    };

    if (loading) return <Spinner variant="inline" />;
    if (error) return <div className={styles.error}>{error}</div>;

    return (
        <div className={styles.container}>
            {loading ? (
                <Spinner variant="inline" />
            ) : (
                <div className={styles.content}>
                    <div className={styles.mainContent}>
                        <div className={styles.tableWrapper}>
                            <BuyOrdersTable
                                buyOrders={buyOrders}
                                selectedBuyOrderId={selectedBuyOrderId}
                                onRowClick={handleRowClick}
                            />
                        </div>
                        <div className={styles.paginationWrapper}>
                            <ItemsListPagination
                                currentPage={pagination.page}
                                totalCount={pagination.totalCount}
                                pageSize={pagination.pageSize}
                                hasNextPage={pagination.hasNextPage}
                                hasPreviousPage={pagination.hasPreviousPage}
                                onPageChange={(page) =>
                                    setPagination((prev) => ({ ...prev, page }))
                                }
                            />
                        </div>
                    </div>
                </div>
            )}
        </div>
    );
};
