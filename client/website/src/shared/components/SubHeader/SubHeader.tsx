import { useState } from "react";
import { Link } from "react-router-dom";
import styles from "./SubHeader.module.css";

interface MenuItem {
    label: string;
    path?: string;
    children?: MenuItem[];
}

const menuItems: MenuItem[] = [
    {
        label: "Agrotehniki & Ko LTD",
        path: "/",
    },
    {
        label: "Inventory",
        children: [
            { label: "Items", path: "/items" },
            { label: "Warehouses", path: "/warehouses" },
        ],
    },
    {
        label: "Sales",
        children: [
            { label: "Orders", path: "/sales/sale-orders" },
            { label: "Invoices", path: "/sales/sale-invoices" },
        ],
    },
    {
        label: "Purchases",
        children: [
            { label: "Orders", path: "/purchases/buy-orders" },
            { label: "Invoices", path: "/purchases/buy-invoices" },
        ],
    },
    {
        label: "Clients",
        path: "/clients",
    },
    {
        label: "Suppliers",
        path: "/suppliers",
    },
];

export const SubHeader = () => {
    const [activeDropdown, setActiveDropdown] = useState<number | null>(null);

    const handleMouseEnter = (index: number) => {
        setActiveDropdown(index);
    };

    const handleMouseLeave = () => {
        setActiveDropdown(null);
    };

    return (
        <nav className={styles.subHeader}>
            <div className={styles.menuContainer}>
                {menuItems.map((item, index) => (
                    <div
                        key={index}
                        className={styles.menuItem}
                        onMouseEnter={() => handleMouseEnter(index)}
                        onMouseLeave={handleMouseLeave}
                    >
                        {item.path ? (
                            <Link to={item.path} className={styles.menuLink}>
                                {item.label}
                                {item.children && (
                                    <span className={styles.arrow}>▼</span>
                                )}
                            </Link>
                        ) : (
                            <span className={styles.menuLink}>
                                {item.label}
                                {item.children && (
                                    <span className={styles.arrow}>▼</span>
                                )}
                            </span>
                        )}
                        {item.children && activeDropdown === index && (
                            <div className={styles.dropdown}>
                                {item.children.map((child, childIndex) => (
                                    <Link
                                        key={childIndex}
                                        to={child.path || "#"}
                                        className={styles.dropdownItem}
                                    >
                                        {child.label}
                                    </Link>
                                ))}
                            </div>
                        )}
                    </div>
                ))}
            </div>
        </nav>
    );
};
