import "./App.css";
import "bootstrap/dist/css/bootstrap.min.css";
import Layout from "./pages/layout/Layout";
import AppRoutes from "./routes/AppRoutes";

function App() {
  return (
    <Layout>
      <AppRoutes />
    </Layout>
  );
}

export default App;
