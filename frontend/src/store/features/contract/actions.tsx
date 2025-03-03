import { Dispatch } from "redux";
import {
  fetchContractsSuccess,
  deleteContractReducer,
} from "./reducers";
import api from "../../axios";
import { IContract } from "./types";

export const fetchContracts = () => {
  return async (dispatch: Dispatch) => {
      const response = await api.get<IContract[]>("/api/contract"); 
      dispatch(fetchContractsSuccess(response.data));
  };
};

export const deleteContract = (contract: IContract) => {
  return (dispatch: Dispatch) => {
    dispatch(deleteContractReducer(contract)); 
  };
};
