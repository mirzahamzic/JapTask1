import React, { useEffect } from "react";
import { useForm } from "react-hook-form";
import { useDispatch, useSelector } from "react-redux";
import { useNavigate, Link } from "react-router-dom";
import { Button, Form, Container, Spinner } from "react-bootstrap";
import { loginUser, reset } from "../store/auth/auth-slice";
import { toast } from "react-toastify";
import { FaSignInAlt } from "react-icons/fa";

const Login = (props) => {
  const dispatch = useDispatch();
  const navigate = useNavigate();

  const { user, isLoading, isError, isSuccess, message } = useSelector(
    (state) => state.auth
  );

  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm();

  useEffect(() => {
    if (isError) {
      toast.error(message);
    }

    // Redirect when logged in
    if (isSuccess || user) {
      navigate("/home");
    }

    dispatch(reset());
  }, [isError, isSuccess, user, message, navigate, dispatch]);

  const onSubmit = (data) => {
    dispatch(loginUser(data));
  };

  if (isLoading) {
    return <Spinner />;
  }

  return (
    <Container style={{ maxWidth: "500px" }} className="my-5">
      <h3>
        <FaSignInAlt /> User login
      </h3>
      <hr />
      <Form onSubmit={handleSubmit(onSubmit)}>
        <Form.Group className="mb-3">
          <Form.Label>Enter name</Form.Label>
          <Form.Control
            type="text"
            placeholder="Name"
            {...register("name", {
              required: "Name is required",
              min: { value: 3, message: "Too short." },
              maxLength: { value: 30, message: "Too long." },
            })}
            isInvalid={errors.name}
          />
          <Form.Control.Feedback type="invalid">
            {errors.name && errors.name.message}
          </Form.Control.Feedback>
        </Form.Group>
        <Form.Group className="mb-3" controlId="password">
          <Form.Label>Enter password</Form.Label>
          <Form.Control
            type="password"
            placeholder="Password"
            {...register("password", {
              required: "Password is required.",
              minLength: { value: 6, message: "Password too short." },
            })}
            isInvalid={errors.password}
          />
          <Form.Control.Feedback type="invalid">
            {errors.password && errors.password.message}
          </Form.Control.Feedback>
        </Form.Group>

        <div className="d-flex justify-content-end">
          <Button variant="primary" type="submit">
            Submit
          </Button>
        </div>
      </Form>
    </Container>
  );
};

export default Login;
