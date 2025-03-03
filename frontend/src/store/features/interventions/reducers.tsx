import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { IIntervention, IInterventionsState } from "./types";

const initialState: IInterventionsState = {
  interventions: [],
  loading: false,
  error: null,
};

const interventionsSlice = createSlice({
  name: "interventions",
  initialState,
  reducers: {
    fetchInterventionsRequest(state) {
      state.loading = true;
      state.error = null;
    },
    fetchInterventionsSuccess(state, action: PayloadAction<IIntervention[]>) {
      state.loading = false;
      state.interventions = action.payload;
    },
    fetchInterventionsFailure(state, action: PayloadAction<string>) {
      state.loading = false;
      state.error = action.payload;
    },
    deleteInterventionReducer(state, action: PayloadAction<IIntervention>) {
      state.interventions = state.interventions.filter(
        (intervention) => intervention.id !== action.payload.id
      );
    },
  },
});

export const {
  fetchInterventionsRequest,
  fetchInterventionsSuccess,
  fetchInterventionsFailure,
  deleteInterventionReducer,
} = interventionsSlice.actions;

export default interventionsSlice.reducer;
