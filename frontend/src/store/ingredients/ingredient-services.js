import axios from "axios";

const API_URL = "/api/Ingredients/";

// Get all ingredients
const getAllIngredients = async (token) => {
  const config = {
    headers: {
      Authorization: `Bearer ${token}`,
    },
  };

  const response = await axios.get("https://localhost:5001/api/Ingredients/get-all-ingredients", config);

  return response.data;
};

const ingredientService = {
  getAllIngredients,
};

export default ingredientService;
