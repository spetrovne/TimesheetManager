import { Container } from "react-bootstrap";
import workHours from "../../../assets/pngegg.png";
import { Link } from "react-router-dom";
import "./BaseSection.css";

const BaseSection = () => {
  return (
    <section className="bg-dark text-light text-center text-sm-start p-5">
      <div className="container">
        <div className="d-sm-flex align-items-center justify-content-between">
          <div className="">
            <h1>
              Keep track on your
              <span className="text-warning"> working hours</span>
            </h1>
            <p className="lead my-4">
              Make your manager's life easier and yours too by keeping track on
              your work. We have made an user friendly system where you could
              easily submit your working hours for the week.
            </p>
            <Link className="btn btn-primary btn-lg" to="/Login">
              Login
            </Link>
          </div>
          <img
            className=" work-hours-img img-fluid d-none d-sm-block"
            src={workHours}
            alt="work-hours"
          ></img>
        </div>
      </div>
    </section>
  );
};

export default BaseSection;
