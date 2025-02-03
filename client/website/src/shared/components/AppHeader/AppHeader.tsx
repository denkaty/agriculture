import { useState } from "react";
import { useAuth } from "../../../features/users/context/AuthContext";
import { useNavigate } from "react-router-dom";
import styles from "./AppHeader.module.css";

export const AppHeader = () => {
    const [isDropdownOpen, setIsDropdownOpen] = useState(false);
    const { logout } = useAuth();
    const navigate = useNavigate();

    const handleLogout = () => {
        logout();
        navigate("/login");
    };

    const handleEditProfile = () => {
        navigate("/profile");
        setIsDropdownOpen(false);
    };

    return (
        <header className={styles.header}>
            <span className={styles.logoText}>AgriTech Solutions</span>

            <div className={styles.userMenu}>
                <button
                    className={styles.userButton}
                    onClick={() => setIsDropdownOpen(!isDropdownOpen)}
                >
                    <div className={styles.userIcon}>
                        <svg
                            viewBox="0 0 24 24"
                            fill="currentColor"
                            width="24"
                            height="24"
                        >
                            <path d="M12 2C6.48 2 2 6.48 2 12s4.48 10 10 10 10-4.48 10-10S17.52 2 12 2zm0 3c1.66 0 3 1.34 3 3s-1.34 3-3 3-3-1.34-3-3 1.34-3 3-3zm0 14.2c-2.5 0-4.71-1.28-6-3.22.03-1.99 4-3.08 6-3.08 1.99 0 5.97 1.09 6 3.08-1.29 1.94-3.5 3.22-6 3.22z" />
                        </svg>
                    </div>
                    <span className={styles.arrow}>
                        {isDropdownOpen ? "▲" : "▼"}
                    </span>
                </button>

                {isDropdownOpen && (
                    <div className={styles.dropdown}>
                        <button
                            className={styles.dropdownItem}
                            onClick={handleEditProfile}
                        >
                            Edit Profile
                        </button>
                        <button
                            className={styles.dropdownItem}
                            onClick={handleLogout}
                        >
                            Logout
                        </button>
                    </div>
                )}
            </div>
        </header>
    );
};
