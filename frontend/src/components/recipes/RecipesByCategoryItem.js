import React from "react";
import { Card, Button } from "react-bootstrap";
import { Link } from "react-router-dom";
import { GiMeal } from "react-icons/gi";

const RecipesByCategoryItem = ({ recipe }) => {
  return (
    <Card className="m-4">
      <Card.Header></Card.Header>
      <Card.Body>
        <h1>
          <GiMeal className="text-warning" /> {recipe.name}
        </h1>
        <Card.Text>{recipe.description}</Card.Text>
        <hr />
        <h5>Ingredients:</h5>
        {recipe.ingredient.map()}
        {/* <Link to={`/recipes/category/${category.id}`}> */}
        <Button size="sm" variant="success" className="mt-4">
          View
        </Button>
        {/* </Link> */}
      </Card.Body>
    </Card>
  );
};

export default RecipesByCategoryItem;
