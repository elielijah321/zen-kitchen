import React from 'react'
import { Accordion, Table } from 'react-bootstrap';
import { Order } from '../../types/Order/Order';
import { getDisplayDate } from '../../helpers/DateHelper';


const OrderDetailComponent: React.FC<{order: Order}> = ({order}) => {


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
                    </tr>
                  </thead>
                  <tbody>
                    <tr>
                      <td>{getDisplayDate(order.createdAt)}</td>
                      <td>{order.name}</td>
                      <td>{order.phoneNumber}</td>
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
                        <tr>
                          <td>{od}</td>
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


