import styles from "./Spinner.module.css";

interface SpinnerProps {
    variant?: "fullscreen" | "inline";
}

export const Spinner = ({ variant = "inline" }: SpinnerProps) => {
    return (
        <div
            className={
                variant === "fullscreen"
                    ? styles.fullscreenWrapper
                    : styles.inlineWrapper
            }
        >
            <div className={styles.spinner}></div>
        </div>
    );
};
