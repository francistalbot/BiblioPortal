// src/redux/store.js
import { configureStore } from '@reduxjs/toolkit';
import userReducer from './userSlice';  // The slice for managing user data

export const store = configureStore({
    reducer: {
        user: userReducer,
    },
});

// D�finition du type RootState
export type RootState = ReturnType<typeof store.getState>;

// D�finition du type AppDispatch
export type AppDispatch = typeof store.dispatch;