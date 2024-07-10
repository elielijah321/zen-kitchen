import { ChangeEvent, useEffect, useState } from 'react'
import { Button, Form, Tab, Tabs } from 'react-bootstrap';
import { useParams, useNavigate } from 'react-router-dom';
import { DefendantRequest } from '../../types/Defendant/DefendantRequest';
import { deleteDefendantById, getDefendantById, postDefendant } from '../../functions/fetchEntities';
import Loading from '../HelperComponents/Loading';

function EditDefendant() {

// const state = useSelector((state: RootState) => state.systemUser);
// const systemUser = state.systemUser;

const [hasBeenEdited, setHasBeenEdited] = useState(false);
const [validated, setValidated] = useState(false);

const [selectedDefendant, setSelectedDefendant] = useState<DefendantRequest>({} as DefendantRequest);

const navigate = useNavigate();

const { id } = useParams();
const parsedId = id !== undefined ? id : "";


  useEffect(() => {

    if (parsedId !== "new") {
        getDefendantById(parsedId)
            .then((data) => setSelectedDefendant(data));
    }

    }, [parsedId]);


    const handleNameChange = (event: ChangeEvent<HTMLInputElement>) => {
        const name = event.target.value;
        setSelectedDefendant({...selectedDefendant, name: name});
        setHasBeenEdited(true);
    }

    const handleEmailChange = (event: ChangeEvent<HTMLInputElement>) => {
        const email = event.target.value;
        setSelectedDefendant({...selectedDefendant, email: email});
        setHasBeenEdited(true);
    }

    const handleAddressLine1Change = (event: ChangeEvent<HTMLInputElement>) => {
        const addressLine1 = event.target.value;
        setSelectedDefendant({...selectedDefendant, address_Line1: addressLine1});
        setHasBeenEdited(true);
    }

    const handleAddressCityChange = (event: ChangeEvent<HTMLInputElement>) => {
        const city = event.target.value;
        setSelectedDefendant({...selectedDefendant, address_City: city});
        setHasBeenEdited(true);
    }

    const handleAddressPostCodeChange = (event: ChangeEvent<HTMLInputElement>) => {
        const postCode = event.target.value;
        setSelectedDefendant({...selectedDefendant, address_PostalCode: postCode});
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


        if(window.confirm(`Are you sure you want to delete ${selectedDefendant.name}`))
        {
            await deleteDefendantById(selectedDefendant.id);
            navigate('/Defendants', {replace: true});
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
                await postDefendant(selectedDefendant);
            }
            navigate('/Defendants', {replace: true});
        }
        setValidated(true);
    };


  
    return (
        <>
             {parsedId === "new" || selectedDefendant.id !== undefined ? 
                <div className='page'>
                    <h1>Edit Defendant</h1>
                    <Form noValidate validated={validated} onSubmit={event => handleSubmit(event)}>

                        <div className='edit-Defendant-action-btns'>
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
                                    <Form.Label>Defendant Name</Form.Label>
                                    <Form.Control 
                                    id="edit-name"
                                    type="text" 
                                    placeholder="Defendant Name" 
                                    onChange={handleNameChange} 
                                    value={selectedDefendant.name} 
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
                                    value={selectedDefendant.email} 
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
                                    value={selectedDefendant.address_Line1} 
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
                                    value={selectedDefendant.address_City} 
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
                                    value={selectedDefendant.address_PostalCode} 
                                    required
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

export default EditDefendant;