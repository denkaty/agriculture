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
import { CreateItemModal } from "../../components/CreateItemModal/CreateItemModal";
import { ItemDetailsModal } from "../../components/ItemDetailsModal/ItemDetailsModal";

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
    const [showCreateModal, setShowCreateModal] = useState(false);
    const [showDetailsModal, setShowDetailsModal] = useState(false);

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
        if (selectedItemId !== item.id) {
            setSelectedItemId(item.id);
            try {
                const response = await itemsService.getInventoryDetailsByItemId(
                    item.id
                );
                setInventoryDetails(response.data);
            } catch (err) {
                setError("Failed to load inventory details");
            } finally {
            }
        }
    };

    const handleCatalogNumberClick = (item: Item) => {
        setSelectedItemId(item.id);
        setShowDetailsModal(true);
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
        setShowCreateModal(true);
    };

    const handleCreateSubmit = async (itemData: Partial<Item>) => {
        try {
            await itemsService.createItem(itemData);
            setShowCreateModal(false);
            loadItems(searchTerm); // Refresh the list
        } catch (error) {
            throw error; // Let the modal handle the error display
        }
    };

    const handleDeleteItem = () => {
        if (selectedItemId) {
            // Remove from local state immediately
            setItems((prevItems) =>
                prevItems.filter((item) => item.id !== selectedItemId)
            );
            // Close the modal and clear selection
            setSelectedItemId(null);
            // Clear details panel
            setInventoryDetails([]);
            // Refresh the list
            loadItems(searchTerm);
        }
    };

    if (loading) return <Spinner variant="inline" />;
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
                            onCatalogNumberClick={handleCatalogNumberClick}
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
            {showCreateModal && (
                <CreateItemModal
                    onClose={() => setShowCreateModal(false)}
                    onSubmit={handleCreateSubmit}
                />
            )}
            {selectedItem && showDetailsModal && (
                <ItemDetailsModal
                    item={selectedItem}
                    onClose={() => {
                        setShowDetailsModal(false);
                        setSelectedItemId(null);
                    }}
                    onDelete={handleDeleteItem}
                />
            )}
        </div>
    );
};
