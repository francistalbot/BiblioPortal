// src/services/authService.js

import axios from "axios";

const API_URL = "http://localhost:5147"; 

// Set up Axios instance
const axiosInstance = axios.create({
    withCredentials: true,
    baseURL: API_URL,
    headers: { "Content-Type": "application/json" },
});

// Add a request interceptor to attach the token to every request
axiosInstance.interceptors.request.use(
    (config) => {
        const token = localStorage.getItem("token");
        console.log(token);
        if (token) {
            config.headers["Authorization"] = `Bearer ${token}`; // Attach token to headers
        }
        return config;
    },
    (error) => Promise.reject(error)
);

//POST Register user
interface RegisterData {
    email: string;
    password: string;
}
const register = async (registerData: RegisterData) => {
    const response = await axiosInstance.post("/register", registerData, {
        headers: {
            "Content-Type": "multipart/form-data", // Override the Content-Type header
        },
    });
    return response.data;
};

//POST Login user
interface LoginData {
    email: string;
    password: string;
    twoFactorCode: string;
    twoFactorRecoveryCode: string;
}
const login = async (loginData: LoginData ) => {
    const response = await axiosInstance.post("/login", loginData);
    return response.data;
};

//POST refresh
interface RefreshData {
    refreshToken: string;
}
const refresh = async (refreshData: RefreshData) => {
    const response = await axiosInstance.post("/refresh", refreshData);
    return response.data;
};

//GET confirmEmail
interface ConfirmEmailParams {
    userId: string;
    code: string;
    changedEmail: string;
}
const confirmEmail = async (confirmEmailParams: ConfirmEmailParams) => {
    const response = await axiosInstance.get("/confirmEmail", { params: confirmEmailParams });
    return response.data;
};

//POST resend a Confirmation Email
interface ResendConfEmailData {
    email: string;
}
const resendConfirmationEmail = async (resendConfEmailData: ResendConfEmailData) => {
    const response = await axiosInstance.post("/resendConfirmationEmail", resendConfEmailData);
    return response.data;
};

//POST forgot Password
interface ForgotPassData {
    email: string;
}
const forgotPassword = async (forgotPassData: ForgotPassData) => {
    const response = await axiosInstance.post("/forgotPassword", forgotPassData);
    return response.data;
};

//POST Reset Password
interface ResetPasswordData {
    email: string;
    resetCode: string,
    newPassword: string
}
const resetPassword = async (resetPasswordData: ResetPasswordData) => {
    const response = await axiosInstance.post("/resetPassword", resetPasswordData);
    return response.data;
};

//GET manage info
const getManageInfo = async () => {
    const response = await axiosInstance.get("/manage/info");
    return response.data;
};
//POST manage 2fa
interface Manage2faData {
    enable: boolean,
    twoFactorCode: string,
    resetSharedKey: boolean,
    resetRecoveryCodes: boolean,
    forgetMachine: boolean
}
const manage2fa = async (manage2faData: Manage2faData) => {
    const response = await axiosInstance.post("/manage/2fa", manage2faData);
    return response.data;
};
//POST manage info
interface PostManageInfoData {
    newEmail: string,
    newPassword: string,
    oldPassword: string
}
const postManageInfo = async (postManageInfoData: PostManageInfoData) => {
    const response = await axiosInstance.post("/manage/info", postManageInfoData);
    return response.data;
};
export {
    register, login, refresh, confirmEmail,
    resendConfirmationEmail, forgotPassword, resetPassword,
    manage2fa, getManageInfo, postManageInfo,
};