import React from "react";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import { ToastContainer } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
import { Container } from "react-bootstrap";

import AddRecipe from "./components/recipes/AddRecipe";
import Login from "./pages/Login";
import PrivateRoute from "./components/PrivateRoute";
import Home from "./pages/Home";
import RecipesByCategory from "./components/recipes/RecipesByCategory";
import RecipeDetail from "./pages/RecipeDetail";
import Header from "./components/Header";

import "./assets/css/bootstrap.min.css";

function App() {
  return (
    <>
      <Router>
        <div>
          <Header />
          <Routes>
            {/* public routes */}
            <Route path="/login" element={<Login />} />
            <Route path="/" element={<Login />} />

            {/* protected routes */}
            <Route element={<PrivateRoute />}>
              <Route path="/home" element={<Home />} />
              <Route path="/addrecipe" element={<AddRecipe />} />
              <Route
                path="/recipes/category/:categoryId"
                element={<RecipesByCategory />}
              />
              <Route path="/recipes/:recipeId" element={<RecipeDetail />} />
            </Route>

            {/* 404 route */}
            <Route
              path="*"
              element={
                <div className="py-5 text-center">
                  <h1 className="display-1 text-bold">404</h1>
                  <h6>Page not found!</h6>
                </div>
              }
            />
          </Routes>
        </div>
      </Router>
      <ToastContainer />
    </>
  );
}

export default App;
