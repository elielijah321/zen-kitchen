import { useEffect, useState } from 'react'
import { Accordion, Button, Table } from 'react-bootstrap';
import { Link } from 'react-router-dom';
import { canEdit } from '../../../helpers/UserHelper';
import Loading from '../../HelperComponents/Loading';
import { getAllAllergies } from '../../../functions/fetchEntities';
import { Allergy } from '../../../types/Allergy/Allergy';

function IngredientsComponent() {

  // const state = useSelector((state: RootState) => state.systemUser);
  // const systemUser = state.systemUser;

  const [allergies, setAllergies] = useState<Allergy[] | undefined>(undefined);

  useEffect(() => {
    // fetch data
    getAllAllergies()
      .then(allergies => setAllergies(allergies));
  }, [])

  return (
    <>
      <div>
        <div className='entity-button-container'>
          {
            //systemUser
            canEdit() &&
            <div className='add-new-entity-btn'>
                  <Link className="navitem" to="/Allergy/new">
                      <Button variant="primary" className="mb-3">
                          Add Allergy
                      </Button>
                  </Link>
              </div>
            }
        </div>
        
        {allergies !== undefined ?
        (
          <div>
            <Accordion defaultActiveKey={"allergies"}>
                <Accordion.Item key={"allergies"} eventKey={"allergies"}>
                        <Accordion.Header>{"Allergies"}</Accordion.Header>
                        <Accordion.Body>
                          {
                          allergies.length > 0 ? 
                          <div>
                            <Table striped hover responsive>
                              <thead>
                                  <tr>
                                      <th>Name</th>
                                      <th></th>
                                  </tr>
                              </thead>
                              <tbody>
                                  {allergies.map((_allergy: Allergy) => {

                                    return (
                                      <tr key={_allergy.id}>
                                          <td>{_allergy.name}</td>
                                          <td>
                                            {
                                              <Link to={`/Allergy/${_allergy.id}`} className="button">
                                                  <Button className='page-btn' id={`${_allergy.id}-btn`}>
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
                          </div> : <div>No allergies</div>
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

export default IngredientsComponent;