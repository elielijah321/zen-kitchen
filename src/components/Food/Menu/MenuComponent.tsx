import { useEffect, useState } from 'react'
import { Accordion, Button, Form, Table } from 'react-bootstrap';
import { Link } from 'react-router-dom';
import { getAllMenus, getCurrentMenuId, postCurrentMenu } from '../../../functions/fetchEntities';
import { canEdit } from '../../../helpers/UserHelper';
import Loading from '../../HelperComponents/Loading';
import { Menu } from '../../../types/Menu/Menu';

function MenuComponent() {

  // const state = useSelector((state: RootState) => state.systemUser);
  // const systemUser = state.systemUser;

  const [menus, setMenus] = useState<Menu[] | undefined>(undefined);
  const [currentMenuId, setCurrentMenuId] = useState<string>("");

  useEffect(() => {
    // fetch data
    getAllMenus()
      .then(recipe => setMenus(recipe));

    getCurrentMenuId()
      .then(currentMenuId => setCurrentMenuId(currentMenuId));

  }, [])


  const handleCurrentMenuChange = (menu: Menu) => {

    postCurrentMenu(menu);
    setCurrentMenuId(menu.id);

  }

  return (
    <>
      <div>
        <div className='entity-button-container'>
          {
            //systemUser
            canEdit() &&
            <div className='add-new-entity-btn'>
                  <Link className="navitem" to="/Menu/new">
                      <Button variant="primary" className="mb-3 page-btn">
                          Add Menu
                      </Button>
                  </Link>
              </div>
            }
        </div>
        
        {menus !== undefined ?
        (
          <div>
            <Accordion defaultActiveKey={"menus"}>
                <Accordion.Item key={"menus"} eventKey={"menus"}>
                        <Accordion.Header>{"Menus"}</Accordion.Header>
                        <Accordion.Body>
                          {
                          menus.length > 0 ? 
                          <div>

                                    
                            <Table striped hover responsive>
                              <thead>
                                  <tr>
                                      <th>Current Menu</th>
                                      <th>Name</th>
                                      <th></th>
                                  </tr>
                              </thead>
                              <tbody>
                                  {menus.map((_menu: Menu) => {

                                    return (
                                      <tr key={_menu.id}>
                                          <td>{<Form.Check checked={currentMenuId === _menu.id} onClick={() => handleCurrentMenuChange(_menu)} value={_menu.id} name='selectedMenu' type="radio"/>}</td>
                                          <td>{_menu.name}</td>
                                          <td>
                                            {
                                              <Link to={`/Menu/${_menu.id}`} className="button">
                                                  <Button className='page-btn' id={`${_menu.id}-btn`}>
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
                          </div> : <div>No menus</div>
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

export default MenuComponent;