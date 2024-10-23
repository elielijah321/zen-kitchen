import { useEffect, useState } from 'react'
import { Accordion, Button, Table } from 'react-bootstrap';
import { Link } from 'react-router-dom';
import { getAllRecipes } from '../../../functions/fetchEntities';
import { canEdit } from '../../../helpers/UserHelper';
import Loading from '../../HelperComponents/Loading';
import { Recipe } from '../../../types/Recipe/Recipe';
import { calculateTotalCalories, calculateTotalProtein } from '../../../helpers/FoodHelper';

function RecipesComponent() {

  // const state = useSelector((state: RootState) => state.systemUser);
  // const systemUser = state.systemUser;

  const [recipes, setRecipes] = useState<Recipe[] | undefined>(undefined);

  useEffect(() => {
    // fetch data
    getAllRecipes()
      .then(recipe => setRecipes(recipe));
  }, [])

  return (
    <>
      <div>
        <div className='entity-button-container'>
          {
            //systemUser
            canEdit() &&
            <div className='add-new-entity-btn'>
                  <Link className="navitem" to="/Recipe/new">
                      <Button variant="primary" className="mb-3 page-btn">
                          Add Recipe
                      </Button>
                  </Link>
              </div>
            }
        </div>
        
        {recipes !== undefined ?
        (
          <div>
            <Accordion defaultActiveKey={"recipes"}>
                <Accordion.Item key={"recipes"} eventKey={"recipes"}>
                        <Accordion.Header>{"Recipes"}</Accordion.Header>
                        <Accordion.Body>
                          {
                          recipes.length > 0 ? 
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
                                  {recipes.map((_recipe: Recipe) => {


                                    var ingredients = _recipe.ingredients.map(r => {return r.ingredient!});

                                    return (
                                      <tr key={_recipe.id}>
                                          <td>{_recipe.name}</td>
                                          <td>{calculateTotalCalories(ingredients)}</td>
                                          <td>{calculateTotalProtein(ingredients)}</td>
                                          <td>
                                            {
                                              <Link to={`/Recipe/${_recipe.id}`} className="button">
                                                  <Button className='page-btn' id={`${_recipe.id}-btn`}>
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
                          </div> : <div>No recipes</div>
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

export default RecipesComponent;