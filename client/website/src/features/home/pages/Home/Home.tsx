import { StatCard } from "../../components/StatCard/StatCard";
import styles from "./Home.module.css";

export const Home = () => {
    return (
        <div className={styles.container}>
            <div className={styles.titleSection}>
                <div className={styles.welcomeSection}>
                    <h1 className={styles.welcomeTitle}>
                        Welcome to AgriTech Solutions
                    </h1>
                    <div className={styles.subtitle}>
                        Streamline Your Agricultural Inventory Management
                    </div>
                </div>
                <div className={styles.activities}>
                    <h2 className={styles.activitiesTitle}>Activities</h2>
                    <div className={styles.activityColumns}>
                        <div className={styles.activityColumn}>
                            <h3 className={styles.columnTitle}>Sales</h3>
                            <div className={styles.activityGroup}>
                                <a href="#" className={styles.activityLink}>
                                    + Sales Order
                                </a>
                                <a href="#" className={styles.activityLink}>
                                    + Sales Invoice
                                </a>
                            </div>
                        </div>
                        <div className={styles.activityColumn}>
                            <h3 className={styles.columnTitle}>Purchases</h3>
                            <div className={styles.activityGroup}>
                                <a href="#" className={styles.activityLink}>
                                    + Purchase Order
                                </a>
                                <a href="#" className={styles.activityLink}>
                                    + Purchase Invoice
                                </a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div className={styles.divider}></div>

            <div className={styles.monthlyStats}>
                <h2 className={styles.statsTitle}>Monthly Sales</h2>
                <div className={styles.amount}>121,520 BGN</div>
                <div className={styles.smallDivider}></div>
            </div>

            <div className={styles.statsGrid}>
                <div className={styles.statsSection}>
                    <h3 className={styles.sectionTitle}>Current Sales</h3>
                    <div className={styles.boxes}>
                        <StatCard number={34} label="Sales Orders" />
                        <StatCard number={144} label="Orders" />
                    </div>
                </div>

                <div className={styles.statsSection}>
                    <h3 className={styles.sectionTitle}>Current Purchases</h3>
                    <div className={styles.boxes}>
                        <StatCard number={30} label="Purchase Orders" />
                    </div>
                </div>

                <div className={styles.statsSection}>
                    <h3 className={styles.sectionTitle}>Transfers</h3>
                    <div className={styles.boxes}>
                        <StatCard number={7} label="Not Shipped" />
                        <StatCard number={1} label="Shipped" />
                    </div>
                </div>
            </div>
        </div>
    );
};
