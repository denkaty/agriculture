import { useEffect, useState } from "react";
import { suppliersService } from "../../services/suppliers.service";
import { Supplier } from "../../types/suppliers.types";
import { Spinner } from "../../../../shared/components/Spinner/Spinner";
import { SuppliersTable } from "../../components/SuppliersTable/SuppliersTable";
import { ItemsListPagination } from "../../../inventory/components/ItemsListPagination/ItemsListPagination";
import styles from "./Suppliers.module.css";

export const Suppliers = () => {
    const [suppliers, setSuppliers] = useState<Supplier[]>([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState<string | null>(null);
    const [selectedSupplierId, setSelectedSupplierId] = useState<string | null>(
        null
    );
    const [pagination, setPagination] = useState({
        page: 1,
        pageSize: 10,
        totalCount: 0,
        hasNextPage: false,
        hasPreviousPage: false,
    });

    useEffect(() => {
        const fetchSuppliers = async () => {
            try {
                const response = await suppliersService.getSuppliers(
                    pagination.page,
                    pagination.pageSize
                );
                setSuppliers(response.data);
                setPagination({
                    ...pagination,
                    totalCount: response.totalCount,
                    hasNextPage: response.hasNextPage,
                    hasPreviousPage: response.hasPreviousPage,
                });
            } catch (err) {
                setError("Failed to fetch suppliers. Please try again later.");
            } finally {
                setLoading(false);
            }
        };

        fetchSuppliers();
    }, [pagination.page]);

    const handleRowClick = async (supplier: Supplier) => {
        setSelectedSupplierId(supplier.id);
    };

    return (
        <div className={styles.container}>
            {loading ? (
                <Spinner variant="inline" />
            ) : error ? (
                <div className={styles.error}>{error}</div>
            ) : (
                <div className={styles.content}>
                    <div className={styles.mainContent}>
                        <div className={styles.tableWrapper}>
                            <SuppliersTable
                                suppliers={suppliers}
                                selectedSupplierId={selectedSupplierId}
                                onRowClick={handleRowClick}
                            />
                        </div>
                        <ItemsListPagination
                            currentPage={pagination.page}
                            totalCount={pagination.totalCount}
                            pageSize={pagination.pageSize}
                            hasNextPage={pagination.hasNextPage}
                            hasPreviousPage={pagination.hasPreviousPage}
                            onPageChange={(page) =>
                                setPagination((prev) => ({ ...prev, page }))
                            }
                        />
                    </div>
                </div>
            )}
        </div>
    );
};
