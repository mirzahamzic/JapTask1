import axios from "axios";

const API_URL = "/api/Categories/";

// Get all ingredients
const getAllCategories = async (limit, token) => {
  const config = {
    headers: {
      Authorization: `Bearer ${token}`,
    },
  };

  const response = await axios.get(
    "https://localhost:5001/api/Categories/get-all-categories/" + limit,
    config
  );

  return response.data;
};

const categoryServices = {
  getAllCategories,
};

export default categoryServices;
