import { Dispatch } from "redux";
import {
  fetchInterventionsRequest,
  fetchInterventionsSuccess,
  fetchInterventionsFailure,
  deleteInterventionReducer,
} from "./reducers";
import api from "../../axios";
import { IIntervention } from "./types";

export const fetchInterventions = () => {
  return async (dispatch: Dispatch) => {
    dispatch(fetchInterventionsRequest()); 

    try {
      const response = await api.get<IIntervention[]>("/api/intervention"); 
      dispatch(fetchInterventionsSuccess(response.data)); 
    } catch (error: any) {
      dispatch(
        fetchInterventionsFailure(error.message || "Something went wrong")
      ); 
    }
  };
};

export const deleteIntervention = (intervention: IIntervention) => {
  return (dispatch: Dispatch) => {
    dispatch(deleteInterventionReducer(intervention));
  };
};
