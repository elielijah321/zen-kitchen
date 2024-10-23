import { useEffect, useState } from 'react'
import { Accordion, Button, Table } from 'react-bootstrap';
import { Link } from 'react-router-dom';
import { getAllIngredients } from '../../../functions/fetchEntities';
import { Ingredient } from '../../../types/Ingredient/Ingredient';
import { canEdit } from '../../../helpers/UserHelper';
import Loading from '../../HelperComponents/Loading';

function AllergiesComponent() {

  // const state = useSelector((state: RootState) => state.systemUser);
  // const systemUser = state.systemUser;

  const [ingredients, setIngredients] = useState<Ingredient[] | undefined>(undefined);

  useEffect(() => {
    // fetch data
    getAllIngredients()
      .then(ingredients => setIngredients(ingredients));
  }, [])

  return (
    <>
      <div>
        <div className='entity-button-container'>
          {
            //systemUser
            canEdit() &&
            <div className='add-new-entity-btn'>
                  <Link className="navitem" to="/Ingredient/new">
                      <Button variant="primary" className="mb-3 page-btn">
                          Add Ingredient
                      </Button>
                  </Link>
              </div>
            }
        </div>
        
        {ingredients !== undefined ?
        (
          <div>
            <Accordion defaultActiveKey={"ingredients"}>
                <Accordion.Item key={"ingredients"} eventKey={"ingredients"}>
                        <Accordion.Header>{"Ingredients"}</Accordion.Header>
                        <Accordion.Body>
                          {
                          ingredients.length > 0 ? 
                          <div>
                            <Table striped hover responsive>
                              <thead>
                                  <tr>
                                      <th>Name</th>
                                      <th>Calories</th>
                                      <th>Protein</th>
                                      <th></th>
                                  </tr>
                              </thead>
                              <tbody>
                                  {ingredients.map((_ingredient: Ingredient) => {

                                    return (
                                      <tr key={_ingredient.id}>
                                          <td>{_ingredient.name}</td>
                                          <td>{_ingredient.calories}</td>
                                          <td>{_ingredient.protein}</td>
                                          <td>
                                            {
                                              <Link to={`/Ingredient/${_ingredient.id}`} className="button">
                                                  <Button id={`${_ingredient.id}-btn`} className='page-btn'>
                                                      Edit
                                                  </Button>
                                              </Link>
                                            }
                                              
                                          </td>
                                      </tr>
                                  )
                                  })}
                              </tbody>
                            </Table>
                          </div> : <div>No ingredients</div>
                          }
                        </Accordion.Body>
                </Accordion.Item>
            </Accordion>
          </div> 
        )
        : <Loading /> }

      </div>
    </>
  )
}

export default AllergiesComponent;