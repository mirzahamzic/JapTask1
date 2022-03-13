import React, { useEffect, useState } from "react";
import { useForm } from "react-hook-form";
import { useDispatch, useSelector } from "react-redux";
import { useNavigate } from "react-router-dom";
import { Button, Form, Container, Row, Col } from "react-bootstrap";
import { Spinner } from "react-bootstrap";
import { toast } from "react-toastify";
import {
  createRecipe,
  reset as resetRecipes,
} from "../../store/recipes/recipe-slice";

import {
  getAllIngredients,
  reset as resetIngredients,
} from "../../store/ingredients/ingredient-slice";
import { getAllCategories } from "../../store/categories/category-slice";

const AddRecipe = (props) => {
  const dispatch = useDispatch();
  const navigate = useNavigate();

  const [localIngredient, setLocalIngredient] = useState([]);

  const { ingredients, isLoading, isError, isSuccess, message } = useSelector(
    (state) => state.ingredient
  );

  const { categories } = useSelector((state) => state.category);

  useEffect(() => {
    if (isError) {
      toast.error(message);
    }

    dispatch(getAllIngredients());
    dispatch(getAllCategories());
  }, [dispatch, isError, isSuccess, navigate, message]);

  const {
    register,
    handleSubmit,
    formState: { errors },
    getValues,
  } = useForm();

  const onSubmit = (data) => {
    data.ingredients = localIngredient;

    const createdRecipe = {
      name: data.name,
      description: data.description,
      categoryId: data.categoryId,
      ingredients: localIngredient,
    };
    alert(JSON.stringify(createdRecipe));
    console.log(createdRecipe);
    dispatch(createRecipe(createdRecipe));
    toast.info("Recipe added.");
    navigate("/home");
  };

  if (isLoading) {
    <Spinner />;
  }

  const addIngredientToLocalList = () => {
    const data = getValues();

    if (Object.values(data).includes("")) {
      toast.error("Please add ingredient");
      return;
    }
    alert(JSON.stringify(data));
    setLocalIngredient((prevState) => [...prevState, data]);
  };

  return (
    <Container className="my-5">
      <h3>Add your recipe</h3>
      <hr />

      <Form onSubmit={handleSubmit(onSubmit)}>
        <Row className="mb-4">
          <Col>
            <Form.Group className="mb-3">
              <Form.Label>Recipe name</Form.Label>
              <Form.Control
                as="input"
                placeholder="Name..."
                {...register("name", {
                  required: "Recipe is required.",
                })}
                isInvalid={errors.name}
              />
              <Form.Control.Feedback type="invalid">
                {errors.name && errors.name.message}
              </Form.Control.Feedback>
            </Form.Group>
            <Form.Group className="mb-3">
              <Form.Label>Recipe category</Form.Label>
              <Form.Select
                {...register("categoryId", {
                  required: "Category is required.",
                })}
                isInvalid={errors.categoryId}
              >
                {categories.map((category) => (
                  <option key={category.id} value={category.id}>
                    {category.name}
                  </option>
                ))}
              </Form.Select>
              <Form.Control.Feedback type="invalid">
                {errors.categoryId && errors.categoryId.message}
              </Form.Control.Feedback>
            </Form.Group>
          </Col>
          <Col>
            <Form.Group className="mb-3">
              <Form.Label>Description</Form.Label>
              <Form.Control
                as="textarea"
                rows={5}
                placeholder="Description..."
                {...register("description", {
                  required: "Description is required.",
                })}
                isInvalid={errors.description}
              />
              <Form.Control.Feedback type="invalid">
                {errors.description && errors.description.message}
              </Form.Control.Feedback>
            </Form.Group>
          </Col>
        </Row>
        <Row>
          <Col>
            <Form.Group className="mb-3">
              <Form.Label>Ingredient</Form.Label>
              <Form.Select
                {...register("ingredientId", {
                  required: "Ingredient is required.",
                })}
                isInvalid={errors.ingredientId}
              >
                <option default disabled>
                  Choose ingredient
                </option>
                {ingredients.map((ingredient) => (
                  <option key={ingredient.id} value={ingredient.id}>
                    {ingredient.name}
                  </option>
                ))}
              </Form.Select>
              <Form.Control.Feedback type="invalid">
                {errors.ingredientId && errors.ingredientId.message}
              </Form.Control.Feedback>
            </Form.Group>
          </Col>
          <Col>
            <Form.Group className="mb-3">
              <Form.Label>Unit of measure</Form.Label>
              <Form.Select
                {...register("ingredientUnit", {
                  required: "Unit of measure is required.",
                })}
                isInvalid={errors.ingredientUnit}
              >
                <option default disabled>
                  Choose measure unit
                </option>
                <option value="kg">Kilogram</option>
                <option value="gr">Gram</option>
                <option value="l">Liter</option>
                <option value="ml">Milliliter</option>
              </Form.Select>
              <Form.Control.Feedback type="invalid">
                {errors.ingredientUnit && errors.ingredientUnit.message}
              </Form.Control.Feedback>
            </Form.Group>
          </Col>
          <Col>
            <Form.Group className="mb-3">
              <Form.Label>Quantity</Form.Label>
              <Form.Control
                type="number"
                min="0"
                step="0.01"
                placeholder="Quantity..."
                {...register("ingredientQuantity", {
                  required: "Quantity is required.",
                  pattern: {
                    value: /^[0-9]*(\.)?[0-9]+$/,
                    message: "Only positive numbers.",
                  },
                })}
                isInvalid={errors.ingredientQuantity}
              />
              <Form.Control.Feedback type="invalid">
                {errors.ingredientQuantity && errors.ingredientQuantity.message}
              </Form.Control.Feedback>
            </Form.Group>
          </Col>

          <Col>
            <Button className="mt-4" onClick={addIngredientToLocalList}>
              Add ingredient
            </Button>
          </Col>
        </Row>
        <hr />
        <div>
          {localIngredient &&
            localIngredient.map((ingredient, i) => {
              let ingName = ingredients.find(
                (item) => item.id == ingredient.ingredientId
              );
              return (
                <Row key={i} className="d-flex justify-content-between">
                  <Col>{i + 1}</Col>
                  <Col>{ingName.name}</Col>
                  <Col>{ingredient.ingredientUnit}</Col>
                  <Col>{ingredient.ingredientQuantity}</Col>
                </Row>
              );
            })}
        </div>
        <hr />
        <div className="my-4 d-flex justify-content-between">
          <Button variant="success" type="submit" size="lg">
            Submit
          </Button>
          {/* <BackButton url="/home" /> */}
        </div>
      </Form>
    </Container>
  );
};

export default AddRecipe;
