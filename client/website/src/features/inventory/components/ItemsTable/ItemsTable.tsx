import { Item } from "../../types/items.types";
import styles from "./ItemsTable.module.css";

interface ItemsTableProps {
    items: Item[];
    selectedItemId: string | null;
    onRowClick: (item: Item) => void;
    onCatalogNumberClick: (item: Item) => void;
}

export const ItemsTable = ({
    items,
    selectedItemId,
    onRowClick,
    onCatalogNumberClick,
}: ItemsTableProps) => {
    const handleCatalogNumberClick = (e: React.MouseEvent, item: Item) => {
        e.stopPropagation();
        onCatalogNumberClick(item);
    };

    return (
        <div className={styles.tableContainer}>
            <table className={styles.table}>
                <thead>
                    <tr>
                        <th className={styles.numberColumn}>№</th>
                        <th>Name</th>
                        <th>Description</th>
                        <th>Created At</th>
                    </tr>
                </thead>
                <tbody>
                    {items.map((item) => (
                        <tr
                            key={item.id}
                            onClick={() => onRowClick(item)}
                            className={`${styles.tableRow} ${
                                selectedItemId === item.id
                                    ? styles.selectedRow
                                    : ""
                            }`}
                        >
                            <td className={styles.numberColumn}>
                                <span
                                    className={styles.catalogNumber}
                                    onClick={(e) =>
                                        handleCatalogNumberClick(e, item)
                                    }
                                >
                                    {item.catalogNumber}
                                </span>
                            </td>
                            <td>{item.name}</td>
                            <td>{item.description}</td>
                            <td>{item.createdAt}</td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>
    );
};
