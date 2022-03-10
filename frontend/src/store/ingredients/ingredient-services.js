import axios from "axios";

const API_URL = "/api/ingredients/";

// Create new ingredient
const createIngredient = async (ingredientData, token) => {
  const config = {
    headers: {
      Authorization: `Bearer ${token}`,
    },
  };

  const response = await axios.post(API_URL, ingredientData, config);

  return response.data;
};

// Update ingredient
const updateIngredient = async (ingredientData, token) => {
  const { ingredientId, text } = ingredientData;
  console.log(text);
  const config = {
    headers: {
      Authorization: `Bearer ${token}`,
    },
  };
  const response = await axios.put(API_URL + ingredientId, {text}, config);
  return response.data;
};

// Get all ingredients
const getAllIngredients = async (offset, token) => {
  const config = {
    headers: {
      Authorization: `Bearer ${token}`,
    },
  };

  const response = await axios.get(API_URL, config);

  return response.data;
};

// Get user ingredients
const getUserIngredients = async (token) => {
  const config = {
    headers: {
      Authorization: `Bearer ${token}`,
    },
  };

  const response = await axios.get(API_URL + "user", config);

  return response.data;
};

// Get user ingredient
const getIngredient = async (ingredientId, token) => {
  const config = {
    headers: {
      Authorization: `Bearer ${token}`,
    },
  };

  const response = await axios.get(API_URL + ingredientId, config);

  return response.data;
};

// Remove user ingredient
const removeIngredient = async (ingredientId, token) => {
  const config = {
    headers: {
      Authorization: `Bearer ${token}`,
    },
  };
  const response = await axios.delete(API_URL + ingredientId, config);
  return response.data;
};



const ingredientService = {
  createIngredient,
  getAllIngredients,
  getUserIngredients,
  getIngredient,
  removeIngredient,
};

export default ingredientService;
