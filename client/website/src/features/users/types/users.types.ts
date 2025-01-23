export interface RegisterDto {
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
