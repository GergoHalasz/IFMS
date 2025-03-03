export interface IContract {
  id: number;
  contractNumber: string;
  startDate: Date;
  endDate: Date;
}

export interface IContractsState {
  contracts: IContract[];
}

export const FETCH_CONTRACTS_SUCCESS = "FETCH_CONTRACTS_SUCCESS";

export const DELETE_CONTRACT = "DELETE_CONTRACT";

interface DeleteContract {
  type: typeof DELETE_CONTRACT;
  payload: IContract;
}

interface FetchCompaniesSuccess {
  type: typeof FETCH_CONTRACTS_SUCCESS;
  payload: IContract[];
}

export type ContractsSliceActionTypes = FetchCompaniesSuccess | DeleteContract;
