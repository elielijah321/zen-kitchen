import { ChangeEvent, useEffect, useState } from 'react'
import { Button, Form, Tab, Tabs } from 'react-bootstrap';
import { useParams, useNavigate } from 'react-router-dom';
import { CaseRequest } from '../../types/Case/CaseRequest';
import { deleteCaseById, getCaseById, postCase } from '../../functions/fetchEntities';
import Loading from '../HelperComponents/Loading';

function EditCase() {

// const state = useSelector((state: RootState) => state.systemUser);
// const systemUser = state.systemUser;

const [hasBeenEdited, setHasBeenEdited] = useState(false);
const [validated, setValidated] = useState(false);

const [selectedCase, setSelectedCase] = useState<CaseRequest>({} as CaseRequest);

const navigate = useNavigate();

const { id } = useParams();
const parsedId = id !== undefined ? id : "";


  useEffect(() => {

    if (parsedId !== "new") {
        getCaseById(parsedId)
            .then((data) => setSelectedCase(data));
    }

    }, [parsedId]);


    const handleTitleChange = (event: ChangeEvent<HTMLInputElement>) => {
        const title = event.target.value;
        setSelectedCase({...selectedCase, title: title});
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


        if(window.confirm(`Are you sure you want to delete ${selectedCase.title}`))
        {
            await deleteCaseById(selectedCase.id);
            navigate('/Cases', {replace: true});
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
                await postCase(selectedCase);
            }
            navigate('/Cases', {replace: true});
        }
        setValidated(true);
    };


  
    return (
        <>
             {parsedId === "new" || selectedCase.id !== undefined ? 
                <div className='page'>
                    <h1>Edit Case</h1>
                    <Form noValidate validated={validated} onSubmit={event => handleSubmit(event)}>

                        <div className='edit-action-btns'>
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
                                    <Form.Label>Case Title</Form.Label>
                                    <Form.Control 
                                    id="edit-name"
                                    type="text" 
                                    placeholder="Case Title" 
                                    onChange={handleTitleChange} 
                                    value={selectedCase.title} 
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

export default EditCase;