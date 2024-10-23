import { ChangeEvent, useEffect, useState } from 'react'
import { Button, Form, Modal, Table } from 'react-bootstrap';
import { useParams, useNavigate } from 'react-router-dom';
import { deleteRecipeById, getAllIngredients, getRecipeById, postRecipe } from '../../../functions/fetchEntities';
import Loading from '../../HelperComponents/Loading';
import { RecipeRequest } from '../../../types/Recipe/RecipeRequest';
import { Ingredient } from '../../../types/Ingredient/Ingredient';
import { RecipeItem } from '../../../types/Recipe/Recipe';
import { calculateTotalCalories, calculateTotalProtein } from '../../../helpers/FoodHelper';

function EditRecipe() {

    const [hasBeenEdited, setHasBeenEdited] = useState(false);
    const [validated, setValidated] = useState(false);

    const [selectedRecipe, setSelectedRecipe] = useState<RecipeRequest>({} as RecipeRequest);
    const [ingredients, setIngredients] = useState<Ingredient[]>([]);


    const [selectedIngredients, setSelectedIngredients] = useState<Ingredient[]>([]);

    const [searchTerm, setSearchTerm] = useState<string>("");

    const [showModal, setShowModal] = useState(false);
    const handleClose = () => setShowModal(false);
    const handleShow = () => {

        setShowModal(true);
    };


    const navigate = useNavigate();

    const { id } = useParams();
    const parsedId = id !== undefined ? id : "";

    useEffect(() => {


        const loadPage = async () =>  {
            
            if (parsedId !== "new") {
                getRecipeById(parsedId)
                    .then((data) => {
    
                        setSelectedRecipe(data);
                        setSelectedIngredients(data.ingredients.map(i => {
    
                            return i.ingredient!;
                        }));
                    });
            }
    
            getAllIngredients()
                .then(ingredients => setIngredients(ingredients));
        }
    
        loadPage();

        

    }, [parsedId]);





    const handleNameChange = (event: ChangeEvent<HTMLInputElement>) => {
        const name = event.target.value;
        setSelectedRecipe({...selectedRecipe, name: name});
        setHasBeenEdited(true);
    }


    const handleSearchChange = (event: ChangeEvent<HTMLInputElement>) => {

        const term = event.target.value;

        var _ingredients = ingredients?.filter(i => i.name.includes(term));
        
        setIngredients(_ingredients);
        setSearchTerm(term);

    }

    const toggleSelectedIngredient = (_ingredient: Ingredient) => {

        let array = selectedIngredients!!;

        var index = array.findIndex(p => p.id === _ingredient.id);

        if (index > -1) {
            
            array.splice(index, 1)

        }else{
            array.push(_ingredient);
        }

        setSelectedIngredients([...array]);

        var recipeItems = array.map(t => {

            var recipeItem : RecipeItem = { ingredientId: t.id, recipeId: selectedRecipe.id, ingredient: undefined };

            return recipeItem;
        })

        setSelectedRecipe({...selectedRecipe, ingredients: recipeItems});
        setHasBeenEdited(true);

    }

    const handleDelete = async (event:any) => {
        event.preventDefault();

        if(window.confirm(`Are you sure you want to delete ${selectedRecipe.name}`))
        {
            await deleteRecipeById(selectedRecipe.id);
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
                await postRecipe(selectedRecipe);
            }
            navigate('/Food', {replace: true});
        }
        setValidated(true);
    };


    return (
        <>

        <Modal show={showModal} onHide={handleClose}>
            <Modal.Header closeButton>
            <Modal.Title className='centered'>
                Edit Ingredients
            </Modal.Title>
            </Modal.Header>
            <Modal.Body>
                <Form.Group className="mb-3">
                                <Form.Control 
                                type="text" 
                                placeholder="Search..." 
                                onChange={handleSearchChange} 
                                value={searchTerm} 
                                />
                </Form.Group>
                {
                    <Table>
                        {
                            ingredients?.map((ingredient: Ingredient) => {

                                console.log(selectedIngredients);

                                return (
                                    selectedIngredients &&
                                    <tr key={ingredient.id}>
                                        <td>
                                            <Form.Check checked={selectedIngredients.filter(i => i.id === ingredient.id).length > 0} onClick={() => toggleSelectedIngredient(ingredient)} />
                                        </td>
                                        <td>
                                            <span>{ingredient.name}</span>
                                        </td>
                                    </tr>
                                    )
                            })
                        }
                    </Table>
                }
            </Modal.Body>
        </Modal>

            {parsedId === "new" || selectedRecipe.id !== undefined ? 
                <div className='page'>
                    <h1>Edit Recipe</h1>
                    <Form noValidate validated={validated} onSubmit={event => handleSubmit(event)}>

                        <div className='flex-container'>
                                <div>
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
                                </div>

                                <Table className='recipe-information-info margin-top-20' hover responsive>
                                    <tbody>
                                        <tr>
                                            <td>Total Calories</td>
                                            <td>{calculateTotalCalories(selectedIngredients!!)}</td>
                                        </tr>
                                        <tr>
                                            <td>Total Protein</td>
                                            <td>{calculateTotalProtein(selectedIngredients!!)}</td>
                                        </tr>
                                    </tbody>
                                </Table>
                        </div>


                        
                        <div className='page-form'>

                            <Form.Group className="mb-3">
                                    <Form.Label>Name</Form.Label>
                                    <Form.Control 
                                    id="edit-name"
                                    type="text" 
                                    placeholder="Name" 
                                    onChange={handleNameChange} 
                                    value={selectedRecipe.name} 
                                    required
                                    />
                                </Form.Group>
                        </div>

                        <div className='flex-container'>

                            <div className='edit-ingredient-btn'>
                                    <Button className='page-btn  edit-action-btns'  variant="primary" onClick={handleShow}>
                                        Add Ingredients
                                    </Button>
                                </div>

                                <Table className='margin-top-20' striped hover responsive>
                                    <thead>
                                        <tr>
                                            <th>Name</th>
                                            <th>Calories</th>
                                            <th>Protein</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        {selectedIngredients?.map((ingredient: Ingredient) => {

                                            return (
                                            <tr key={ingredient.id}>
                                                <td>{ingredient.name}</td>
                                                <td>{ingredient.calories}</td>
                                                <td>{ingredient.protein}</td>
                                            </tr>
                                        )
                                        })}
                                    </tbody>
                                </Table>



                        </div>
                    </Form>
                </div> 
                : 
                <Loading /> 
            }
        </>
  )
}

export default EditRecipe;