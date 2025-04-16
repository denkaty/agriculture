import styles from "./ItemsListPagination.module.css";

interface ItemsListPaginationProps {
    currentPage: number;
    totalCount: number;
    pageSize: number;
    hasNextPage: boolean;
    hasPreviousPage: boolean;
    onPageChange: (page: number) => void;
}

export const ItemsListPagination = ({
    currentPage,
    totalCount,
    pageSize,
    hasNextPage,
    hasPreviousPage,
    onPageChange,
}: ItemsListPaginationProps) => {
    return (
        <div className={styles.pagination}>
            <button
                className={styles.pageButton}
                disabled={!hasPreviousPage}
                onClick={() => onPageChange(currentPage - 1)}
            >
                Previous
            </button>
            <span className={styles.pageInfo}>
                Page {currentPage} of {Math.ceil(totalCount / pageSize)}
            </span>
            <button
                className={styles.pageButton}
                disabled={!hasNextPage}
                onClick={() => onPageChange(currentPage + 1)}
            >
                Next
            </button>
        </div>
    );
};
