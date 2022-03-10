import React, { useEffect } from "react";
import { useForm } from "react-hook-form";
import { useDispatch, useSelector } from "react-redux";
import { useNavigate } from "react-router-dom";
import { Button, Form, Container, Row, Col } from "react-bootstrap";
import { Spinner } from "react-bootstrap";
import { toast } from "react-toastify";
import {
  createRecipe,
  getRecentRecipes,
  reset as resetSlice,
} from "../../store/recipes/recipe-slice";

const AddRecipe = (props) => {
  const dispatch = useDispatch();
  const navigate = useNavigate();

  const { isLoading, isError, isSuccess, message } = useSelector(
    (state) => state.recipe
  );

  useEffect(() => {
    if (isError) {
      toast.error(message);
    }

    if (isSuccess) {
      dispatch(resetSlice());
      navigate("/");
    }

    dispatch(resetSlice());
  }, [dispatch, isError, isSuccess, navigate, message]);

  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm();

  const onSubmit = (data) => {
    dispatch(createRecipe(data));
    // dispatch(getRecentRecipes());
    toast.info("Recipe added.");
  };

  if (isLoading) {
    <Spinner />;
  }

  return (
    <Container className="my-5">
      <h3>Add your recipe</h3>
      <hr />

      <Form onSubmit={handleSubmit(onSubmit)}>
        <Row>
          <Col>
            <Form.Group className="mb-3">
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
          </Col>
          <Col>
            <Form.Group className="mb-3">
              <Form.Control
                as="textarea"
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
          <hr />
          <h6>Choose ingredients</h6>
          <Col>
            <Form.Group className="mb-3">
              <Form.Select
                {...register("ingredient", {
                  required: "Ingredient is required.",
                })}
                isInvalid={errors.ingredient}
              >
                <option disabled selected value="">
                  Choose ingredient
                </option>
                <option value="Active">Active</option>
              </Form.Select>
              <Form.Control.Feedback type="invalid">
                {errors.ingredient && errors.ingredient.message}
              </Form.Control.Feedback>
            </Form.Group>
          </Col>
          <Col></Col>
          <Col></Col>
          <Col></Col>
        </Row>

        <div className="d-flex justify-content-between">
          <Button variant="primary" type="submit">
            Submit
          </Button>
          {/* <BackButton url="/home" /> */}
        </div>
      </Form>
    </Container>
  );
};

export default AddRecipe;
