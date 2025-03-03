import { configureStore } from "@reduxjs/toolkit";
import interventionsReducer from "./store/features/interventions/reducers";
import contractsReducer from "./store/features/contract/reducers";

export const store = configureStore({
  reducer: {
    interventions: interventionsReducer,
    contracts: contractsReducer,
  },
});

export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;
