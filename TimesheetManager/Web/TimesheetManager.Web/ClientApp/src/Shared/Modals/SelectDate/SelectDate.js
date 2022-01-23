import { useState, useEffect } from "react";
import { Navigate } from "react-router-dom";
import moment from "moment";
import { Container } from "react-bootstrap";

const SelectDate = () => {
  const [endDate, setEndDate] = useState("");
  const [startDate, setStartDate] = useState("");
  const [week, setWeek] = useState("");

  const navigate = () => {
    return (
      <Navigate
        to={{
          pathname: "/Timesheet/New",
          state: { week, startDate, endDate },
        }}
        class="btn btn-primary"
      >
        Go somewhere
      </Navigate>
    );
  };
  const handleWeek = (e) => {
    setWeek(e.target.value);
    let getWeek = Number.parseInt(e.target.value.split("W")[1]);
    let endDate = moment().isoWeek(getWeek).format("yyyy-MM-DD");
    let startDate = moment(new Date(endDate)).add(-7, "d").format("yyyy-MM-DD");
    setStartDate(startDate);
    setEndDate(endDate);
  };
  return (
    <Container>
      <div className="">
        <div class="card text-center" style={{ width: "18rem" }}>
          <div className="card-header bg-primary text-white">
            <h5 class="card-title">Choose a week</h5>
          </div>
          <div class="card-body">
            <form>
              <div className="form-group">
                <input
                  className="form-control"
                  type="week"
                  name="myWeek"
                  required
                  id="myWeek"
                  onChange={handleWeek}
                />
              </div>
            </form>
            <div class="row card-text mt-3">
              {endDate && (
                <p className="col-6">
                  <b>Start Date:</b> {startDate}
                </p>
              )}
              {endDate && (
                <p className="col-6">
                  <b>End Date:</b> {endDate}
                </p>
              )}
            </div>
            <div class="btn btn-primary" onClick={navigate}>
              Go somewhere
            </div>
          </div>
        </div>
      </div>
    </Container>
  );
};

export default SelectDate;
