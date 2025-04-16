import { useEffect, useState } from "react";
import { clientsService } from "../../services/clients.service";
import { Client } from "../../types/clients.types";
import { Spinner } from "../../../../shared/components/Spinner/Spinner";
import { ClientsTable } from "../../components/ClientsTable/ClientsTable";
import { ItemsListPagination } from "../../../inventory/components/ItemsListPagination/ItemsListPagination";
import styles from "./Clients.module.css";

export const Clients = () => {
    const [clients, setClients] = useState<Client[]>([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState<string | null>(null);
    const [selectedClientId, setSelectedClientId] = useState<string | null>(
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
        const fetchClients = async () => {
            try {
                const response = await clientsService.getClients(
                    pagination.page,
                    pagination.pageSize
                );
                setClients(response.data);
                setPagination({
                    ...pagination,
                    totalCount: response.totalCount,
                    hasNextPage: response.hasNextPage,
                    hasPreviousPage: response.hasPreviousPage,
                });
            } catch (err) {
                setError("Failed to fetch clients. Please try again later.");
            } finally {
                setLoading(false);
            }
        };

        fetchClients();
    }, [pagination.page]);

    const handleRowClick = async (client: Client) => {
        setSelectedClientId(client.id);
    };

    if (loading) return <Spinner variant="inline" />;
    if (error) return <div className={styles.error}>{error}</div>;

    return (
        <div className={styles.container}>
            <div className={styles.content}>
                <div className={styles.mainContent}>
                    <div className={styles.tableWrapper}>
                        <ClientsTable
                            clients={clients}
                            selectedClientId={selectedClientId}
                            onRowClick={handleRowClick}
                        />
                    </div>
                    <div className={styles.paginationWrapper}>
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
            </div>
        </div>
    );
};
