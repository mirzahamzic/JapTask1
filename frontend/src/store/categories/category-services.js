import axios from "axios";

const API_URL = "/api/Categories/";

// Get all categories with the load more option
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

// Get all categories without the load more option
const getAllCategoriesNoLoadMore = async (token) => {
  const config = {
    headers: {
      Authorization: `Bearer ${token}`,
    },
  }; 
  const response = await axios.get(
    "https://localhost:5001/api/Categories/get-all-categories",
    config
  );

  return response.data;
};

const categoryServices = {
  getAllCategories,
  getAllCategoriesNoLoadMore,
};

export default categoryServices;
