import React from "react";
import { Container, Navbar, Nav, NavDropdown } from "react-bootstrap";
import { Link } from "react-router-dom";
import "./Header.css";

const Header = () => {
  return (
    <Navbar bg="light" expand="lg">
      <Container>
        <Navbar.Brand>
          <Link className="text-dark no-decoration" to="/Home">
            Timesheet Manager
          </Link>
        </Navbar.Brand>
        <Navbar.Toggle aria-controls="basic-navbar-nav" />
        <Navbar.Collapse id="basic-navbar-nav">
          <Nav className="me-auto">
            <Nav.Link>
              <Link className="text-dark no-decoration" to="/Home">
                Home
              </Link>
            </Nav.Link>
            <NavDropdown title="Timesheet" id="basic-nav-dropdown">
              <NavDropdown.Item>
                <Link className="text-dark no-decoration" to="/Timesheet/New">
                  New
                </Link>
              </NavDropdown.Item>
              <NavDropdown.Item>
                <Link className="text-dark no-decoration" to="/Timesheet/Saved">
                  Saved
                </Link>
              </NavDropdown.Item>
              <NavDropdown.Item>
                <Link className="text-dark no-decoration" to="/Timesheets">
                  Submited
                </Link>
              </NavDropdown.Item>
              <NavDropdown.Divider />
              <NavDropdown.Item href="#action/3.4">
                Separated link
              </NavDropdown.Item>
            </NavDropdown>
          </Nav>
        </Navbar.Collapse>
      </Container>
    </Navbar>
  );
};

export default Header;
