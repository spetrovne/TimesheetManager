import React from "react";
import { Container, Navbar, Nav, NavDropdown } from "react-bootstrap";
import { Link } from "react-router-dom";
import "./Header.css";

const Header = () => {
  return (
    <Navbar sticky="top" bg="light" expand="lg">
      <Container>
        <Navbar.Brand>
          <Link className="text-dark no-decoration" to="/Home">
            Timesheet Manager
          </Link>
        </Navbar.Brand>
        <Navbar.Toggle aria-controls="basic-navbar-nav" />
        <Navbar.Collapse id="basic-navbar-nav">
          <Nav active={true} className="me-auto">
            <Nav.Link className="d-flex" as={Link} to="/Home">
              Home
            </Nav.Link>
            {/* <NavDropdown title="Timesheet" id="basic-nav-dropdown">
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
            </NavDropdown> */}
          </Nav>
          <div className="d-flex">
            <Link className="text-dark no-decoration" to="/Login">
              Login
            </Link>
          </div>
        </Navbar.Collapse>
      </Container>
    </Navbar>
  );
};

export default Header;
