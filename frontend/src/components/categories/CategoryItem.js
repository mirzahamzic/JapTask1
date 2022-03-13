import React from "react";
import { Card, Button } from "react-bootstrap";
import { GiMeal } from "react-icons/gi";
import { Link } from "react-router-dom";

const CategoryItem = ({ category }) => {
  const categoryName = category.name;
  return (
    <Card className="m-4">
      <Card.Header></Card.Header>
      <Card.Body className="text-center">
        <h1>
          <GiMeal className="text-warning" />
        </h1>
        <hr />
        <h4>{category.name}</h4>
        <Link
          to={`/recipes/category/${category.id}`}
          state={{ name: categoryName }}
        >
          <Button size="sm" variant="success" className="mt-4">
            View
          </Button>
        </Link>
      </Card.Body>
    </Card>
  );
};

export default CategoryItem;
