import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { IContract, IContractsState } from "./types";

const initialState: IContractsState = {
  contracts: [],
};

const contractsSlice = createSlice({
  name: "contracts",
  initialState,
  reducers: {
    fetchContractsSuccess(state, action: PayloadAction<IContract[]>) {
      state.contracts = action.payload;
    },
    deleteContractReducer(state, action: PayloadAction<IContract>) {
      state.contracts = state.contracts.filter(
        (contract) => contract.id !== action.payload.id
      );
    },
  },
});

export const {
  fetchContractsSuccess,
  deleteContractReducer,
} = contractsSlice.actions;

export default contractsSlice.reducer;
