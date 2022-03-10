import React from "react";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import { ToastContainer } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
import { Container } from "react-bootstrap";

import AddRecipe from "./components/recipes/AddRecipe";

import "./assets/css/bootstrap.min.css";

function App() {
  return (
    <>
      <Router>
        <div>
          {/* <Header /> */}
          <Routes>
            {/* public routes */}
            <Route path="/addrecipe" element={<AddRecipe />} />
            {/* <Route path="/login" element={<Login />} />
            <Route path="/" element={<Home />} /> */}

            {/* protected routes
            <Route element={<PrivateRoute />}>
              <Route path="/question/:questionId" element={<Question />} />
              <Route path="/addquestion" element={<AddQuestion />} />
              <Route
                path="/editquestion/:questionId"
                element={<EditQuestion />}
              />
              <Route path="/editanswer/:answerId" element={<EditAnswer />} />
              <Route path="/myquestions" element={<MyQuestions />} />
              <Route path="/profile" element={<MyProfile />} />
            </Route> */}

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
