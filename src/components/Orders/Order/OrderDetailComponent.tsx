import React from 'react'
import { Accordion, Button, Table } from 'react-bootstrap';
import { Order } from '../../../types/Order/Order';
import { getDisplayDate } from '../../../helpers/DateHelper';
import { deleteOrderById } from '../../../functions/fetchEntities';


const OrderDetailComponent: React.FC<{order: Order}> = ({order}) => {


  const handleDelete = async () => {

    if(window.confirm(`Are you sure you want to delete ${order.name}'s order?`))
    {
        await deleteOrderById(order.id);
        window.location.reload();
    };
};


  return (
    <Accordion.Item eventKey={order.name}>
        <div className='order-header'>
          <Accordion.Header>
              <div className='order-header-btn block action-button'>
                {/* <h3 className='centered'>{order.name}</h3> */}
                <Table responsive className='cage-table'>
                  <thead>
                    <tr className='centered'>
                        <th>Date</th> 
                        <th>Name</th> 
                        <th>Phone Number</th> 
                        <th></th> 
                    </tr>
                  </thead>
                  <tbody>
                    <tr>
                      <td>{getDisplayDate(order.createdAt)}</td>
                      <td>{order.name}</td>
                      <td>{order.phoneNumber}</td>
                      <td>
                            <Button id="save" className='order-confirm-btn' variant="danger" onClick={() => handleDelete()} >
                                Delete Order
                            </Button>
                      </td>
                    </tr>
                  </tbody>
              </Table>
              </div>
          </Accordion.Header>
        </div>
        <Accordion.Body>
          <div>
              <Table responsive striped hover>
                  <tbody>
                    {
                      order.orderDetails.map(od => {
                        return (
                        <tr id={od.id}>
                          <td>{od.name}</td>
                        </tr>
                        )
                      })
                    }
                  </tbody>
              </Table>
          </div>
        </Accordion.Body>
    </Accordion.Item>
  );
};

export default OrderDetailComponent;


