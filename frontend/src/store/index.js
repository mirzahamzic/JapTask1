import { configureStore } from "@reduxjs/toolkit";
import recipeReducer from "./recipes/recipe-slice";

export const store = configureStore({
  reducer: {
    recipe: recipeReducer,
  },
});
