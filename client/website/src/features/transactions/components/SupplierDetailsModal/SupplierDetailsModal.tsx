import { useState } from "react";
import { Supplier } from "../../types/suppliers.types";
import styles from "./SupplierDetailsModal.module.css";
import { ConfirmDialog } from "../../../../shared/components/ConfirmDialog/ConfirmDialog";

interface SupplierDetailsModalProps {
    supplier: Supplier;
    onClose: () => void;
}

export const SupplierDetailsModal = ({
    supplier,
    onClose,
}: SupplierDetailsModalProps) => {
    const [isEditing, setIsEditing] = useState(true);
    const [editedSupplier, setEditedSupplier] = useState(supplier);
    const [isDirty, setIsDirty] = useState(false);
    const [showConfirmDialog, setShowConfirmDialog] = useState(false);

    const handleInputChange = (field: keyof Supplier, value: string) => {
        setEditedSupplier((prev) => ({
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
                                    {supplier.name}
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
                            <h3 className={styles.sectionTitle}>Supplier</h3>
                            <div className={styles.supplierDetails}>
                                <div className={styles.detailRow}>
                                    <span className={styles.label}>Name</span>
                                    <input
                                        type="text"
                                        className={styles.input}
                                        value={editedSupplier.name}
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
                                        Address
                                    </span>
                                    <input
                                        type="text"
                                        className={styles.input}
                                        value={editedSupplier.address}
                                        onChange={(e) =>
                                            handleInputChange(
                                                "address",
                                                e.target.value
                                            )
                                        }
                                        disabled={!isEditing}
                                    />
                                </div>
                                <div className={styles.detailRow}>
                                    <span className={styles.label}>Phone</span>
                                    <input
                                        type="text"
                                        className={styles.input}
                                        value={editedSupplier.phoneNumber}
                                        onChange={(e) =>
                                            handleInputChange(
                                                "phoneNumber",
                                                e.target.value
                                            )
                                        }
                                        disabled={!isEditing}
                                    />
                                </div>
                                <div className={styles.detailRow}>
                                    <span className={styles.label}>
                                        Contact
                                    </span>
                                    <input
                                        type="text"
                                        className={styles.input}
                                        value={editedSupplier.contactPerson}
                                        onChange={(e) =>
                                            handleInputChange(
                                                "contactPerson",
                                                e.target.value
                                            )
                                        }
                                        disabled={!isEditing}
                                    />
                                </div>
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
