import { useState } from "react";
import styles from "./CreateItemModal.module.css";
import { Item } from "../../types/items.types";

interface CreateItemModalProps {
    onClose: () => void;
    onSubmit: (itemData: Partial<Item>) => Promise<void>;
}

interface ValidationErrors {
    catalogNumber?: string;
    name?: string;
}

export const CreateItemModal = ({
    onClose,
    onSubmit,
}: CreateItemModalProps) => {
    const [formData, setFormData] = useState({
        catalogNumber: "",
        name: "",
        description: "",
    });
    const [error, setError] = useState<string | null>(null);
    const [validationErrors, setValidationErrors] = useState<ValidationErrors>(
        {}
    );

    const validateForm = (): boolean => {
        const errors: ValidationErrors = {};

        if (!formData.catalogNumber.trim()) {
            errors.catalogNumber = "Catalog Number is required";
        }

        if (!formData.name.trim()) {
            errors.name = "Name is required";
        }

        setValidationErrors(errors);
        return Object.keys(errors).length === 0;
    };

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();
        setError(null);

        if (!validateForm()) {
            return;
        }

        try {
            await onSubmit(formData);
            onClose();
        } catch (err) {
            setError(
                err instanceof Error ? err.message : "Failed to create item"
            );
        }
    };

    return (
        <div className={styles.modalOverlay}>
            <div className={styles.modal}>
                <div className={styles.header}>
                    <div className={styles.headerLeft}>
                        <button className={styles.backButton} onClick={onClose}>
                            ←
                        </button>
                        <h2 className={styles.title}>Create New Item</h2>
                    </div>
                </div>
                <form
                    onSubmit={handleSubmit}
                    autoComplete="off"
                    spellCheck="false"
                    noValidate
                    className={styles.formContainer}
                >
                    {error && (
                        <div className={styles.errorMessage}>{error}</div>
                    )}
                    <div className={styles.formGroup}>
                        <label className={styles.label}>Catalog Number</label>
                        <input
                            id="catalogNumber"
                            type="text"
                            value={formData.catalogNumber}
                            onChange={(e) => {
                                setFormData((prev) => ({
                                    ...prev,
                                    catalogNumber: e.target.value,
                                }));
                                if (validationErrors.catalogNumber) {
                                    setValidationErrors((prev) => ({
                                        ...prev,
                                        catalogNumber: undefined,
                                    }));
                                }
                            }}
                            required
                            autoComplete="new-password"
                            className={styles.input}
                        />
                        {validationErrors.catalogNumber && (
                            <span className={styles.error}>
                                {validationErrors.catalogNumber}
                            </span>
                        )}
                    </div>
                    <div className={styles.formGroup}>
                        <label className={styles.label}>Name</label>
                        <input
                            id="name"
                            type="text"
                            value={formData.name}
                            onChange={(e) => {
                                setFormData((prev) => ({
                                    ...prev,
                                    name: e.target.value,
                                }));
                                if (validationErrors.name) {
                                    setValidationErrors((prev) => ({
                                        ...prev,
                                        name: undefined,
                                    }));
                                }
                            }}
                            required
                            autoComplete="new-password"
                            className={styles.input}
                        />
                        {validationErrors.name && (
                            <span className={styles.error}>
                                {validationErrors.name}
                            </span>
                        )}
                    </div>
                    <div className={styles.formGroup}>
                        <label className={styles.label}>Description</label>
                        <textarea
                            id="description"
                            value={formData.description}
                            onChange={(e) =>
                                setFormData((prev) => ({
                                    ...prev,
                                    description: e.target.value,
                                }))
                            }
                            autoComplete="new-password"
                            className={styles.input}
                        />
                    </div>
                    <div className={styles.actions}>
                        <button type="button" onClick={onClose}>
                            Cancel
                        </button>
                        <button type="submit">Create</button>
                    </div>
                </form>
            </div>
        </div>
    );
};
