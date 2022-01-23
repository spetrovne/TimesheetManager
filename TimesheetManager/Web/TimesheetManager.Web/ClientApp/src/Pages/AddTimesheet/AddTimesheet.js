import "./AddTimesheet.css";
import React, { useEffect, useState } from "react";
import { Container, Table } from "react-bootstrap";
import { getProjects } from "../../Services/Project/Project";
import Select from "react-select";
import TimesheetRow from "./TimesheetRow/TimesheetRow";

const columns = [
  "Project",
  "Task",
  "Mon",
  "Tue",
  "Wed",
  "Thur",
  "Fri",
  "Sat",
  "Sun",
  // "Monday",
  // "Tuesday",
  // "Wednesday",
  // "Thursday",
  // "Friday",
  // "Saturday",
  // "Sunday",
];

const customStyles = {
  menuList: (base) => ({
    ...base,
    height: "100px",
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
  const [projects, setPtojects] = useState([]);
  const [timesheetRows, setTimesheetRows] = useState([]);
  const [rowCount, setRowCount] = useState(1);

  const onChangeRow = (id, timesheetRow) => {
    let tempTimesheetRows = timesheetRows;
    console.log(tempTimesheetRows);

    tempTimesheetRows[id] = timesheetRow;

    if ((rowCount === 1 && id === 0) || id === rowCount - 1) {
      addColumn();
    }

    setTimesheetRows(tempTimesheetRows);
  };

  const addColumn = () => {
    setRowCount(rowCount + 1);
  };

  useEffect(() => {
    getProjects().then((result) => setPtojects(result));
  }, []);
  return (
    <Container className="timesheet-container">
      <div className="create-timesheet-header">
        {/* <h1>Create Timesheet</h1> */}
      </div>
      <div className="row">
        <div class="card col-md-6">
          <div class="card-body">
            <h3 class="card-title">Week 01 -2022</h3>
            <div class=" card-text mt-3">
              <p>
                <b>Start Date:</b> 02-11-2022
              </p>

              <div className="row">
                <p className="col-md-6">
                  <b>End Date:</b> 02-11-2022
                </p>
                <p className="col-md-6">
                  <b>Stoyan Petrov</b>
                </p>
              </div>
            </div>
          </div>
        </div>

        <div class=" col-md-6 p-3">
          <div className="row h-100 w-100 bottom-end-align">
            <div className="col-sm-4 btn btn-primary mt-3 ">Save</div>
            <div className="col-sm-1 "></div>
            <div className="col-sm-4 btn btn-success mt-3">Submit</div>
          </div>
        </div>
      </div>
      <form>
        <Table
          responsive
          className="timesheet-table table-striped table-sm mt-5"
        >
          <thead>
            <tr>
              <th>#</th>
              {Array.from({ length: 9 }).map((_, index) => (
                <th key={index}>{columns[index]}</th>
              ))}
              <th>Total</th>
              <th></th>
            </tr>
          </thead>
          <tbody>
            {Array.from({ length: rowCount }).map((_, index) => (
              <TimesheetRow
                key={index}
                id={index}
                onChangeRow={onChangeRow}
              ></TimesheetRow>
            ))}
          </tbody>
        </Table>
      </form>
      <button onClick={(e) => addColumn(e)}></button>
    </Container>
  );
}

export default AddTimesheet;
