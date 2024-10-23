import { ChangeEvent, useEffect, useState } from 'react'
import { Button, Form } from 'react-bootstrap';
import { useParams, useNavigate } from 'react-router-dom';
import { IngredientRequest } from '../../../types/Ingredient/IngredientRequest';
import { deleteIngredientById, getIngredientById, postIngredient } from '../../../functions/fetchEntities';
import Loading from '../../HelperComponents/Loading';

function EditIngredient() {

    const [hasBeenEdited, setHasBeenEdited] = useState(false);
    const [validated, setValidated] = useState(false);

    const [selectedIngredient, setSelectedIngredient] = useState<IngredientRequest>({ unitOfMeasurement: "g"} as IngredientRequest);

    const navigate = useNavigate();

    const { id } = useParams();
    const parsedId = id !== undefined ? id : "";

    useEffect(() => {

        if (parsedId !== "new") {
            getIngredientById(parsedId)
                .then((data) => setSelectedIngredient(data));
        }

    }, [parsedId]);


    const handleNameChange = (event: ChangeEvent<HTMLInputElement>) => {
        const name = event.target.value;
        setSelectedIngredient({...selectedIngredient, name: name});
        setHasBeenEdited(true);
    }

    const handleCalorieChange = (event: ChangeEvent<HTMLInputElement>) => {
        const calories = event.target.value;
        setSelectedIngredient({...selectedIngredient, calories: parseInt(calories)});
        setHasBeenEdited(true);
    }


    const handleWeightChange = (event: ChangeEvent<HTMLInputElement>) => {
        const weight = event.target.value;
        setSelectedIngredient({...selectedIngredient, weight: parseInt(weight)});
        setHasBeenEdited(true);
    }

    const handleUoMChange = (event: ChangeEvent<HTMLSelectElement>) => {
        const uom = event.target.value;
        setSelectedIngredient({ ...selectedIngredient, unitOfMeasurement: uom });
        setHasBeenEdited(true);
      }


    const handleProteinChange = (event: ChangeEvent<HTMLInputElement>) => {
        const protein = event.target.value;
        setSelectedIngredient({...selectedIngredient, protein: parseInt(protein)});
        setHasBeenEdited(true);
    }

    const handleDelete = async (event:any) => {
        event.preventDefault();

        if(window.confirm(`Are you sure you want to delete ${selectedIngredient.name}`))
        {
            await deleteIngredientById(selectedIngredient.id);
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
                await postIngredient(selectedIngredient);
            }
            navigate('/Food?tab=Ingredients', {replace: true});
        }
        setValidated(true);
    };


    return (
        <>
            {parsedId === "new" || selectedIngredient.id !== undefined ? 
                <div className='page'>
                    <h1>Edit Ingredient</h1>
                    <Form noValidate validated={validated} onSubmit={event => handleSubmit(event)}>

                        <div className='edit-action-btns'>
                            <Button id="save" className='page-btn' variant="primary" type="submit">
                                Save
                            </Button>
                                
                            {parsedId !== "new" && 
                            (
                                <Button id="save" className='page-delete-btn' variant="danger" onClick={handleDelete} >
                                    Delete
                                </Button>
                            )}
                        </div>

                        <div className='form-component'>
                            <Form.Group className="mb-3">
                                    <Form.Label className='form-first-label'>Name</Form.Label>
                                    <Form.Control 
                                    id="edit-name"
                                    type="text" 
                                    placeholder="Name" 
                                    onChange={handleNameChange} 
                                    value={selectedIngredient.name} 
                                    required
                                    />
                                </Form.Group>

                            <Form.Group className="mb-3">
                                    <Form.Label>Weight</Form.Label>
                                    <Form.Control 
                                    id="edit-weight"
                                    type="number" 
                                    placeholder="Weight" 
                                    onChange={handleWeightChange} 
                                    value={selectedIngredient.weight} 
                                    required
                                    />
                            </Form.Group>

                            <Form.Group className="mb-3" controlId="formGender">
                                <Form.Label className='centered'>Unit Of Measurement</Form.Label>
                                <select className="form-select" aria-label="UoM" onChange={handleUoMChange}>
                                <option value={"g"} selected={selectedIngredient.unitOfMeasurement === "g"}>Grams</option>
                                <option value={"ml"} selected={selectedIngredient.unitOfMeasurement === "ml"}>ML</option>
                                </select>
                            </Form.Group>

                            <Form.Group className="mb-3">
                                    <Form.Label>Calories</Form.Label>
                                    <Form.Control 
                                    id="edit-calories"
                                    type="number" 
                                    placeholder="Calories" 
                                    onChange={handleCalorieChange} 
                                    value={selectedIngredient.calories} 
                                    required
                                    />
                            </Form.Group>

                            <Form.Group className="mb-3">
                                    <Form.Label>Protein</Form.Label>
                                    <Form.Control 
                                    id="edit-protein"
                                    type="number" 
                                    placeholder="Protein" 
                                    onChange={handleProteinChange} 
                                    value={selectedIngredient.protein} 
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

export default EditIngredient;