import { Routes, Route } from "react-router-dom";
import InterventionList from "../pages/intervention-list/InterventionList";
import AddEditIntervention from "../pages/add-edit-intervention/AddEditIntervention";
import ContractList from "../pages/contract-list/ContractList";

const AppRoutes = () => {
  return (
    <Routes>
      <Route path="/" element={<InterventionList />} />
      <Route path="/interventions" element={<InterventionList />} />
      <Route path="/contracts" element={<ContractList />} />
      <Route path="/add-edit-intervention" element={<AddEditIntervention />} />
    </Routes>
  );
};

export default AppRoutes;
