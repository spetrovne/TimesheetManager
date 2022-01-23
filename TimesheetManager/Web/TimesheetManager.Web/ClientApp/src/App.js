import logo from "./logo.svg";
import "./App.css";
import Header from "./Shared/Navbar/Header";
import "bootstrap/dist/css/bootstrap.min.css";
import Footer from "./Shared/Footer/Footer";
import Layout from "./Shared/Layout/Layout";

import { BrowserRouter, Route, Routes, Redirect } from "react-router-dom";
import HomePage from "./Pages/Home/HomePage";
import NotFound from "./Shared/NotFound/NotFound";
import AddTimesheet from "./Pages/AddTimesheet/AddTimesheet";
import SelectDate from "./Shared/Modals/SelectDate/SelectDate";

function App() {
  return (
    <BrowserRouter>
      <Layout>
        <Routes>
          <Route exact path="/" element={<HomePage />}></Route>
          <Route exact path="/Home" element={<HomePage />}></Route>
          <Route exact path="/Timesheet/New" element={<AddTimesheet />}></Route>
          <Route path="*" element={<NotFound />} />
          <Route exact path="/Week" element={<SelectDate />} />
        </Routes>
      </Layout>
    </BrowserRouter>
  );
}

export default App;
