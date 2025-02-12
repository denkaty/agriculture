import { useEffect, useState } from "react";
import { itemsService } from "../../services/items.service";
import { Item } from "../../types/items.types";
import { InventoryDetail } from "../../types/inventory.types";
import { Spinner } from "../../../../shared/components/Spinner/Spinner";
import { ItemsTable } from "../../components/ItemsTable/ItemsTable";
import { ItemsListPagination } from "../../components/ItemsListPagination/ItemsListPagination";
import { ItemWarehousesPanel } from "../../components/ItemWarehousesPanel/ItemWarehousesPanel";
import { EntityToolbar } from "../../../../shared/components/EntityToolbar/EntityToolbar";
import styles from "./Items.module.css";
import axios from "axios";

export const Items = () => {
    const [items, setItems] = useState<Item[]>([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState<string | null>(null);
    const [selectedItemId, setSelectedItemId] = useState<string | null>(null);
    const [searchTerm, setSearchTerm] = useState("");
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
    const [searchTimeout, setSearchTimeout] = useState<number>();

    const loadItems = async (term?: string) => {
        try {
            setLoading(true);
            setError(null);
            const response = await itemsService.getItems(
                pagination.page,
                pagination.pageSize,
                term
            );
            setItems(response.data);
            setPagination((prev) => ({
                ...prev,
                totalCount: response.totalCount,
                hasNextPage: response.hasNextPage,
                hasPreviousPage: response.hasPreviousPage,
            }));
        } catch (err) {
            if (axios.isAxiosError(err) && err.response?.status === 404) {
                setItems([]);
            } else {
                setError("Failed to load items");
                console.error("Error loading items:", err);
            }
        } finally {
            setLoading(false);
        }
    };

    useEffect(() => {
        loadItems(searchTerm);
        return () => {
            if (searchTimeout) {
                clearTimeout(searchTimeout);
            }
        };
    }, []);

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

    const handleSearch = (term: string) => {
        setSearchTerm(term);

        if (searchTimeout) {
            clearTimeout(searchTimeout);
        }

        if (term && term.length < 2) {
            return;
        }

        const timeout = window.setTimeout(() => {
            loadItems(term);
        }, 500);

        setSearchTimeout(timeout);
    };

    const handleCreateNew = () => {
        console.log("Creating new item");
    };

    if (loading) return <Spinner />;
    if (error) return <div className={styles.error}>{error}</div>;

    const selectedItem = items.find((item) => item.id === selectedItemId);

    return (
        <div className={styles.container}>
            <div className={styles.content}>
                <div className={styles.mainContent}>
                    <EntityToolbar
                        entityName="Items"
                        onSearch={handleSearch}
                        onCreateNew={handleCreateNew}
                        searchValue={searchTerm}
                        isSearchVisible={Boolean(searchTerm)}
                    />
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
