// src/redux/store.js
import { configureStore } from '@reduxjs/toolkit';
import userReducer from './userSlice';  // The slice for managing user data

export const store = configureStore({
    reducer: {
        user: userReducer,
    },
});
