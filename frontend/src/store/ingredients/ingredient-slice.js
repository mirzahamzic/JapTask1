import { createSlice, createAsyncThunk } from "@reduxjs/toolkit";
import ingredientService from "./ingredient-services";

const initialState = {
  ingredients: [],
  currentIngredient: {},
  status: "",
  message: "",
  isError: false,
  isSuccess: false,
  isLoading: false,
  isLoadMore: true,
};

// Create new ingredient
export const createIngredient = createAsyncThunk(
  "ingredients/create",
  async (ingredientData, thunkAPI) => {
    try {
      const token = thunkAPI.getState().auth.user.token;
      return await ingredientService.createIngredient(ingredientData, token);
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

// Update ingredient
export const updateIngredient = createAsyncThunk(
  "ingredients/updateIngredient",
  async (ingredientData, thunkAPI) => {
    try {
      const token = thunkAPI.getState().auth.user.token;
      return await ingredientService.updateIngredient(ingredientData, token);
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

// Remove ingredient
export const removeIngredient = createAsyncThunk(
  "ingredients/removeIngredient",
  async (ingredientId, thunkAPI) => {
    try {
      const token = thunkAPI.getState().auth.user.token;
      return await ingredientService.removeIngredient(ingredientId, token);
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

// Get all ingredients
export const getAllIngredients = createAsyncThunk(
  "ingredients/getAll",
  async (offset, thunkAPI) => {
    try {
      const token = thunkAPI.getState().auth.user.token;
      return await ingredientService.getAllIngredients(offset, token);
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

// Get all user's ingredients
export const getUserIngredients = createAsyncThunk(
  "ingredients/getUserIngredients",
  async (_, thunkAPI) => {
    try {
      const token = thunkAPI.getState().auth.user.token;
      return await ingredientService.getUserIngredients(token);
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

// Get user ingredient
export const getIngredient = createAsyncThunk(
  "ingredients/getIngredient",
  async (ingredientId, thunkAPI) => {
    try {
      const token = thunkAPI.getState().auth.user.token;
      return await ingredientService.getIngredient(ingredientId, token);
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

export const ingredientSlice = createSlice({
  name: "ingredient",
  initialState,
  reducers: {
    reset: (state) => initialState,
  },
  extraReducers: {
    [createIngredient.pending]: (state) => {
      state.isLoading = true;
    },
    [createIngredient.fulfilled]: (state, action) => {
      state.isLoading = false;
      state.isSuccess = true;
    },
    [createIngredient.rejected]: (state, action) => {
      state.isLoading = false;
      state.isError = true;
      state.message = action.payload;
    },

    [getAllIngredients.pending]: (state) => {
      state.isLoading = true;
    },
    [getAllIngredients.fulfilled]: (state, action) => {
      state.isLoading = false;
      state.isSuccess = true;
      state.recentIngredients = action.payload.recentIngredients;
      state.hotIngredients = action.payload.hotIngredients;
    },
    [getAllIngredients.rejected]: (state, action) => {
      state.isLoading = false;
      state.isError = true;
      state.message = action.payload;
    },

    [getUserIngredients.pending]: (state) => {
      state.isLoading = true;
    },
    [getUserIngredients.fulfilled]: (state, action) => {
      state.isLoading = false;
      state.isSuccess = true;
      state.userIngredients = action.payload;
    },
    [getUserIngredients.rejected]: (state, action) => {
      state.isLoading = false;
      state.isError = true;
      state.message = action.payload;
    },

    [getIngredient.pending]: (state) => {
      state.isLoading = true;
    },
    [getIngredient.fulfilled]: (state, action) => {
      state.isLoading = false;
      state.isSuccess = true;
      state.ingredient = action.payload;
    },
    [getIngredient.rejected]: (state, action) => {
      state.isLoading = false;
      state.isError = true;
      state.message = action.payload;
    },
  },
});

export const { reset } = ingredientSlice.actions;
export default ingredientSlice.reducer;
