import axios from "axios";

const API_URL = "https://localhost:44319/Timesheet";

export const createTimesheet = async (timesheet) => {
  try {
    let result = await axios.post(API_URL, timesheet);
    return result.data;
  } catch (err) {}
};
