import axios from "axios";

const API_URL = "https://localhost:44319/Project";
const products = [
  { value: "chocolate", label: "Chocolate" },
  { value: "strawberry", label: "Strawberry" },
  { value: "vanilla", label: "Vanilla" },
];

export const getProjects = async () => {
  try {
    let result = await axios.get(API_URL + "/getAll");
    let projects = result.data.map((r) => ({ value: r.id, label: r.name }));
    return projects;
  } catch (error) {}
  return products;
};
