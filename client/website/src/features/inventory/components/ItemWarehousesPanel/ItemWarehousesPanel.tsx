import { InventoryDetail } from "../../types/inventory.types";
import { Item } from "../../types/items.types";
import styles from "./ItemWarehousesPanel.module.css";

interface ItemWarehousesPanelProps {
    selectedItem: Item;
    inventoryDetails: InventoryDetail[];
    loadingDetails: boolean;
    error: string | null;
    onClose: () => void;
}

export const ItemWarehousesPanel = ({
    selectedItem,
    inventoryDetails,
    loadingDetails,
    error,
    onClose,
}: ItemWarehousesPanelProps) => {
    return (
        <div className={styles.warehousesPanel}>
            <div className={styles.warehousesHeader}>
                <h2>Warehouse</h2>
                <button className={styles.closeButton} onClick={onClose}>
                    ×
                </button>
            </div>
            <div className={styles.warehousesContent}>
                {loadingDetails ? (
                    <div className={styles.loading}>Loading details...</div>
                ) : error ? (
                    <div className={styles.error}>{error}</div>
                ) : (
                    <div className={styles.warehousesList}>
                        <div className={styles.headerRow}>
                            <span>Warehouse</span>
                            <span>Quantity</span>
                            <span>Location</span>
                        </div>
                        {inventoryDetails.length > 0 ? (
                            inventoryDetails.map((detail) => (
                                <div
                                    key={detail.id}
                                    className={styles.warehousesRow}
                                >
                                    <span>{detail.warehouseName}</span>
                                    <span>{detail.quantity}</span>
                                    <span>-</span>
                                </div>
                            ))
                        ) : (
                            <div className={styles.noData}>
                                No warehouse data available
                            </div>
                        )}
                    </div>
                )}
            </div>
        </div>
    );
};
