import Header from "../Navbar/Header";
import Footer from "../Footer/Footer";
import { useDispatch, useSelector } from "react-redux";
import "./Layout.css";
import EmployeeHeader from "../Navbar/EmployeeHeader/EmployeeHeader";
import { logout } from "../../actions/auth";

function Layout({ children }) {
  const { isLoggedIn, user } = useSelector((state) => state.auth);
  const dispatch = useDispatch();

  const logOut = () => {
    dispatch(logout());
  };

  return (
    <>
      {isLoggedIn ? (
        <EmployeeHeader logout={logOut} user={user}></EmployeeHeader>
      ) : (
        <Header></Header>
      )}
      <div className="layout-content">{children}</div>
      <Footer></Footer>
    </>
  );
}

export default Layout;
