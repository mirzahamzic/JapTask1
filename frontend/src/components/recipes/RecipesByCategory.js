import React, { useEffect } from "react";
import { useParams, useNavigate, Link } from "react-router-dom";
import { useDispatch, useSelector } from "react-redux";
import { toast } from "react-toastify";
import { getRecipesByCategory, reset } from "../../store/recipes/recipe-slice";
import { Card, Container, Button, Row, Col } from "react-bootstrap";
import { getAllCategories } from "../../store/categories/category-slice";
import { GiTakeMyMoney } from "react-icons/gi";

const RecipesByCategory = () => {
  const { categoryId } = useParams();

  const dispatch = useDispatch();
  const navigate = useNavigate();

  const { recipesByCategory, isError, isSuccess, isLoading, message } =
    useSelector((state) => state.recipe);

  const { categories } = useSelector((state) => state.category);

  const categoryName = categories.find((cat) => cat.id == categoryId);

  useEffect(() => {
    if (isError) {
      toast.error(message);
    }

    dispatch(getRecipesByCategory(categoryId));
    dispatch(getAllCategories());
  }, [dispatch, isError, isSuccess, navigate, message]);

  if (isLoading) {
    <h3>Loading...</h3>;
  }

  return (
    <Container className="my-4">
      <h1 className="my-4">
        Category: {categoryName && categoryName.name && categoryName.name}{" "}
      </h1>
      <hr />
      {recipesByCategory.map((recipe, i) => (
        <div key={recipe.id}>
          <Row>
            <Col sm={12} md={6}>
              <h2>{recipe.name}</h2>
            </Col>
            <Col sm={12} md={4}>
              <h2>
                <GiTakeMyMoney className="text-success" /> {recipe.cost} KM{" "}
              </h2>
            </Col>
            <Col sm={12} md={2}>
              <Link to={`/recipes/${recipe.id}`}>
                <Button variant="success">Details</Button>
              </Link>
            </Col>
          </Row>
          <hr />
        </div>
      ))}
    </Container>
  );
};

export default RecipesByCategory;
