import { useState } from "react";
import { Client } from "../../types/clients.types";
import { ClientDetailsModal } from "../ClientDetailsModal/ClientDetailsModal";
import styles from "./ClientsTable.module.css";

interface ClientsTableProps {
    clients: Client[];
    selectedClientId: string | null;
    onRowClick: (client: Client) => void;
}

export const ClientsTable = ({
    clients,
    selectedClientId,
    onRowClick,
}: ClientsTableProps) => {
    const [modalClient, setModalClient] = useState<Client | null>(null);

    const handleNameClick = (e: React.MouseEvent, client: Client) => {
        e.stopPropagation();
        setModalClient(client);
        onRowClick(client);
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
                        {clients.map((client) => (
                            <tr
                                key={client.id}
                                onClick={() => onRowClick(client)}
                                className={`${styles.tableRow} ${
                                    selectedClientId === client.id
                                        ? styles.selectedRow
                                        : ""
                                }`}
                            >
                                <td>
                                    <span
                                        className={styles.clientName}
                                        onClick={(e) =>
                                            handleNameClick(e, client)
                                        }
                                    >
                                        {client.name}
                                    </span>
                                </td>
                                <td>{client.address}</td>
                                <td>{client.phoneNumber}</td>
                                <td>{client.contactPerson}</td>
                                <td>{client.createdAt}</td>
                                <td>{client.updatedAt}</td>
                            </tr>
                        ))}
                    </tbody>
                </table>
            </div>

            {modalClient && (
                <ClientDetailsModal
                    client={modalClient}
                    onClose={() => setModalClient(null)}
                />
            )}
        </>
    );
};
