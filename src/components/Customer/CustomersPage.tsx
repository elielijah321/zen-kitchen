import { ChangeEvent, useEffect, useState } from 'react'
import { Accordion, Button, Form, Table } from 'react-bootstrap';
import { Link } from 'react-router-dom';
import { canEdit } from '../../helpers/UserHelper';
import { Customer } from '../../types/Customer';
import Loading from '../HelperComponents/Loading';
import { getAllCustomers, searchAllCustomers } from '../../functions/fetchEntities';
import { getDisplayDate } from '../../helpers/DateHelper';

function CustomersPage() {

  // const state = useSelector((state: RootState) => state.systemUser);
  // const systemUser = state.systemUser;

  const [customers, setCustomers] = useState<Customer[] | undefined>(undefined);
  const [searchTerm, setSearchTerm] = useState<string>("");


  const handleSearchChange = (event: ChangeEvent<HTMLInputElement>) => {
    const name = event.target.value;
    setSearchTerm(name);

    if(name === "")
    {
      getAllCustomers()
        .then(customers => setCustomers(customers));

    }else{
      searchAllCustomers(name)
      .then(customers => setCustomers(customers));
    }
    
  }

  useEffect(() => {
    // fetch data
    getAllCustomers()
      .then(customers => setCustomers(customers));
  }, [])

  return (
    <>
      <div className='page'>
        <div className='entity-button-container'>
          <div className='search-customer-input'>
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
                  <Link className="navitem" to="/Customer/new">
                      <Button variant="primary" className="mb-3">
                          Add Customer
                      </Button>
                  </Link>
              </div>
            }
        </div>
        
        {customers !== undefined ?
        (
          <div>
            <Accordion defaultActiveKey={"customers"}>
                <Accordion.Item key={"customers"} eventKey={"customers"}>
                        <Accordion.Header>{"Customers"}</Accordion.Header>
                        <Accordion.Body>
                          {
                          customers.length > 0 ? 
                          <div>
                            <Table striped hover responsive>
                              <thead>
                                  <tr>
                                      <th>Name</th>
                                      <th>E-mail</th>
                                      <th>Payment Status</th>
                                      <th>Last Payment Date</th>
                                      <th></th>
                                  </tr>
                              </thead>
                              <tbody>
                                  {customers.map((customer: Customer) => {

                                    return (
                                      <tr key={customer.id}>
                                          <td className='customer-name'>{customer.name}</td>
                                          <td className='customer-email'>{customer.email}</td>
                                          <td className='customer-payment-status'>{customer.paymentStatus}</td>
                                          <td className='customer-last-payment'>{getDisplayDate(customer.lastPaymentDate)}</td>
                                          <td>
                                            {
                                              <Link to={`/Customer/${customer.id}`} className="button">
                                                  <Button id={`${customer.name}-btn`}>
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
                          </div> : <div>No customers</div>
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

export default CustomersPage;