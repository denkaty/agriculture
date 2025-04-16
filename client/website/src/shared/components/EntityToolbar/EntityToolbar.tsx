import { useState } from "react";
import styles from "./EntityToolbar.module.css";

interface EntityToolbarProps {
    entityName: string; // e.g., "Items", "Buy Orders", etc.
    onSearch?: (searchTerm: string) => void;
    onCreateNew?: () => void;
    searchValue?: string;
    isSearchVisible?: boolean;
}

export const EntityToolbar = ({
    entityName,
    onSearch,
    onCreateNew,
    searchValue = "",
    isSearchVisible: initialIsSearchVisible = false,
}: EntityToolbarProps) => {
    const [isSearchVisible, setIsSearchVisible] = useState(
        initialIsSearchVisible
    );

    const handleSearchChange = (value: string) => {
        onSearch?.(value);
    };

    const handleClear = () => {
        onSearch?.("");
    };

    const handleBlur = () => {
        setIsSearchVisible(false);
    };

    const SearchIcon = () => (
        <svg
            className={styles.searchIcon}
            width="16"
            height="16"
            viewBox="0 0 16 16"
            fill="none"
            xmlns="http://www.w3.org/2000/svg"
        >
            <path
                d="M14.6666 14.6666L11.2916 11.2916M12.9166 7.29164C12.9166 10.4033 10.4033 12.9166 7.29164 12.9166C4.18 12.9166 1.66664 10.4033 1.66664 7.29164C1.66664 4.18 4.18 1.66664 7.29164 1.66664C10.4033 1.66664 12.9166 4.18 12.9166 7.29164Z"
                stroke="currentColor"
                strokeWidth="1.5"
                strokeLinecap="round"
                strokeLinejoin="round"
            />
        </svg>
    );

    const PlusIcon = () => (
        <svg
            className={styles.plusIcon}
            width="14"
            height="14"
            viewBox="0 0 14 14"
            fill="none"
            xmlns="http://www.w3.org/2000/svg"
        >
            <path
                d="M7 1V13M1 7H13"
                stroke="currentColor"
                strokeWidth="1.5"
                strokeLinecap="round"
                strokeLinejoin="round"
            />
        </svg>
    );

    return (
        <div className={styles.toolbar}>
            <div className={styles.toolbarLeft}>
                <span className={styles.entityLabel}>{entityName}</span>
                <div className={styles.searchContainer}>
                    {isSearchVisible ? (
                        <div className={styles.searchWrapper}>
                            <SearchIcon />
                            <input
                                type="text"
                                className={styles.searchInput}
                                placeholder="Search"
                                value={searchValue}
                                onChange={(e) =>
                                    handleSearchChange(e.target.value)
                                }
                                onBlur={handleBlur}
                                autoFocus
                            />
                            {searchValue && (
                                <button
                                    className={styles.clearButton}
                                    onClick={handleClear}
                                    onMouseDown={(e) => e.preventDefault()}
                                >
                                    ×
                                </button>
                            )}
                        </div>
                    ) : (
                        <button
                            className={styles.searchButton}
                            onClick={() => setIsSearchVisible(true)}
                        >
                            <SearchIcon />
                        </button>
                    )}
                </div>
                <button className={styles.createButton} onClick={onCreateNew}>
                    <PlusIcon />
                    <span>Създаване</span>
                </button>
            </div>
        </div>
    );
};
