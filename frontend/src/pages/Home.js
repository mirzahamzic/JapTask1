import React, { useEffect } from "react";
import { Container, Row, Col, Card, CardGroup } from "react-bootstrap";
import { useNavigate, useParams } from "react-router-dom";
import { useSelector, useDispatch } from "react-redux";
import { getAllCategories } from "../store/categories/category-slice";
import { toast } from "react-toastify";
import CategoryItem from "../components/categories/CategoryItem";

const Home = () => {
  const dispatch = useDispatch();
  const navigate = useNavigate();

  const { categories, isError, isSuccess, message } = useSelector(
    (state) => state.category
  );

  useEffect(() => {
    if (isError) {
      toast.error(message);
    }

    dispatch(getAllCategories());
  }, [dispatch, isError, isSuccess, navigate, message]);

  return (
    <Container className="my-4 text-center">
      <h1 className="my-5">Please choose recipe category</h1>
      <Row>
        {categories.map((category) => (
          <Col sm={12} md={3} key={category.id}>
            <CategoryItem category={category} />
          </Col>
        ))}
      </Row>
    </Container>
  );
};

export default Home;
