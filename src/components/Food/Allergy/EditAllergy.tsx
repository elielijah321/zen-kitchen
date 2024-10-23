import { ChangeEvent, useEffect, useState } from 'react'
import { Button, Form } from 'react-bootstrap';
import { useParams, useNavigate } from 'react-router-dom';
import Loading from '../../HelperComponents/Loading';
import { deleteAllergyById, getAllergyById, postAllergy } from '../../../functions/fetchEntities';
import { AllergyRequest } from '../../../types/Allergy/AllergyRequest';

function EditAllergy() {

    const [hasBeenEdited, setHasBeenEdited] = useState(false);
    const [validated, setValidated] = useState(false);

    const [selectedAllergy, setSelectedAllergy] = useState<AllergyRequest>({} as AllergyRequest);

    const navigate = useNavigate();

    const { id } = useParams();
    const parsedId = id !== undefined ? id : "";

    useEffect(() => {

        if (parsedId !== "new") {
            getAllergyById(parsedId)
                .then((data) => setSelectedAllergy(data));
        }

    }, [parsedId]);


    const handleNameChange = (event: ChangeEvent<HTMLInputElement>) => {
        const name = event.target.value;
        setSelectedAllergy({...selectedAllergy, name: name});
        setHasBeenEdited(true);
    }

    const handleDelete = async (event:any) => {
        event.preventDefault();

        if(window.confirm(`Are you sure you want to delete ${selectedAllergy.name}`))
        {
            await deleteAllergyById(selectedAllergy.id);
            navigate('/Food', {replace: true});
        };
    };

    const handleSubmit = async (event:any) => {
        const form = event.currentTarget;
        event.preventDefault();
    
        if (form.checkValidity() === false) {
          event.stopPropagation();
        }else{
            if (hasBeenEdited) {
                await postAllergy(selectedAllergy);
            }
            navigate('/Food', {replace: true});
        }
        setValidated(true);
    };


    return (
        <>
            {parsedId === "new" || selectedAllergy.id !== undefined ? 
                <div className='page'>
                    <h1>Edit Allergy</h1>
                    <Form noValidate validated={validated} onSubmit={event => handleSubmit(event)}>

                        <div className='page-btn'>
                            <Button id="save" className='page-btn' variant="primary" type="submit">
                                Save
                            </Button>
                                
                            {parsedId !== "new" && 
                            (
                                <Button id="save" className='edit-form-submit' variant="danger" onClick={handleDelete} >
                                    Delete
                                </Button>
                            )}
                        </div>

                        <div className='page'>
                            <Form.Group className="mb-3">
                                    <Form.Label>Name</Form.Label>
                                    <Form.Control 
                                    id="edit-name"
                                    type="text" 
                                    placeholder="Name" 
                                    onChange={handleNameChange} 
                                    value={selectedAllergy.name} 
                                    required
                                    />
                                </Form.Group>
                        </div>
                    </Form>
                </div> 
                : 
                <Loading /> 
            }
        </>
  )
}

export default EditAllergy;