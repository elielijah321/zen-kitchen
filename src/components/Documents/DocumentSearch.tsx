import { ChangeEvent, useEffect, useState } from 'react'
import { Form, Table } from 'react-bootstrap';
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
                        <th>Title</th>
                    </tr>
                </thead>
                <tbody>
                    {documents.map((_document: DocumentObject) => {

                      return (
                        <tr key={_document.id}>
                            <td className='case-title'>{_document.id}</td>
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