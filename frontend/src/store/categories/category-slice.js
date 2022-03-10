import { createSlice, createAsyncThunk } from "@reduxjs/toolkit";
import categoryService from "./category-services";

const initialState = {
  categories: [],
  currentCategory: {},
  status: "",
  message: "",
  isError: false,
  isSuccess: false,
  isLoading: false,
  isLoadMore: true,
};

// Get all categories
export const getAllCategories = createAsyncThunk(
  "categories/getAll",
  async (_, thunkAPI) => {
    try {
      //   const token = thunkAPI.getState().auth.user.token;
      const token = "dummytokenfornow";
      return await categoryService.getAllCategories(token);
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

export const categorySlice = createSlice({
  name: "category",
  initialState,
  reducers: {
    reset: (state) => initialState,
  },
  extraReducers: {
    [getAllCategories.pending]: (state) => {
      state.isLoading = true;
    },
    [getAllCategories.fulfilled]: (state, action) => {
      state.isLoading = false;
      state.isSuccess = true;
      state.categories = action.payload;
    },
    [getAllCategories.rejected]: (state, action) => {
      state.isLoading = false;
      state.isError = true;
      state.message = action.payload;
    },
  },
});

export const { reset } = categorySlice.actions;
export default categorySlice.reducer;
