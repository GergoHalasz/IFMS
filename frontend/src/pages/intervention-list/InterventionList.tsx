import React, { useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";
import { IIntervention } from "../../store/features/interventions/types";
import { fetchInterventions } from "../../store/features/interventions/actions";
import { AppDispatch, RootState } from "../../configureStore";
import { fetchContracts } from "../../store/features/contract/actions";

const InterventionList: React.FC = () => {
  const dispatch = useDispatch<AppDispatch>();
  const { interventions, loading } = useSelector(
    (state: RootState) => state.interventions
  );

  useEffect(() => {
    dispatch(fetchInterventions());
    dispatch(fetchContracts());
  }, [dispatch]);

  return (
    <div>
      {loading ? (
        <div>Loading...</div>
      ) : (
        <div className="row">
          {interventions.map((intervention: IIntervention) => (
            <div className="col-md-4" key={intervention.id}>
              <div className={`card`}>
                <div className="card-body">
                  <h5 className="card-title">{intervention.contractNumber}</h5>
                  <p className="card-text">
                    <strong>Client: </strong>
                    {intervention.clientName}
                    <br />
                    <strong>Technician: </strong>
                    {intervention.technicianName}
                    <br />
                    <strong>Status: </strong>
                    {intervention.statusName}
                    <br />
                    <strong>Notes: </strong>
                    {intervention.notes}
                    <br />
                    <strong>Created: </strong>
                    {new Date(intervention.createdAt).toLocaleString()}
                  </p>
                  {intervention.geolocation && (
                    <div>
                      <strong>Location: </strong>
                      {intervention.geolocation.latitude},{" "}
                      {intervention.geolocation.longitude}
                    </div>
                  )}
                </div>
              </div>
            </div>
          ))}
        </div>
      )}
    </div>
  );
};

export default InterventionList;
