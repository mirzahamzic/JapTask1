import { createSlice, createAsyncThunk } from "@reduxjs/toolkit";
import recipeService from "./recipe-services";

const initialState = {
  recipes: [],
  currentRecipe: {},
  recipesByCategory: [],
  status: "",
  message: "",
  searchTerm: "",
  isError: false,
  isSuccess: false,
  isLoading: false,
  isLoadMore: true,
};

// Create new recipe
export const createRecipe = createAsyncThunk(
  "recipes/create",
  async (recipeData, thunkAPI) => {
    try {
      const token = thunkAPI.getState().auth.user.data;
      return await recipeService.createRecipe(recipeData, token);
    } catch (error) {
      const message =
        (error.response &&
          error.response.data &&
          error.response.data.message) ||
        error.message ||
        error.toString();

      return thunkAPI.rejectWithValue(message);
    }
  }
);

// Update recipe
export const updateRecipe = createAsyncThunk(
  "recipes/updateRecipe",
  async (recipeData, thunkAPI) => {
    try {
      const token = thunkAPI.getState().auth.user.token;
      return await recipeService.updateRecipe(recipeData, token);
    } catch (error) {
      const message =
        (error.response &&
          error.response.data &&
          error.response.data.message) ||
        error.message ||
        error.toString();

      return thunkAPI.rejectWithValue(message);
    }
  }
);

// Get filtered recipes
export const searchRecipes = createAsyncThunk(
  "recipes/searchRecipes",
  async (searchTerm, thunkAPI) => {
    try {
      const token = thunkAPI.getState().auth.user.data;
      return await recipeService.getFilteredRecipes(searchTerm, token);
    } catch (error) {
      const message =
        (error.response &&
          error.response.data &&
          error.response.data.message) ||
        error.message ||
        error.toString();

      return thunkAPI.rejectWithValue(message);
    }
  }
);

// Get all recipes by category
export const getRecipesByCategory = createAsyncThunk(
  "recipes/getRecipesByCategory",
  async (categoryId, thunkAPI) => {
    try {
      const token = thunkAPI.getState().auth.user.data;
      return await recipeService.getRecipesByCategoryId(categoryId, token);
    } catch (error) {
      const message =
        (error.response &&
          error.response.data &&
          error.response.data.message) ||
        error.message ||
        error.toString();

      return thunkAPI.rejectWithValue(message);
    }
  }
);

// Get recipe by ID
export const getRecipeById = createAsyncThunk(
  "recipes/getRecipeById",
  async (recipeId, thunkAPI) => {
    try {
      const token = thunkAPI.getState().auth.user.data;
      return await recipeService.getRecipeById(recipeId, token);
    } catch (error) {
      const message =
        (error.response &&
          error.response.data &&
          error.response.data.message) ||
        error.message ||
        error.toString();

      return thunkAPI.rejectWithValue(message);
    }
  }
);

export const recipeSlice = createSlice({
  name: "recipe",
  initialState,
  reducers: {
    reset: (state) => initialState,
    search: (state, action) => {
      state.searchTerm = action.payload;
    },
  },
  extraReducers: {
    [createRecipe.pending]: (state) => {
      state.isLoading = true;
    },
    [createRecipe.fulfilled]: (state, action) => {
      state.isLoading = false;
      state.isSuccess = true;
    },
    [createRecipe.rejected]: (state, action) => {
      state.isLoading = false;
      state.isError = true;
      state.message = action.payload;
    },

    [searchRecipes.pending]: (state) => {
      state.isLoading = true;
    },
    [searchRecipes.fulfilled]: (state, action) => {
      state.isLoading = false;
      state.isSuccess = true;
      state.recipesByCategory = action.payload;
    },
    [searchRecipes.rejected]: (state, action) => {
      state.isLoading = false;
      state.isError = true;
      state.message = action.payload;
    },

    [getRecipesByCategory.pending]: (state) => {
      state.isLoading = true;
    },
    [getRecipesByCategory.fulfilled]: (state, action) => {
      state.isLoading = false;
      state.isSuccess = true;
      state.recipesByCategory = action.payload;
    },
    [getRecipesByCategory.rejected]: (state, action) => {
      state.isLoading = false;
      state.isError = true;
      state.message = action.payload;
    },

    [getRecipeById.pending]: (state) => {
      state.isLoading = true;
    },
    [getRecipeById.fulfilled]: (state, action) => {
      state.isLoading = false;
      state.isSuccess = true;
      state.currentRecipe = action.payload;
    },
    [getRecipeById.rejected]: (state, action) => {
      state.isLoading = false;
      state.isError = true;
      state.message = action.payload;
    },
  },
});

export const { reset, search } = recipeSlice.actions;
export default recipeSlice.reducer;
