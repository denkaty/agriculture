import { useState } from "react";
import { Supplier } from "../../types/suppliers.types";
import { SupplierDetailsModal } from "../SupplierDetailsModal/SupplierDetailsModal";
import styles from "./SuppliersTable.module.css";

interface SuppliersTableProps {
    suppliers: Supplier[];
    selectedSupplierId: string | null;
    onRowClick: (supplier: Supplier) => void;
}

export const SuppliersTable = ({
    suppliers,
    selectedSupplierId,
    onRowClick,
}: SuppliersTableProps) => {
    const [modalSupplier, setModalSupplier] = useState<Supplier | null>(null);

    const handleNameClick = (e: React.MouseEvent, supplier: Supplier) => {
        e.stopPropagation();
        setModalSupplier(supplier);
        onRowClick(supplier);
    };

    return (
        <>
            <div className={styles.tableContainer}>
                <table className={styles.table}>
                    <thead>
                        <tr>
                            <th>Name</th>
                            <th>Address</th>
                            <th>Phone Number</th>
                            <th>Contact Person</th>
                            <th>Created At</th>
                            <th>Updated At</th>
                        </tr>
                    </thead>
                    <tbody>
                        {suppliers.map((supplier) => (
                            <tr
                                key={supplier.id}
                                onClick={() => onRowClick(supplier)}
                                className={`${styles.tableRow} ${
                                    selectedSupplierId === supplier.id
                                        ? styles.selectedRow
                                        : ""
                                }`}
                            >
                                <td>
                                    <span
                                        className={styles.supplierName}
                                        onClick={(e) =>
                                            handleNameClick(e, supplier)
                                        }
                                    >
                                        {supplier.name}
                                    </span>
                                </td>
                                <td>{supplier.address}</td>
                                <td>{supplier.phoneNumber}</td>
                                <td>{supplier.contactPerson}</td>
                                <td>{supplier.createdAt}</td>
                                <td>{supplier.updatedAt}</td>
                            </tr>
                        ))}
                    </tbody>
                </table>
            </div>

            {modalSupplier && (
                <SupplierDetailsModal
                    supplier={modalSupplier}
                    onClose={() => setModalSupplier(null)}
                />
            )}
        </>
    );
};
