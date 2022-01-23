import React, { useEffect, useState } from "react";
import { Container, Table } from "react-bootstrap";
import { getProjects } from "../../../Services/Project/Project";
import Select from "react-select";

const customStyles = {
  menuList: (base) => ({
    ...base,
    height: "100px",
    minHeight: "35px",
  }),
};

function TimesheetRow({ id, onChangeRow }) {
  const [projects, setPtojects] = useState([]);
  const [projectId, setProjectId] = useState(1);
  const [taskId, setTaskId] = useState(1);
  const [mondayHours, setmondayHours] = useState(0);
  const [tuesdayHours, setTuesdayHours] = useState(0);
  const [wednesdayHours, setWednesdayHours] = useState(0);
  const [thursdayHours, setThursdayHours] = useState(0);
  const [fridayHours, setFridayHours] = useState(0);
  const [saturdayHours, setSaturdayHours] = useState(0);
  const [sundayHours, setSundayHours] = useState(0);
  const [total, setTotal] = useState(0);

  const returnCurrentRowState = (field, value) => {
    let row = {
      projectId,
      taskId,
      mondayHours,
      tuesdayHours,
      wednesdayHours,
      thursdayHours,
      fridayHours,
      saturdayHours,
      sundayHours,
      total: getTotal(),
    };

    row[field] = value;
    console.log(row);

    onChangeRow(id, row);
  };

  const getTotal = () => {
    return (
      Number.parseInt(mondayHours) +
      Number.parseInt(tuesdayHours) +
      Number.parseInt(wednesdayHours) +
      Number.parseInt(thursdayHours) +
      Number.parseInt(fridayHours) +
      Number.parseInt(saturdayHours) +
      Number.parseInt(sundayHours)
    );
  };

  const onChangeProject = (e) => {
    setProjectId(e.target.value);
    returnCurrentRowState("projectId", e.target.value);
  };

  const onChangeTask = (e) => {
    setTaskId(e.target.value);
    returnCurrentRowState("taskId", e.target.value);
  };

  const onChangeMondayHours = (e) => {
    setmondayHours(e.target.value);
    returnCurrentRowState("mondayHours", Number.parseFloat(e.target.value));
  };

  const onChangeTuesdayHours = (e) => {
    setTuesdayHours(e.target.value);
    returnCurrentRowState("tuesdayHours", Number.parseFloat(e.target.value));
  };

  const onChangeWednesdayHours = (e) => {
    setWednesdayHours(e.target.value);
    returnCurrentRowState("wednesdayHours", Number.parseFloat(e.target.value));
  };

  const onChangeThursdayHours = (e) => {
    setThursdayHours(e.target.value);
    returnCurrentRowState("thursdayHours", Number.parseFloat(e.target.value));
  };
  const onChangeFridayHours = (e) => {
    setFridayHours(e.target.value);
    returnCurrentRowState("fridayHours", Number.parseFloat(e.target.value));
  };

  const onChangeSaturdayHours = (e) => {
    setSaturdayHours(e.target.value);
    returnCurrentRowState("saturdayHours", Number.parseFloat(e.target.value));
  };

  const onChangeSundayHours = (e) => {
    setSundayHours(e.target.value);
    returnCurrentRowState("sundayHours", Number.parseFloat(e.target.value));
  };

  useEffect(() => {
    getProjects().then((result) => setPtojects(result));
  }, []);
  return (
    <tr>
      <td>{id}</td>
      <td>
        {/* <Select
          options={projects}
          styles={customStyles}
          onChange={onChangeProject}
        /> */}
        <select
          className="form-control custom-select custom-select-md "
          value={projectId}
          onChange={onChangeProject}
        >
          <option defaultValue hidden></option>
          {projects.map((project, index) => (
            <option key={index} value={project.value}>
              {project.label}
            </option>
          ))}
          />
        </select>
      </td>
      <td>
        {/* <Select
          options={projects}
          styles={customStyles}
          onChange={onChangeTask}
        /> */}
        <div className="form-group">
          <select
            className="form-control custom-select custom-select-md "
            value={taskId}
            onChange={onChangeTask}
          >
            <option defaultValue hidden></option>
            {projects.map((project, index) => (
              <option key={index} value={project.value}>
                {project.label}
              </option>
            ))}
          </select>
        </div>
      </td>
      <td>
        <div className="form-group">
          <input
            type="number"
            value={mondayHours}
            name="mondayHours"
            className="form-control hour-input"
            onChange={onChangeMondayHours}
          ></input>
        </div>
      </td>
      <td>
        <div className="form-group">
          <input
            type="number"
            value={tuesdayHours}
            name="tuesdayHours"
            className="form-control hour-input"
            onChange={onChangeTuesdayHours}
          ></input>
        </div>
      </td>
      <td>
        <div className="form-group">
          <input
            type="number"
            value={wednesdayHours}
            name="wednesdayHours"
            className="form-control hour-input"
            onChange={onChangeWednesdayHours}
          ></input>
        </div>
      </td>
      <td>
        <div className="form-group">
          <input
            type="number"
            value={thursdayHours}
            name="thursdayHours"
            className="form-control hour-input"
            onChange={onChangeThursdayHours}
          ></input>
        </div>
      </td>
      <td>
        <div className="form-group">
          <input
            type="number"
            value={fridayHours}
            name="fridayHours"
            className="form-control hour-input"
            onChange={onChangeFridayHours}
          ></input>
        </div>
      </td>
      <td>
        <div className="form-group">
          <input
            type="number"
            value={saturdayHours}
            name="saturdayHours"
            className="form-control hour-input"
            onChange={onChangeSaturdayHours}
          ></input>
        </div>
      </td>
      <td>
        <div className="form-group">
          <input
            type="number"
            value={sundayHours}
            name="sundayHours"
            className="form-control hour-input"
            onChange={onChangeSundayHours}
          ></input>
        </div>
      </td>

      <td>{getTotal()}</td>
      <td>X</td>
    </tr>
  );
}

export default TimesheetRow;
