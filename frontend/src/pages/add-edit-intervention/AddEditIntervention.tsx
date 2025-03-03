import React, { useState } from "react";
import { useSelector } from "react-redux";
import { RootState } from "../../configureStore";
import { IContract } from "../../store/features/contract/types";

const AddEditIntervention: React.FC = () => {
  const { contracts } = useSelector((state: RootState) => state.contracts);

  const [contractNumber, setContractNumber] = useState("");
  const [clientName, setClientName] = useState("");
  const [technicianName, setTechnicianName] = useState("");

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
  };

  return (
    <div className="container">
      <h1 className="text-center mb-4">Add/Edit Intervention</h1>
      <div className="row justify-content-center">
        <div className="col-sm-12 col-md-8 col-lg-6">
          <form onSubmit={handleSubmit}>
            <div className="form-group">
              <label>Contract Number</label>
              <select
                className="form-control"
                value={contractNumber}
                onChange={(e) => setContractNumber(e.target.value)}
              >
                <option value="">Select a contract</option>
                {contracts?.map((contract: IContract) => (
                  <option key={contract.id} value={contract.contractNumber}>
                    {contract.contractNumber}
                  </option>
                ))}
              </select>
            </div>

            <div className="form-group">
              <label>Client Name</label>
              <input
                type="text"
                className="form-control"
                value={clientName}
                onChange={(e) => setClientName(e.target.value)}
              />
            </div>

            <div className="form-group">
              <label>Technician Name</label>
              <input
                type="text"
                className="form-control"
                value={technicianName}
                onChange={(e) => setTechnicianName(e.target.value)}
              />
            </div>

            <button type="submit" className="btn btn-primary mt-2">
              Save
            </button>
          </form>
        </div>
      </div>
    </div>
  );
};

export default AddEditIntervention;
