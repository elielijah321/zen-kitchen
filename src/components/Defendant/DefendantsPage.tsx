import { ChangeEvent, useEffect, useState } from 'react'
import { Accordion, Button, Form, Table } from 'react-bootstrap';
import { Link } from 'react-router-dom';
import { canEdit } from '../../helpers/UserHelper';
import { Defendant } from '../../types/Defendant';
import Loading from '../HelperComponents/Loading';
import { getAllDefendants, searchAllDefendants } from '../../functions/fetchEntities';

function DefendantsPage() {

  // const state = useSelector((state: RootState) => state.systemUser);
  // const systemUser = state.systemUser;

  const [defendants, setDefendants] = useState<Defendant[] | undefined>(undefined);
  const [searchTerm, setSearchTerm] = useState<string>("");


  const handleSearchChange = (event: ChangeEvent<HTMLInputElement>) => {
    const name = event.target.value;
    setSearchTerm(name);

    if(name === "")
    {
      getAllDefendants()
        .then(defendants => setDefendants(defendants));

    }else{
      searchAllDefendants(name)
      .then(defendants => setDefendants(defendants));
    }
    
  }

  useEffect(() => {
    // fetch data
    getAllDefendants()
      .then(defendants => setDefendants(defendants));
  }, [])

  return (
    <>
      <div className='page'>
        <div className='entity-button-container'>
          <div className='search-defendant-input'>
            <Form.Group className="mb-3">
                <Form.Control 
                id="edit-name"
                type="text" 
                placeholder="Search..." 
                onChange={handleSearchChange} 
                value={searchTerm} 
                required
                />
            </Form.Group>
          </div>

          {
            //systemUser
            canEdit() &&
            <div className='add-new-entity-btn'>
                  <Link className="navitem" to="/Defendant/new">
                      <Button variant="primary" className="mb-3">
                          Add Defendant
                      </Button>
                  </Link>
              </div>
            }
        </div>
        
        {defendants !== undefined ?
        (
          <div>
            <Accordion defaultActiveKey={"defendants"}>
                <Accordion.Item key={"defendants"} eventKey={"defendants"}>
                        <Accordion.Header>{"Defendants"}</Accordion.Header>
                        <Accordion.Body>
                          {
                          defendants.length > 0 ? 
                          <div>
                            <Table striped hover responsive>
                              <thead>
                                  <tr>
                                      <th>Name</th>
                                      <th>E-mail</th>
                                      <th></th>
                                  </tr>
                              </thead>
                              <tbody>
                                  {defendants.map((defendant: Defendant) => {

                                    return (
                                      <tr key={defendant.id}>
                                          <td className='defendant-name'>{defendant.name}</td>
                                          <td className='defendant-email'>{defendant.email}</td>
                                          <td>
                                            {
                                              <Link to={`/Defendant/${defendant.id}`} className="button">
                                                  <Button id={`${defendant.name}-btn`}>
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
                          </div> : <div>No defendants</div>
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

export default DefendantsPage;