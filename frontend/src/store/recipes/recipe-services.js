import axios from "axios";

const API_URL = "/api/recipes/";

// Create new recipe
const createRecipe = async (recipeData, token) => {
  const config = {
    headers: {
      Authorization: `Bearer ${token}`,
    },
  };

  const response = await axios.post("https://localhost:5001/api/Recipes/add-recipe-ingredient", recipeData, config);

  return response.data;
};

// Update recipe
const updateRecipe = async (recipeData, token) => {
  const { recipeId, text } = recipeData;
  console.log(text);
  const config = {
    headers: {
      Authorization: `Bearer ${token}`,
    },
  };
  const response = await axios.put(API_URL + recipeId, { text }, config);
  return response.data;
};

// Get all recipes
const getAllRecipes = async (offset, token) => {
  const config = {
    headers: {
      Authorization: `Bearer ${token}`,
    },
  };

  const response = await axios.get(API_URL, config);

  return response.data;
};

// Get user recipes
const getUserRecipes = async (token) => {
  const config = {
    headers: {
      Authorization: `Bearer ${token}`,
    },
  };

  const response = await axios.get(API_URL + "user", config);

  return response.data;
};

// Get user recipe
const getRecipe = async (recipeId, token) => {
  const config = {
    headers: {
      Authorization: `Bearer ${token}`,
    },
  };

  const response = await axios.get(API_URL + recipeId, config);

  return response.data;
};

// Remove user recipe
const removeRecipe = async (recipeId, token) => {
  const config = {
    headers: {
      Authorization: `Bearer ${token}`,
    },
  };
  const response = await axios.delete(API_URL + recipeId, config);
  return response.data;
};

const recipeService = {
  createRecipe,
  getAllRecipes,
  getUserRecipes,
  getRecipe,
  removeRecipe,
};

export default recipeService;
