import { useState } from "react";
import { BuyOrder } from "../../types/buyOrders.types";
import { BuyOrderDetailsModal } from "../BuyOrderDetailsModal/BuyOrderDetailsModal";
import styles from "./BuyOrdersTable.module.css";

interface BuyOrdersTableProps {
    buyOrders: BuyOrder[];
    selectedBuyOrderId: string | null;
    onRowClick: (buyOrder: BuyOrder) => void;
}

export const BuyOrdersTable = ({
    buyOrders,
    selectedBuyOrderId,
    onRowClick,
}: BuyOrdersTableProps) => {
    const [modalBuyOrder, setModalBuyOrder] = useState<BuyOrder | null>(null);

    const handleOrderClick = (e: React.MouseEvent, buyOrder: BuyOrder) => {
        e.stopPropagation();
        setModalBuyOrder(buyOrder);
        onRowClick(buyOrder);
    };

    return (
        <>
            <div className={styles.tableContainer}>
                <table className={styles.table}>
                    <thead>
                        <tr>
                            <th>Supplier Name</th>
                            <th>Order Date</th>
                            <th>Total Amount</th>
                            <th>Created At</th>
                            <th>Updated At</th>
                        </tr>
                    </thead>
                    <tbody>
                        {buyOrders.map((buyOrder) => (
                            <tr
                                key={buyOrder.id}
                                onClick={() => onRowClick(buyOrder)}
                                className={`${styles.tableRow} ${
                                    selectedBuyOrderId === buyOrder.id
                                        ? styles.selectedRow
                                        : ""
                                }`}
                            >
                                <td>
                                    <span
                                        className={styles.orderName}
                                        onClick={(e) =>
                                            handleOrderClick(e, buyOrder)
                                        }
                                    >
                                        {buyOrder.supplierName}
                                    </span>
                                </td>
                                <td>
                                    {new Date(
                                        buyOrder.orderDate
                                    ).toLocaleDateString()}
                                </td>
                                <td>{buyOrder.totalAmount}</td>
                                <td>{buyOrder.createdAt}</td>
                                <td>{buyOrder.updatedAt}</td>
                            </tr>
                        ))}
                    </tbody>
                </table>
            </div>

            {modalBuyOrder && (
                <BuyOrderDetailsModal
                    buyOrder={modalBuyOrder}
                    onClose={() => setModalBuyOrder(null)}
                />
            )}
        </>
    );
};
