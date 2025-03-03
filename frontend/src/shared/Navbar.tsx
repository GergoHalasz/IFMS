import { NavLink } from "react-router-dom";
import { Container, Nav, Navbar, NavDropdown } from "react-bootstrap";
import "./styles/Navbar.css"

const AppNavbar = () => {
  return (
    <Navbar expand="lg" className="navbar-custom">
      <Container>
        <Navbar.Brand href="/">
          <i className="bi bi-shield-lock"></i> Intervention File Management System
        </Navbar.Brand>
        <Navbar.Toggle aria-controls="basic-navbar-nav" />
        <Navbar.Collapse id="basic-navbar-nav">
          <Nav className="ms-auto">
            <Nav.Link as={NavLink} to="/interventions">
              <i className="bi bi-card-list"></i> Interventions
            </Nav.Link>
            <Nav.Link as={NavLink} to="/add-edit-intervention">
              <i className="bi bi-card-list"></i> Add Intervention
            </Nav.Link>
            <Nav.Link as={NavLink} to="/contracts">
              <i className="bi bi-card-list"></i> Contracts
            </Nav.Link>
            <NavDropdown title={<><i className="bi bi-person-circle"></i> Profile</>} id="profile-dropdown">
              <NavDropdown.Item href="/profile">My Account</NavDropdown.Item>
              <NavDropdown.Item href="/settings">Settings</NavDropdown.Item>
              <NavDropdown.Divider />
              <NavDropdown.Item href="/logout">Logout</NavDropdown.Item>
            </NavDropdown>
          </Nav>
        </Navbar.Collapse>
      </Container>
    </Navbar>
  );
};

export default AppNavbar;
