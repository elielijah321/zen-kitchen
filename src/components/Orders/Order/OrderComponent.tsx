import { useEffect, useState } from 'react'
import { Accordion, Table } from 'react-bootstrap';
import { Order } from '../../../types/Order/Order';
import Loading from '../../HelperComponents/Loading';
import { getAllOrders } from '../../../functions/fetchEntities';
import OrderDetailComponent from './OrderDetailComponent';

function OrderComponent() {

  // const state = useSelector((state: RootState) => state.systemUser);
  // const systemUser = state.systemUser;

  const [orders, setOrders] = useState<Order[]>();
  

  useEffect(() => {
    // fetch data
    getAllOrders()
       .then(orders => setOrders(orders));

  }, [])

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