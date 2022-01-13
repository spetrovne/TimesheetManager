import Header from "../Navbar/Header";
import Footer from "../Footer/Footer";
import "./Layout.css";

function Layout({ children }) {
  return (
    <>
      <Header></Header>
      <div className="layout-content">{children}</div>
      <Footer></Footer>
    </>
  );
}

export default Layout;
