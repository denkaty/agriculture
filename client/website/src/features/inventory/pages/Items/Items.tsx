import { useEffect, useState } from "react";
import { itemsService } from "../../services/items.service";
import { Item } from "../../types/items.types";
import { InventoryDetail } from "../../types/inventory.types";
import { Spinner } from "../../../../shared/components/Spinner/Spinner";
import { ItemsTable } from "../../components/ItemsTable/ItemsTable";
import { ItemsListPagination } from "../../components/ItemsListPagination/ItemsListPagination";
import { ItemWarehousesPanel } from "../../components/ItemWarehousesPanel/ItemWarehousesPanel";
import styles from "./Items.module.css";

export const Items = () => {
    const [items, setItems] = useState<Item[]>([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState<string | null>(null);
    const [selectedItemId, setSelectedItemId] = useState<string | null>(null);
    const [inventoryDetails, setInventoryDetails] = useState<InventoryDetail[]>(
        []
    );
    const [loadingDetails, setLoadingDetails] = useState(false);
    const [pagination, setPagination] = useState({
        page: 1,
        pageSize: 10,
        totalCount: 0,
        hasNextPage: false,
        hasPreviousPage: false,
    });

    useEffect(() => {
        const fetchItems = async () => {
            try {
                setLoading(true);
                const response = await itemsService.getItems(
                    pagination.page,
                    pagination.pageSize
                );
                setItems(response.data);
                setPagination((prev) => ({
                    ...prev,
                    totalCount: response.totalCount,
                    hasNextPage: response.hasNextPage,
                    hasPreviousPage: response.hasPreviousPage,
                }));
            } catch (error) {
                setError("Failed to fetch items. Please try again later.");
            } finally {
                setLoading(false);
            }
        };

        fetchItems();
    }, [pagination.page]);

    const handleRowClick = async (item: Item) => {
        try {
            setSelectedItemId(item.id);
            setLoadingDetails(true);
            const response = await itemsService.getInventoryDetailsByItemId(
                item.id
            );
            setInventoryDetails(response.data);
        } catch (err) {
            setError("Failed to load inventory details");
        } finally {
            setLoadingDetails(false);
        }
    };

    if (loading) return <Spinner />;
    if (error) return <div className={styles.error}>{error}</div>;

    const selectedItem = items.find((item) => item.id === selectedItemId);

    return (
        <div className={styles.container}>
            <div className={styles.content}>
                <div className={styles.mainContent}>
                    <div className={styles.tableWrapper}>
                        <ItemsTable
                            items={items}
                            selectedItemId={selectedItemId}
                            onRowClick={handleRowClick}
                        />
                    </div>
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
                {selectedItem && (
                    <ItemWarehousesPanel
                        selectedItem={selectedItem}
                        inventoryDetails={inventoryDetails}
                        loadingDetails={loadingDetails}
                        error={error}
                        onClose={() => {
                            setSelectedItemId(null);
                            setInventoryDetails([]);
                        }}
                    />
                )}
            </div>
        </div>
    );
};
