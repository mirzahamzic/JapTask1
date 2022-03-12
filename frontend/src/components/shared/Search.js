import { Form, FormControl } from "react-bootstrap";
import { useDispatch } from "react-redux";
import { search } from "../../store/recipes/recipe-slice";

const Search = () => {
  const dispatch = useDispatch();

  return (
    <Form className="d-flex">
      <FormControl
        type="text"
        placeholder="Search"
        className="me-2"
        aria-label="Search"
        size="lg"
        onChange={(e) => dispatch(search(e.target.value))}
      />
    </Form>
  );
};

export default Search;
