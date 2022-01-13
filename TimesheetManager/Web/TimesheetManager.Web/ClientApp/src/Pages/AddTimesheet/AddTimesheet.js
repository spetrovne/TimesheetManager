import "./AddTimesheet.css";
import React from "react";
import { Container, Table } from "react-bootstrap";
import Select from "react-select";

const columns = [
  "Project",
  "Task",
  "Monday",
  "Tuesday",
  "Wednesday",
  "Thursday",
  "Friday",
  "Saturday",
  "Sunday",
];

const customStyles = {
  menuList: (base) => ({
    ...base,
    height: "150px",
    minHeight: "35px", // your desired height
  }),
};

const options = [
  { value: "chocolate", label: "Chocolate" },
  { value: "strawberry", label: "Strawberry" },
  { value: "vanilla", label: "Vanilla" },
];

const data = [
  ["Aurelia Vega", 30, "Deepends", "Spain", "Madrid"],
  ["Guerra Cortez", 45, "Insectus", "USA", "San Francisco"],
  ["Guadalupe House", 26, "Isotronic", "Germany", "Frankfurt am Main"],
  ["Elisa Gallagher", 31, "Portica", "United Kingdom", "London"],
];

function AddTimesheet() {
  return (
    <Container className="timesheet-container">
      <div className="create-timesheet-header">
        <h1>Create Timesheet</h1>
      </div>
      {Array.from(columns).map((c) => {
        <p>{c}</p>;
      })}
      <Table responsive className="timesheet-table">
        <thead>
          <tr>
            <th>#</th>
            {Array.from({ length: 9 }).map((_, index) => (
              <th key={index}>{columns[index]}</th>
            ))}
          </tr>
        </thead>
        <tbody>
          <tr>
            <td>1</td>
            <td>
              <Select options={options} styles={customStyles} />
            </td>
            {Array.from({ length: 8 }).map((_, index) => (
              <td key={index}>Table cell {index}</td>
            ))}
            <td>X</td>
          </tr>
          <tr>
            <td>2</td>
            {Array.from({ length: 9 }).map((_, index) => (
              <td key={index}>Table cell {index}</td>
            ))}
            <td>X</td>
          </tr>
          <tr>
            <td>3</td>
            {Array.from({ length: 9 }).map((_, index) => (
              <td key={index}>Table cell {index}</td>
            ))}
            <td>X</td>
          </tr>
        </tbody>
      </Table>
    </Container>
  );
}

export default AddTimesheet;
