import "./AddTimesheet.css";
import React, { useEffect, useState } from "react";
import { Container, Table, Alert } from "react-bootstrap";
import { getProjects } from "../../Services/Project/Project";
import Select from "react-select";
import moment from "moment";
import TimesheetRow from "./TimesheetRow/TimesheetRow";
import SelectDate from "../../Shared/Modals/SelectDate/SelectDate";
import { createTimesheet } from "../../Services/Timesheet/TimesheetService";

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
  const [show, setShow] = useState(false);
  const [endDate, setEndDate] = useState("");
  const [startDate, setStartDate] = useState("");
  const [week, setWeek] = useState("");
  const [visibleAlert, setVisibleAlert] = useState(false);

  const handleVisible = () => {
    setVisibleAlert(true);
    setTimeout(() => {
      setVisibleAlert(false);
    }, 2000);
  };

  function openDatePicker() {
    setShow(true);
  }

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

  const restartState = () => {
    setRowCount(1);
    setTimesheetRows([]);
  };

  const handleWeek = (e) => {
    setWeek(e.target.value);
    let getWeek = Number.parseInt(e.target.value.split("W")[1]);
    let endDate = moment().isoWeek(getWeek).format("yyyy-MM-DD");
    let startDate = moment(new Date(endDate)).add(-7, "d").format("yyyy-MM-DD");
    setStartDate(startDate);
    setEndDate(endDate);
  };

  const handleValidation = () => {
    if (!week) {
      handleVisible();
      return false;
    }

    if (!timesheetRows.length) {
      handleVisible();
      return false;
    }

    return true;
  };

  const handleSave = () => {
    if (handleValidation()) {
      let timesheet = {
        name: week,
        startDate,
        endDate,
        timesheetRows,
      };

      console.log(timesheet);
      createTimesheet(timesheet).then((result) => console.log(result));
    }
  };

  useEffect(() => {
    if (!week) {
      setShow(true);
    }
  }, []);

  useEffect(() => {
    getProjects().then((result) => setPtojects(result));
  }, []);
  return (
    <Container className="timesheet-container">
      <Alert show={visibleAlert} variant="danger" dismissible>
        Timesheet should have date and atleast one filled row!
      </Alert>
      <SelectDate
        show={show}
        setShow={setShow}
        handleWeek={handleWeek}
        newTimesheet={restartState}
      />
      <div className="create-timesheet-header">
        {/* <h1>Create Timesheet</h1> */}
      </div>
      <div className="row">
        <div class="card col-md-6">
          <div class="card-body">
            <h3 class="card-title">{week}</h3>
            <div class=" card-text mt-3">
              <p>
                <b>Start Date:</b> {startDate}
              </p>

              <div className="row">
                <p className="col-md-6">
                  <b>End Date:</b> {endDate}
                </p>
                <p className="col-md-6">
                  <b>Stoyan Petrov</b>
                </p>
              </div>
            </div>
          </div>
        </div>

        <div class=" col-md-6 p-3">
          <div className="row h-100 w-100 bottom-end-align g-4">
            <button
              className="col-lg-2 btn btn-primary mx-1 "
              onClick={() => handleSave()}
            >
              Save
            </button>
            <button className="col-lg-2 btn btn-success mx-1">Submit</button>
            <button
              className="col-lg-2 btn btn-primary mx-1 "
              onClick={() => openDatePicker()}
            >
              New
            </button>
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
