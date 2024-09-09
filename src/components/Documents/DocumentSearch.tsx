import { ChangeEvent, useEffect, useState } from 'react'
import { Button, Form, Table } from 'react-bootstrap';
import { searchAllDocuments } from '../../functions/fetchEntities';
import { DocumentObject } from '../../types/Documents/DocumentObject';

function DocumentSearch() {

  // const state = useSelector((state: RootState) => state.systemUser);
  // const systemUser = state.systemUser;

  const [documents, setDocuments] = useState<DocumentObject[] | undefined>(undefined);
  const [searchTerm, setSearchTerm] = useState<string>("");


  const handleSearchChange = (event: ChangeEvent<HTMLInputElement>) => {
    const name = event.target.value;
    setSearchTerm(name);

    searchAllDocuments(name)
        .then(document => setDocuments(document));
  }

  useEffect(() => {
    // fetch data
    // getAllCases()
    //   .then(document => setDocuments(document));
  }, [])

  return (
    <>
      <div className='page'>
        <div className='entity-button-container'>
          <div className='search-input'>
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
        </div>
        
        {documents !== undefined && documents.length > 0 ?
        (
          <div>
              <Table striped hover responsive>
                <thead>
                    <tr>
                        <th>File Name</th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>
                    {documents.map((_document: DocumentObject) => {

                      return (
                        <tr key={_document.id}>
                            <td className='case-name'>{_document.name}</td>
                            <td className='document-link'>
                              {
                                <Button>
                                    <a className='view-document-link' href={_document.url} target='_blank'>
                                        View
                                    </a>
                                </Button>
                              }
                            </td>
                        </tr>
                      )
                    })}
                </tbody>
              </Table>
            </div>
        )
        :  <div>No Documents</div> }

      </div>
    </>
  )
}

export default DocumentSearch;