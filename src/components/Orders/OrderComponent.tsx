import { useEffect, useState } from 'react'
import { Accordion, Button, Form, Table } from 'react-bootstrap';
import { Order } from '../../types/Order/Order';
import Loading from '../HelperComponents/Loading';
import { getAllOrders } from '../../functions/fetchEntities';
import { getDisplayDate } from '../../helpers/DateHelper';
import OrderDetailComponent from './OrderDetailComponent';
// import { getAllMenus, getCurrentMenuId, postCurrentMenu } from '../../../functions/fetchEntities';
// import { canEdit } from '../../../helpers/UserHelper';
// import Loading from '../../HelperComponents/Loading';
// import { Menu } from '../../../types/Menu/Menu';

function OrderComponent() {

  // const state = useSelector((state: RootState) => state.systemUser);
  // const systemUser = state.systemUser;

  const [orders, setOrders] = useState<Order[]>([]);
  

  useEffect(() => {
    // fetch data
    getAllOrders()
       .then(orders => setOrders(orders));

  }, [])


  // const handleCurrentMenuChange = (menu: Menu) => {

  //   // postCurrentMenu(menu);
  //   setCurrentMenuId(menu.id);

  // }

  return (
    <>
      <div>
        
        {orders !== undefined ?
        (
          <div>
            <Accordion defaultActiveKey={"orders"}>
                <Accordion.Item key={"orders"} eventKey={"orders"}>
                        <Accordion.Header>{"Orders"}</Accordion.Header>
                        <Accordion.Body>
                          {
                          orders.length > 0 ? 
                          <div>
                            <Table striped hover responsive>
                              <tbody>
                                <Accordion alwaysOpen={true}>

                                    {orders.map((_order: Order) => {


                                      return(
                                        <OrderDetailComponent order={_order} />
                                      )

                                    //   return (
                                    //     <tr key={_order.name}>
                                    //         <td>{getDisplayDate(_order.createdAt)}</td>
                                    //         <td>{_order.name}</td>
                                    //         <td>{_order.orderDetails.length}</td>
                                    //         <td>{_order.phoneNumber}</td>
                                    //         <td>
                                    //           {/* {
                                    //             <Link to={`/Menu/${_menu.id}`} className="button">
                                    //                 <Button id={`${_menu.id}-btn`}>
                                    //                     Edit
                                    //                 </Button>
                                    //             </Link>
                                    //           } */}
                                                
                                    //         </td>
                                    //     </tr>
                                    // )
                                    })}

                                </Accordion>
                              </tbody>
                            </Table>
                          </div> : <div>No orders</div>
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

export default OrderComponent;