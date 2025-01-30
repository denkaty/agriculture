import { createPortal } from "react-dom";
import styles from "./ConfirmDialog.module.css";

interface ConfirmDialogProps {
    isOpen: boolean;
    onConfirm: () => void;
    onCancel: () => void;
    title: string;
    message: string;
}

export const ConfirmDialog = ({
    isOpen,
    onConfirm,
    onCancel,
    title,
    message,
}: ConfirmDialogProps) => {
    if (!isOpen) return null;

    return createPortal(
        <div className={styles.overlay}>
            <div className={styles.dialog} role="dialog" aria-modal="true">
                <h2 className={styles.title}>{title}</h2>
                <p className={styles.message}>{message}</p>
                <div className={styles.actions}>
                    <button
                        className={styles.cancelButton}
                        onClick={onCancel}
                        autoFocus
                    >
                        Keep editing
                    </button>
                    <button
                        className={styles.confirmButton}
                        onClick={onConfirm}
                    >
                        Discard changes
                    </button>
                </div>
            </div>
        </div>,
        document.body
    );
};
