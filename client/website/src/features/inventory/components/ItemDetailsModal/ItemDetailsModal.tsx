import { Item } from "../../types/items.types";
import { InventoryDetail } from "../../types/inventory.types";
import styles from "./ItemDetailsModal.module.css";
import { useEffect, useState } from "react";
import { itemsService } from "../../services/items.service";
import { ConfirmDialog } from "../../../../shared/components/ConfirmDialog/ConfirmDialog";

interface ItemDetailsModalProps {
    item: Item;
    onClose: () => void;
    onDelete?: () => void;
}

export const ItemDetailsModal = ({
    item,
    onClose,
    onDelete,
}: ItemDetailsModalProps) => {
    const [inventoryDetails, setInventoryDetails] = useState<InventoryDetail[]>(
        []
    );
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState<string | null>(null);
    const [isEditing, setIsEditing] = useState(true);
    const [editedItem, setEditedItem] = useState(item);
    const [isDirty, setIsDirty] = useState(false);
    const [showConfirmDialog, setShowConfirmDialog] = useState(false);
    const [showDeleteDialog, setShowDeleteDialog] = useState(false);
    const [deleteError, setDeleteError] = useState<string | null>(null);
    const [isDeleting, setIsDeleting] = useState(false);

    useEffect(() => {
        const fetchInventoryDetails = async () => {
            try {
                const response = await itemsService.getInventoryDetailsByItemId(
                    item.id
                );
                setInventoryDetails(response.data);
            } catch (err) {
                setError("Failed to load inventory details");
            } finally {
                setLoading(false);
            }
        };

        fetchInventoryDetails();
    }, [item.id]);

    const handleInputChange = (field: keyof Item, value: string) => {
        setEditedItem((prev) => ({
            ...prev,
            [field]: value,
        }));
        setIsDirty(true);
    };

    const handleBackClick = () => {
        if (isDirty) {
            setShowConfirmDialog(true);
        } else {
            onClose();
        }
    };

    const handleConfirmBack = () => {
        setShowConfirmDialog(false);
        onClose();
    };

    const handleDeleteClick = () => {
        setShowDeleteDialog(true);
    };

    const handleConfirmDelete = async () => {
        try {
            setIsDeleting(true);
            setDeleteError(null);
            await itemsService.deleteItem(item.id);
            setShowDeleteDialog(false);
            onDelete?.();
            onClose();
        } catch (err) {
            setDeleteError(
                err instanceof Error ? err.message : "Failed to delete item"
            );
        } finally {
            setIsDeleting(false);
        }
    };

    return (
        <>
            <div className={styles.modalOverlay}>
                <div className={styles.modal}>
                    {deleteError && (
                        <div className={styles.errorMessage}>{deleteError}</div>
                    )}
                    <div className={styles.header}>
                        <div className={styles.headerLeft}>
                            <button
                                className={styles.backButton}
                                onClick={handleBackClick}
                            >
                                ←
                            </button>
                            <div className={styles.titleContainer}>
                                <h2 className={styles.title}>
                                    {item.catalogNumber} - {item.name}
                                </h2>
                            </div>
                        </div>
                        <div className={styles.headerCenter}>
                            <button
                                className={`${styles.editButton} ${
                                    isEditing ? styles.active : ""
                                }`}
                                onClick={() => setIsEditing(!isEditing)}
                            >
                                ✎
                            </button>
                            <button
                                className={styles.deleteButton}
                                onClick={handleDeleteClick}
                                disabled={isDeleting}
                            >
                                🗑️
                            </button>
                        </div>
                        <div className={styles.headerRight}>
                            <div className={styles.saveWrapper}>
                                <button
                                    className={`${styles.saveButton} ${
                                        isDirty ? styles.modified : ""
                                    }`}
                                    disabled={!isEditing || !isDirty}
                                >
                                    {isDirty ? (
                                        "Save"
                                    ) : (
                                        <span className={styles.savedIndicator}>
                                            ✓ Saved
                                        </span>
                                    )}
                                </button>
                            </div>
                        </div>
                    </div>

                    <div className={styles.content}>
                        <section className={styles.section}>
                            <h3 className={styles.sectionTitle}>Item</h3>
                            <div className={styles.itemDetails}>
                                <div className={styles.detailRow}>
                                    <span className={styles.label}>No</span>
                                    <input
                                        type="text"
                                        className={styles.input}
                                        value={editedItem.catalogNumber}
                                        onChange={(e) =>
                                            handleInputChange(
                                                "catalogNumber",
                                                e.target.value
                                            )
                                        }
                                        disabled={!isEditing}
                                    />
                                </div>
                                <div className={styles.detailRow}>
                                    <span className={styles.label}>Name</span>
                                    <input
                                        type="text"
                                        className={styles.input}
                                        value={editedItem.name}
                                        onChange={(e) =>
                                            handleInputChange(
                                                "name",
                                                e.target.value
                                            )
                                        }
                                        disabled={!isEditing}
                                    />
                                </div>
                                <div className={styles.detailRow}>
                                    <span className={styles.label}>
                                        Description
                                    </span>
                                    <input
                                        type="text"
                                        className={styles.input}
                                        value={editedItem.description}
                                        onChange={(e) =>
                                            handleInputChange(
                                                "description",
                                                e.target.value
                                            )
                                        }
                                        disabled={!isEditing}
                                    />
                                </div>
                            </div>
                        </section>

                        <section className={styles.section}>
                            <h3 className={styles.sectionTitle}>Warehouse</h3>
                            {loading ? (
                                <div className={styles.loading}>Loading...</div>
                            ) : error ? (
                                <div className={styles.error}>{error}</div>
                            ) : (
                                <div className={styles.warehouseList}>
                                    <div className={styles.warehouseHeader}>
                                        <span>Warehouse</span>
                                        <span>Quantity</span>
                                    </div>
                                    {inventoryDetails.map((detail) => (
                                        <div
                                            key={detail.id}
                                            className={styles.warehouseRow}
                                        >
                                            <span
                                                className={styles.warehouseName}
                                            >
                                                {detail.warehouseName}
                                            </span>
                                            <span className={styles.quantity}>
                                                {detail.quantity}
                                            </span>
                                        </div>
                                    ))}
                                </div>
                            )}
                        </section>
                    </div>
                </div>
            </div>

            <ConfirmDialog
                isOpen={showConfirmDialog}
                onConfirm={handleConfirmBack}
                onCancel={() => setShowConfirmDialog(false)}
                title="Unsaved changes"
                message="You have unsaved changes. Are you sure you want to discard them?"
                confirmText="Discard changes"
                cancelText="Keep editing"
            />

            <ConfirmDialog
                isOpen={showDeleteDialog}
                onConfirm={handleConfirmDelete}
                onCancel={() => setShowDeleteDialog(false)}
                title="Delete Item"
                message={`Are you sure you want to delete item "${item.name}" (${item.catalogNumber})?`}
                confirmText={isDeleting ? "Deleting..." : "Delete"}
                cancelText="Cancel"
            />
        </>
    );
};
