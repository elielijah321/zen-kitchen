import { ChangeEvent, useEffect, useState } from 'react'
import { Accordion, Button, Form, Table } from 'react-bootstrap';
import { Link } from 'react-router-dom';
import { canEdit } from '../../helpers/UserHelper';
import { Case } from '../../types/Case/Case';
import Loading from '../HelperComponents/Loading';
import { getAllCases, searchAllCases } from '../../functions/fetchEntities';

function CasesPage() {

  // const state = useSelector((state: RootState) => state.systemUser);
  // const systemUser = state.systemUser;

  const [cases, setCases] = useState<Case[] | undefined>(undefined);
  const [searchTerm, setSearchTerm] = useState<string>("");


  const handleSearchChange = (event: ChangeEvent<HTMLInputElement>) => {
    const name = event.target.value;
    setSearchTerm(name);

    if(name === "")
    {
      getAllCases()
        .then(cases => setCases(cases));

    }else{
      searchAllCases(name)
      .then(cases => setCases(cases));
    }
    
  }

  useEffect(() => {
    // fetch data
    getAllCases()
      .then(cases => setCases(cases));
  }, [])

  return (
    <>
      <div className='page'>
        <div className='entity-button-container'>
          <div className='search-input'>
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
                  <Link className="navitem" to="/Case/new">
                      <Button variant="primary" className="mb-3">
                          Add Case
                      </Button>
                  </Link>
              </div>
            }
        </div>
        
        {cases !== undefined ?
        (
          <div>
            <Accordion defaultActiveKey={"cases"}>
                <Accordion.Item key={"cases"} eventKey={"cases"}>
                        <Accordion.Header>{"Cases"}</Accordion.Header>
                        <Accordion.Body>
                          {
                          cases.length > 0 ? 
                          <div>
                            <Table striped hover responsive>
                              <thead>
                                  <tr>
                                      <th>Title</th>
                                      <th></th>
                                  </tr>
                              </thead>
                              <tbody>
                                  {cases.map((_case: Case) => {

                                    return (
                                      <tr key={_case.id}>
                                          <td className='case-title'>{_case.title}</td>
                                          <td>
                                            {
                                              <Link to={`/Case/${_case.id}`} className="button">
                                                  <Button id={`${_case.id}-btn`}>
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
                          </div> : <div>No cases</div>
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

export default CasesPage;