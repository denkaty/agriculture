import styles from "./StatCard.module.css";

interface StatCardProps {
    number: number;
    label: string;
}

export const StatCard = ({ number, label }: StatCardProps) => {
    return (
        <div className={styles.statBox}>
            <div className={styles.content}>
                <span className={styles.statLabel}>{label}</span>
                <span className={styles.statNumber}>{number}</span>
                <div className={styles.divider}></div>
            </div>
        </div>
    );
};
