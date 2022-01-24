import { useState, useEffect } from "react";
import { Navigate } from "react-router-dom";
import moment from "moment";
import { Container } from "react-bootstrap";
import { Modal, Button } from "react-bootstrap";

const SelectDate = ({ show, setShow, handleWeek, newTimesheet }) => {
  const [endDate, setEndDate] = useState("");
  const [startDate, setStartDate] = useState("");
  const [week, setWeek] = useState("");

  const handleClose = () => setShow(false);
  const handleShow = () => setShow(true);

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

  const handleWeekSelect = (e) => {
    setWeek(e.target.value);
    let getWeek = Number.parseInt(e.target.value.split("W")[1]);
    let endDate = moment().isoWeek(getWeek).format("yyyy-MM-DD");
    let startDate = moment(new Date(endDate)).add(-7, "d").format("yyyy-MM-DD");
    setStartDate(startDate);
    setEndDate(endDate);
    handleWeek(e);
  };

  const handleCrete = () => {
    newTimesheet();
    handleClose();
  };
  const handleCreate = () => {};
  return (
    <Container>
      <Modal show={show} onHide={handleClose}>
        <Modal.Header
          className="bg-primary text-white"
          closeButton
          closeVariant="white"
        >
          <Modal.Title>Choose a week</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <Container>
            <form>
              <div className="form-group">
                <input
                  className="form-control"
                  type="week"
                  name="myWeek"
                  value={week}
                  required
                  id="myWeek"
                  onChange={handleWeekSelect}
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
          </Container>
        </Modal.Body>
        <Modal.Footer>
          <Button variant="secondary" onClick={handleClose}>
            Close
          </Button>
          <Button variant="primary" onClick={handleCrete}>
            Create
          </Button>
        </Modal.Footer>
      </Modal>
    </Container>
  );
};

export default SelectDate;
