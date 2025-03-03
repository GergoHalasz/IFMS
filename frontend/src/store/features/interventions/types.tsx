interface IGeolocation {
  latitude: number;
  longitude: number;
}

interface ISignature {
  id: number;
  signedBy: string;
  signedAt: Date;
}

export interface IIntervention {
  id: number;
  contractId: number;
  contractNumber: string;
  systemTypeId: number;
  systemTypeName: string;
  clientId: number;
  clientName: string;
  technicianId: number;
  technicianName: string;
  statusId: number;
  statusName: string;
  createdAt: Date;
  completedAt?: Date | null;
  notes: string;
  geolocation: IGeolocation;
  signatures: ISignature[];
}

export interface IInterventionsState {
  interventions: IIntervention[];
  loading: boolean;
  error: string | null;
}

export const FETCH_INTERVENTIONS_REQUEST = "FETCH_INTERVENTIONS_REQUEST";
export const FETCH_INTERVENTIONS_SUCCESS = "FETCH_INTERVENTIONS_SUCCESS";
export const FETCH_INTERVENTIONS_FAILURE = "FETCH_INTERVENTIONS_FAILURE";
export const DELETE_INTERVENTION = "DELETE_INTERVENTION";

interface FetchCompaniesRequest {
  type: typeof FETCH_INTERVENTIONS_REQUEST;
}

interface FetchCompaniesSuccess {
  type: typeof FETCH_INTERVENTIONS_SUCCESS;
  payload: IIntervention[];
}

interface FetchCompaniesFailure {
  type: typeof FETCH_INTERVENTIONS_FAILURE;
  payload: string;
}

interface DeleteCompany {
  type: typeof DELETE_INTERVENTION;
  payload: IIntervention;
}

export type InterventionsSliceActionTypes =
  | FetchCompaniesRequest
  | FetchCompaniesSuccess
  | FetchCompaniesFailure
  | DeleteCompany;
