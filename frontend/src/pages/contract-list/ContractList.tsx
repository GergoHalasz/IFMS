import React, { useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";
import {
  fetchContracts,
  deleteContract,
} from "../../store/features/contract/actions";
import { AppDispatch, RootState } from "../../configureStore";
import { IContract } from "../../store/features/contract/types";

const ContractList: React.FC = () => {
  const dispatch = useDispatch<AppDispatch>();

  const { contracts } = useSelector((state: RootState) => state.contracts);

  useEffect(() => {
    dispatch(fetchContracts());
  }, [dispatch]);

  const handleDelete = (contract: IContract) => {
    dispatch(deleteContract(contract));
  };

  return (
    <div className="container">
      <h1>Contracts List</h1>
      <table className="table">
        <thead>
          <tr>
            <th>Contract Number</th>
            <th>Start Date</th>
            <th>End Date</th>
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>
          {contracts?.map((contract) => (
            <tr key={contract.id}>
              <td>{contract.contractNumber}</td>
              <td>{new Date(contract.startDate).toLocaleDateString()}</td>
              <td>{new Date(contract.endDate).toLocaleDateString()}</td>
              <td>
                <button
                  className="btn btn-danger"
                  onClick={() => handleDelete(contract)}
                >
                  Delete
                </button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default ContractList;
