// src/services/authService.js

import axios from "axios";

const API_URL = "https://localhost:7168"; // Replace with your backend URL

const axiosInstance = axios.create({
    withCredentials: true,
    baseURL: API_URL,
    headers: { "Content-Type": "application/json" },
});

interface UserData {
    email: string;
    password: string;
    twoFactorCode: string;
    twoFactorRecoveryCode: string;

}
// Login user
const login = async (userData: UserData ) => {
     const response = await axiosInstance.post("/login", userData);
    return response.data;
};

export { login };