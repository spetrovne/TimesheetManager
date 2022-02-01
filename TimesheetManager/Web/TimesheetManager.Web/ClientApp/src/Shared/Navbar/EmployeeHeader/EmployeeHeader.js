import React from "react";
import { Container, Navbar, Nav, NavDropdown } from "react-bootstrap";
import { Link } from "react-router-dom";
import "../Header.css";

const EmployeeHeader = ({ logout, user }) => {
  return (
    <Navbar fixed bg="light" expand="lg">
      <Container>
        <Navbar.Brand>
          <Link className="text-dark no-decoration" to="/Home">
            Timesheet Manager
          </Link>
        </Navbar.Brand>
        <Navbar.Toggle aria-controls="basic-navbar-nav" />
        <Navbar.Collapse id="basic-navbar-nav justify-content-end">
          <Nav active={true} className="me-auto">
            <Nav.Link as={Link} to="/Home">
              Home
            </Nav.Link>
            <NavDropdown title="Timesheet" id="basic-nav-dropdown">
              <NavDropdown.Item as={Link} to="/Timesheet/New">
                New
              </NavDropdown.Item>
              <NavDropdown.Item as={Link} to="/Timesheet/Saved">
                Saved
              </NavDropdown.Item>
              <NavDropdown.Item as={Link} to="/Timesheets">
                Submited
              </NavDropdown.Item>
              <NavDropdown.Divider />
              <NavDropdown.Item href="#action/3.4">
                Separated link
              </NavDropdown.Item>
            </NavDropdown>
          </Nav>
          <Nav className="d-flex justify-content-end">
            <Nav.Link className="text-dark" as={Link} to="/Profile">
              {user.fullName}
            </Nav.Link>
            <Nav.Link as={Link} to="/Login" onClick={() => logout()}>
              Logout
            </Nav.Link>
          </Nav>
        </Navbar.Collapse>
      </Container>
    </Navbar>
  );
};

export default EmployeeHeader;
