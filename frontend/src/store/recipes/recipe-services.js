import axios from "axios";

const API_URL = "/api/recipes/";

// Create new recipe
const createRecipe = async (recipeData, token) => {
  const config = {
    headers: {
      Authorization: `Bearer ${token}`,
    },
  };

  const response = await axios.post(
    "https://localhost:5001/api/Recipes/add-recipe-ingredient",
    recipeData,
    config
  );

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

// Get filtered recipes
const getFilteredRecipes = async (searchTerm, token) => {
  const config = {
    headers: {
      Authorization: `Bearer ${token}`,
    },
  };

  const response = await axios.get(
    "https://localhost:5001/api/Recipes/get-recipes-by-search-term/" +
      searchTerm,
    config
  );

  return response.data;
};

// Get recipe by category id
const getRecipesByCategoryId = async (categoryId, token) => {
  const config = {
    headers: {
      Authorization: `Bearer ${token}`,
    },
  };

  const response = await axios.get(
    "https://localhost:5001/api/Recipes/get-recipes-by-category/" + categoryId,
    config
  );

  return response.data;
};

// Get recipe by id
const getRecipeById = async (recipeId, token) => {
  const config = {
    headers: {
      Authorization: `Bearer ${token}`,
    },
  };
  const response = await axios.get(
    "https://localhost:5001/api/Recipes/get-recipe-by-id/" + recipeId,
    config
  );
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
  getFilteredRecipes,
  getRecipesByCategoryId,
  getRecipeById,
  removeRecipe,
};

export default recipeService;
