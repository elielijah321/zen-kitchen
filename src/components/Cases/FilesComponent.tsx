import { ChangeEvent, useEffect, useState } from 'react'
import { Button, Form, Modal, Table } from 'react-bootstrap';
import { DocumentObject } from '../../types/Documents/DocumentObject';
import { useNavigate } from 'react-router-dom';
import { deleteDocument, postDocument, searchAllCaseDocuments } from '../../functions/fetchEntities';

const FilesComponent: React.FC<{caseId: string}> = ({caseId}) => {

    // const state = useSelector((state: RootState) => state.systemUser);
    // const systemUser = state.systemUser;

    const navigate = useNavigate();

    const [showModal, setShowModal] = useState(false);
    const handleClose = () => setShowModal(false);
  
    const toggleModal = () => {
      setShowModal(!showModal);
    }

    const [validated, setValidated] = useState(false);
    const [caseDocument, setCaseDocument] = useState<DocumentObject>({caseId: caseId} as DocumentObject);
    const [documents, setDocuments] = useState<DocumentObject[] | undefined>(undefined);
    const [searchTerm, setSearchTerm] = useState<string>("");



    useEffect(() => {

        searchAllCaseDocuments(caseId, searchTerm)
            .then(data => setDocuments(data));

    }, []);

    
    const handleNameChange = async (event:any) => {
        event.preventDefault();

        const name = event.target.value;
        setCaseDocument({...caseDocument, name: name});
    };

    const handleFileChange = (event: React.ChangeEvent<HTMLInputElement>) => {

        const file = event.target.files;
    
        if(file){
            let reader = new FileReader(); 
            reader.readAsDataURL(file[0]);
    
            reader.onload = () => {

                setCaseDocument({...caseDocument, file: reader.result});
            }
        }
    }

    const handleFileSubmit = async (event:any) => {
        const form = event.currentTarget;
        event.preventDefault();
    
        if (form.checkValidity() === false) {
          event.stopPropagation();
        }else{

            await postDocument(caseDocument);

            await searchAllCaseDocuments(caseId, '')
            .then(data => {
                setDocuments(data);
                handleClose();
            });
        }
    
    };

    const handleSearchChange = (event: ChangeEvent<HTMLInputElement>) => {
        const name = event.target.value;
        setSearchTerm(name);
    
        // searchAllCaseDocuments(name)
        //     .then(document => setDocuments(document));
    }

    const handleDelete = async (documentId: string) => {
        await deleteDocument(documentId).then(() => {
            searchAllCaseDocuments(caseId, '')
                    .then(data => setDocuments(data));
        });
    }

    return (
        <>

            <Modal show={showModal} onHide={handleClose}>
                <Modal.Header closeButton>
                <Modal.Title className='centered'>
                    Upload File 
                </Modal.Title>
                </Modal.Header>
                <Modal.Body>
                <div>
                    <Form noValidate validated={validated} >

                        <Form.Group className="mb-3">
                            <Form.Label>File Name</Form.Label>
                            <Form.Control 
                            id="file-name"
                            type="text" 
                            placeholder="File Name" 
                            onChange={handleNameChange} 
                            value={caseDocument.name} 
                            required
                            />
                        </Form.Group>

                        <Form.Group className="mb-3">
                            <Form.Label>File</Form.Label>
                                <Form.Control 
                                type="file"
                                onChange={handleFileChange} 
                                accept='application/pdf'
                                />
                        </Form.Group>

                    <Button className='submit-form-submit float-right' variant="primary" type="submit" onClick={event => handleFileSubmit(event)}>
                        Save
                    </Button>
                    </Form>
                </div>
                </Modal.Body>
            </Modal>

            <div className='case-document-actions-container'>
                <div>
                    <div>
                        <Form.Group className="mb-3">
                            <Form.Control 
                            id="edit-name"
                            type="text" 
                            placeholder="Search..." 
                            onChange={handleSearchChange} 
                            value={searchTerm} 
                            />
                        </Form.Group>
                    </div>
                </div>
                <div>
                    <Button onClick={toggleModal}>
                        Upload File
                    </Button>
                </div>

            </div>
                
            {documents !== undefined && documents.length > 0 ?
            (
            <div>
                <Table striped hover responsive>
                    <thead>
                        <tr>
                            <th>Name</th>
                            <th></th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody>
                        {documents.map((_document: DocumentObject) => {

                        return (
                            <tr key={_document.id}>
                                <td className='case-title'>{_document.name}</td>
                                <td>
                                    <Button>
                                        <a className='view-document-link' href={_document.url} target='_blank'>
                                            View
                                        </a>
                                    </Button>
                                </td>
                                <td>
                                    <Button variant='danger' onClick={e => handleDelete(_document.id)}>
                                        Delete
                                    </Button>
                                </td>
                            </tr>
                        )
                        })}
                    </tbody>
                </Table>
                </div>
            )
            :  <div>No Documents</div> }
        </>
  )
}

export default FilesComponent;