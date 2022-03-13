import React, { useEffect, useState } from "react";
import { Container, Row, Col, Button } from "react-bootstrap";
import { useNavigate, useParams } from "react-router-dom";
import { useSelector, useDispatch } from "react-redux";
import { getAllCategories } from "../store/categories/category-slice";
import { toast } from "react-toastify";
import CategoryItem from "../components/categories/CategoryItem";

const Home = () => {
  const dispatch = useDispatch();
  const navigate = useNavigate();

  const { categories, isError, isSuccess, message, isLoadMore } = useSelector(
    (state) => state.category
  );

  const [limit, setLimit] = useState(0);

  useEffect(() => {
    if (isError) {
      toast.error(message);
    }

    dispatch(getAllCategories(limit));
  }, [isError, limit]);

  const loadMore = () => {
    setLimit((prevState) => prevState + 4);
  };

  return (
    <Container className="my-4 text-center">
      <h1 className="my-5">Please choose recipe category</h1>
      <Row>
        {categories.map((category) => (
          <Col sm={12} md={3} key={category.id}>
            <CategoryItem category={category} />
          </Col>
        ))}
        {categories.length > 3 && (
          <Button size="lg" onClick={loadMore} disabled={!isLoadMore}>
            Load More
          </Button>
        )}
      </Row>
    </Container>
  );
};

export default Home;
