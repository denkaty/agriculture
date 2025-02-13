import { createPortal } from "react-dom";
import styles from "./ConfirmDialog.module.css";

interface ConfirmDialogProps {
    isOpen: boolean;
    onConfirm: () => void;
    onCancel: () => void;
    title: string;
    message: string;
    confirmText?: string;
    cancelText?: string;
}

export const ConfirmDialog = ({
    isOpen,
    onConfirm,
    onCancel,
    title,
    message,
    confirmText = "Discard changes",
    cancelText = "Keep editing",
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
                        {cancelText}
                    </button>
                    <button
                        className={styles.confirmButton}
                        onClick={onConfirm}
                    >
                        {confirmText}
                    </button>
                </div>
            </div>
        </div>,
        document.body
    );
};
