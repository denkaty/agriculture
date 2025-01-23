export interface RegisterRequest {
    email: string;
    password: string;
    confirmPassword: string;
    phoneNumber: string;
    firstName: string;
    lastName: string;
}

export interface RegisterResponse {
    id: string;
}

export interface LoginRequest {
    email: string;
    password: string;
}

export interface LoginResponse {
    value: string;
    validUntil: string;
}
