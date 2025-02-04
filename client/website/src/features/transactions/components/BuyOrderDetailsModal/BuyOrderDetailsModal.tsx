import { useState, useEffect } from "react";
import {
    BuyOrder,
    BuyOrderDetail,
    ItemDetail,
} from "../../types/buyOrders.types";
import { buyOrdersService } from "../../services/buyOrders.service";
import styles from "./BuyOrderDetailsModal.module.css";
import { ConfirmDialog } from "../../../../shared/components/ConfirmDialog/ConfirmDialog";
import { Spinner } from "../../../../shared/components/Spinner/Spinner";

interface BuyOrderDetailsModalProps {
    buyOrder: BuyOrder;
    onClose: () => void;
}

export const BuyOrderDetailsModal = ({
    buyOrder,
    onClose,
}: BuyOrderDetailsModalProps) => {
    const [isEditing, setIsEditing] = useState(true);
    const [editedBuyOrder, setEditedBuyOrder] = useState(buyOrder);
    const [isDirty, setIsDirty] = useState(false);
    const [showConfirmDialog, setShowConfirmDialog] = useState(false);
    const [loading, setLoading] = useState(true);
    const [orderDetails, setOrderDetails] = useState<BuyOrderDetail | null>(
        null
    );
    const [itemDetails, setItemDetails] = useState<ItemDetail[]>([]);

    useEffect(() => {
        const fetchOrderDetails = async () => {
            try {
                setLoading(true);
                // Fetch buy order details
                const details = await buyOrdersService.getBuyOrderById(
                    buyOrder.id
                );
                setOrderDetails(details);

                // Extract item IDs and fetch item details
                const itemIds = details.items.map((item) => item.itemId);
                const items = await buyOrdersService.getItemsByIds(itemIds);
                setItemDetails(items.data);
            } catch (error) {
                console.error("Failed to fetch order details:", error);
            } finally {
                setLoading(false);
            }
        };

        fetchOrderDetails();
    }, [buyOrder.id]);

    const handleInputChange = (field: keyof BuyOrder, value: string) => {
        setEditedBuyOrder((prev) => ({
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

    if (loading) return <Spinner />;

    return (
        <>
            <div className={styles.modalOverlay}>
                <div className={styles.modal}>
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
                                    {buyOrder.supplierName}
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
                            <button className={styles.deleteButton}>🗑️</button>
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
                            <h3 className={styles.sectionTitle}>
                                Buy Order Details
                            </h3>
                            <div className={styles.orderDetails}>
                                <div className={styles.detailRow}>
                                    <span className={styles.label}>
                                        Supplier Name
                                    </span>
                                    <input
                                        type="text"
                                        className={styles.input}
                                        value={editedBuyOrder.supplierName}
                                        onChange={(e) =>
                                            handleInputChange(
                                                "supplierName",
                                                e.target.value
                                            )
                                        }
                                        disabled={!isEditing}
                                    />
                                </div>
                                <div className={styles.detailRow}>
                                    <span className={styles.label}>
                                        Order Date
                                    </span>
                                    <input
                                        type="text"
                                        className={styles.input}
                                        value={editedBuyOrder.orderDate}
                                        onChange={(e) =>
                                            handleInputChange(
                                                "orderDate",
                                                e.target.value
                                            )
                                        }
                                        disabled={!isEditing}
                                    />
                                </div>
                                <div className={styles.detailRow}>
                                    <span className={styles.label}>
                                        Total Amount
                                    </span>
                                    <input
                                        type="number"
                                        className={styles.input}
                                        value={editedBuyOrder.totalAmount}
                                        onChange={(e) =>
                                            handleInputChange(
                                                "totalAmount",
                                                e.target.value
                                            )
                                        }
                                        disabled={!isEditing}
                                    />
                                </div>
                            </div>
                        </section>

                        <section className={styles.section}>
                            <h3 className={styles.sectionTitle}>Order Items</h3>
                            <div className={styles.itemsTable}>
                                <table className={styles.table}>
                                    <thead>
                                        <tr>
                                            <th>Catalog Number</th>
                                            <th>Name</th>
                                            <th>Description</th>
                                            <th>Quantity</th>
                                            <th>Unit Price</th>
                                            <th>Subtotal</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        {orderDetails?.items.map(
                                            (orderItem) => {
                                                const itemDetail =
                                                    itemDetails.find(
                                                        (item) =>
                                                            item.id ===
                                                            orderItem.itemId
                                                    );
                                                return (
                                                    <tr key={orderItem.itemId}>
                                                        <td>
                                                            {
                                                                itemDetail?.catalogNumber
                                                            }
                                                        </td>
                                                        <td>
                                                            {itemDetail?.name}
                                                        </td>
                                                        <td>
                                                            {
                                                                itemDetail?.description
                                                            }
                                                        </td>
                                                        <td>
                                                            {orderItem.quantity}
                                                        </td>
                                                        <td>
                                                            {
                                                                orderItem.unitPrice
                                                            }
                                                        </td>
                                                        <td>
                                                            {orderItem.subTotal}
                                                        </td>
                                                    </tr>
                                                );
                                            }
                                        )}
                                    </tbody>
                                </table>
                            </div>
                        </section>
                    </div>
                </div>
            </div>

            <ConfirmDialog
                isOpen={showConfirmDialog}
                onConfirm={handleConfirmBack}
                onCancel={() => setShowConfirmDialog(false)}
                title="Unsaved changes"
                message="You have unsaved changes. Are you sure you want to leave this page? Your changes will be lost."
            />
        </>
    );
};
