import { ChangeEvent, useEffect, useState } from 'react'
import { Button, Form, Tab, Tabs } from 'react-bootstrap';
import { useParams, useNavigate } from 'react-router-dom';
import { CustomerRequest } from '../../types/RequestModels/CustomerRequest';
import { deleteCustomerById, getCustomerById, postCustomer } from '../../functions/fetchEntities';
import Loading from '../HelperComponents/Loading';
import { disableTyping, getCalendarDate } from '../../helpers/DateHelper';

function EditCustomer() {

// const state = useSelector((state: RootState) => state.systemUser);
// const systemUser = state.systemUser;

const [hasBeenEdited, setHasBeenEdited] = useState(false);
const [validated, setValidated] = useState(false);

const [selectedCustomer, setSelectedCustomer] = useState<CustomerRequest>({} as CustomerRequest);

const navigate = useNavigate();

const { id } = useParams();
const parsedId = id !== undefined ? id : "";


  useEffect(() => {

    if (parsedId !== "new") {
        getCustomerById(parsedId)
            .then((data) => setSelectedCustomer(data));
    }

    }, [parsedId]);


    const handleNameChange = (event: ChangeEvent<HTMLInputElement>) => {
        const name = event.target.value;
        setSelectedCustomer({...selectedCustomer, name: name});
        setHasBeenEdited(true);
    }

    const handleEmailChange = (event: ChangeEvent<HTMLInputElement>) => {
        const email = event.target.value;
        setSelectedCustomer({...selectedCustomer, email: email});
        setHasBeenEdited(true);
    }

    const handleSortCodeChange = (event: ChangeEvent<HTMLInputElement>) => {
        const sortCode = event.target.value;
        setSelectedCustomer({...selectedCustomer, sortCode: sortCode});
        setHasBeenEdited(true);
    }

    const handleAccountNumberChange = (event: ChangeEvent<HTMLInputElement>) => {
        const accountNumber = event.target.value;
        setSelectedCustomer({...selectedCustomer, accountNumber: accountNumber});
        setHasBeenEdited(true);
    }

    const handleAddressLine1Change = (event: ChangeEvent<HTMLInputElement>) => {
        const addressLine1 = event.target.value;
        setSelectedCustomer({...selectedCustomer, address_Line1: addressLine1});
        setHasBeenEdited(true);
    }

    const handleAddressCityChange = (event: ChangeEvent<HTMLInputElement>) => {
        const city = event.target.value;
        setSelectedCustomer({...selectedCustomer, address_City: city});
        setHasBeenEdited(true);
    }

    const handleAddressPostCodeChange = (event: ChangeEvent<HTMLInputElement>) => {
        const postCode = event.target.value;
        setSelectedCustomer({...selectedCustomer, address_PostalCode: postCode});
        setHasBeenEdited(true);
    }

    const handleDateChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        const date = new Date(event.target.value);
        setSelectedCustomer({...selectedCustomer, lastPaymentDate: date});

        setHasBeenEdited(true);
    }

 
    /*
  
    const handleClassChange = (event: ChangeEvent<HTMLSelectElement>) => {
        const classId = event.target.value;
        setSelectedStudent({...selectedStudent, classId: classId});
        setHasBeenEdited(true);
    }

    const handleDOBChange = (event: ChangeEvent<HTMLInputElement>) => {
        const dob = new Date(event.target.value);
        setSelectedStudent({...selectedStudent, dob: dob});
        setHasBeenEdited(true);
    }

    const handleDateLeftChange = (event: ChangeEvent<HTMLInputElement>) => {
        const dateLeft = new Date(event.target.value);
        setSelectedStudent({...selectedStudent, dateLeft: dateLeft});
        setHasBeenEdited(true);
    }

    const handleScholarshipTypeChange = (event: ChangeEvent<HTMLSelectElement>) => {
        const scholarshipType = event.target.value;
        setSelectedStudent({...selectedStudent, scholarshipType: scholarshipType});
        setHasBeenEdited(true);
    }

    */

    const handleDelete = async (event:any) => {
        event.preventDefault();


        if(window.confirm(`Are you sure you want to delete ${selectedCustomer.name}`))
        {
            await deleteCustomerById(selectedCustomer.id);
            navigate('/Customers', {replace: true});
        };

    };

    const handleSubmit = async (event:any) => {
        const form = event.currentTarget;
        event.preventDefault();
    
        if (form.checkValidity() === false) {
          event.stopPropagation();
        }else{
            if (hasBeenEdited) {
                // selectedStudent.updatedBy = systemUser.displayName;
                await postCustomer(selectedCustomer);
            }
            navigate('/Customers', {replace: true});
        }
        setValidated(true);
    };


  
    return (
        <>
             {parsedId === "new" || selectedCustomer.id !== undefined ? 
                <div className='page'>
                    <h1>Edit Customer</h1>
                    <Form noValidate validated={validated} onSubmit={event => handleSubmit(event)}>

                        <div className='edit-customer-action-btns'>
                            <Button id="save" className='edit-form-submit' variant="primary" type="submit">
                                Save
                            </Button>
                                
                            {parsedId !== "new" && 
                            (
                                <Button id="save" className='edit-form-submit' variant="danger" onClick={handleDelete} >
                                    Delete
                                </Button>
                            )}
                        </div>

                        <Tabs defaultActiveKey="profile" className="mb-3">
                            <Tab eventKey="profile" title="Profile">
                                <Form.Group className="mb-3">
                                    <Form.Label>Customer Name</Form.Label>
                                    <Form.Control 
                                    id="edit-name"
                                    type="text" 
                                    placeholder="Customer Name" 
                                    onChange={handleNameChange} 
                                    value={selectedCustomer.name} 
                                    required
                                    />
                                </Form.Group>

                                <Form.Group className="mb-3">
                                    <Form.Label>E-mail</Form.Label>
                                    <Form.Control 
                                    id="edit-email"
                                    type="text" 
                                    placeholder="E-mail" 
                                    onChange={handleEmailChange} 
                                    value={selectedCustomer.email} 
                                    required
                                    />
                                </Form.Group>

                                <Form.Group className="mb-3">
                                    <Form.Label>Address Line 1</Form.Label>
                                    <Form.Control 
                                    id="edit-address-line-1"
                                    type="text" 
                                    placeholder="Address Line 1" 
                                    onChange={handleAddressLine1Change} 
                                    value={selectedCustomer.address_Line1} 
                                    required
                                    />
                                </Form.Group>

                                <Form.Group className="mb-3">
                                    <Form.Label>City</Form.Label>
                                    <Form.Control 
                                    id="edit-city"
                                    type="text" 
                                    placeholder="City" 
                                    onChange={handleAddressCityChange} 
                                    value={selectedCustomer.address_City} 
                                    required
                                    />
                                </Form.Group>

                                <Form.Group className="mb-3">
                                    <Form.Label>Postcode</Form.Label>
                                    <Form.Control 
                                    id="edit-post-code"
                                    type="text" 
                                    placeholder="Post Code" 
                                    onChange={handleAddressPostCodeChange} 
                                    value={selectedCustomer.address_PostalCode} 
                                    required
                                    />
                                </Form.Group>
                            </Tab>
                            <Tab eventKey="payment" title="Payment Details">
                                <Form.Group className="mb-3">
                                    <Form.Label>Sort Code</Form.Label>
                                    <Form.Control 
                                    id="edit-sort-code"
                                    type="text" 
                                    placeholder="Sort Code" 
                                    onChange={handleSortCodeChange} 
                                    value={selectedCustomer.sortCode} 
                                    required
                                    />
                                </Form.Group>

                                <Form.Group className="mb-3">
                                    <Form.Label>Account Number</Form.Label>
                                    <Form.Control 
                                    id="edit-account-number"
                                    type="text" 
                                    placeholder="Account Number" 
                                    onChange={handleAccountNumberChange} 
                                    value={selectedCustomer.accountNumber} 
                                    required
                                    />
                                </Form.Group>

                                <Form.Group className="mb-3">
                                    <Form.Label>Last Payment Date</Form.Label>
                                    <Form.Control 
                                    type="date" 
                                    placeholder="Date" 
                                    value={getCalendarDate(selectedCustomer.lastPaymentDate)} 
                                    onChange={handleDateChange} 
                                    onKeyDown={(e) => disableTyping(e)}
                                    />
                                </Form.Group>
                            </Tab>
                        </Tabs>
                    </Form>
                </div> 
                : 
                <Loading /> 
            }
        </>
  )
}

export default EditCustomer;