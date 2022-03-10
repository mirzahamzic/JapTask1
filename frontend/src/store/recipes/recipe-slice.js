import { createSlice, createAsyncThunk } from "@reduxjs/toolkit";
import recipeService from "./recipe-services";

const initialState = {
  recipes: [],
  currentRecipe: {},
  status: "",
  message: "",
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
      const token = thunkAPI.getState().auth.user.token;
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

// Remove recipe
export const removeRecipe = createAsyncThunk(
  "recipes/removeRecipe",
  async (recipeId, thunkAPI) => {
    try {
      const token = thunkAPI.getState().auth.user.token;
      return await recipeService.removeRecipe(recipeId, token);
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

// Get all recipes
export const getAllRecipes = createAsyncThunk(
  "recipes/getAll",
  async (offset, thunkAPI) => {
    try {
      const token = thunkAPI.getState().auth.user.token;
      return await recipeService.getAllRecipes(offset, token);
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

// Get all user's recipes
export const getUserRecipes = createAsyncThunk(
  "recipes/getUserRecipes",
  async (_, thunkAPI) => {
    try {
      const token = thunkAPI.getState().auth.user.token;
      return await recipeService.getUserRecipes(token);
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

// Get user recipe
export const getRecipe = createAsyncThunk(
  "recipes/getRecipe",
  async (recipeId, thunkAPI) => {
    try {
      const token = thunkAPI.getState().auth.user.token;
      return await recipeService.getRecipe(recipeId, token);
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

    [getAllRecipes.pending]: (state) => {
      state.isLoading = true;
    },
    [getAllRecipes.fulfilled]: (state, action) => {
      state.isLoading = false;
      state.isSuccess = true;
      state.recentRecipes = action.payload.recentRecipes;
      state.hotRecipes = action.payload.hotRecipes;
    },
    [getAllRecipes.rejected]: (state, action) => {
      state.isLoading = false;
      state.isError = true;
      state.message = action.payload;
    },

    [getUserRecipes.pending]: (state) => {
      state.isLoading = true;
    },
    [getUserRecipes.fulfilled]: (state, action) => {
      state.isLoading = false;
      state.isSuccess = true;
      state.userRecipes = action.payload;
    },
    [getUserRecipes.rejected]: (state, action) => {
      state.isLoading = false;
      state.isError = true;
      state.message = action.payload;
    },

    [getRecipe.pending]: (state) => {
      state.isLoading = true;
    },
    [getRecipe.fulfilled]: (state, action) => {
      state.isLoading = false;
      state.isSuccess = true;
      state.recipe = action.payload;
    },
    [getRecipe.rejected]: (state, action) => {
      state.isLoading = false;
      state.isError = true;
      state.message = action.payload;
    },
  },
});

export const { reset } = recipeSlice.actions;
export default recipeSlice.reducer;
