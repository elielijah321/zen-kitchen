import { ChangeEvent, useEffect, useState } from 'react'
import { Button, Form, Modal, Table } from 'react-bootstrap';
import { useParams, useNavigate } from 'react-router-dom';
import { deleteMenuById, getAllRecipes, getMenuById, postMenu } from '../../../functions/fetchEntities';
import Loading from '../../HelperComponents/Loading';
import { Recipe } from '../../../types/Recipe/Recipe';
import { MenuRequest } from '../../../types/Menu/MenuRequest';
import { MenuItem } from '../../../types/Menu/Menu';

function EditMenu() {

    const [hasBeenEdited, setHasBeenEdited] = useState(false);
    const [validated, setValidated] = useState(false);

    const [selectedMenu, setSelectedMenu] = useState<MenuRequest>({} as MenuRequest);
    const [recipes, setRecipes] = useState<Recipe[]>([]);

    const [selectedRecipes, setSelectedRecipes] = useState<Recipe[]>([]);

    // const [searchTerm, setSearchTerm] = useState<string>("");

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
                getMenuById(parsedId)
                    .then((data) => {
    
                        console.log(data.recipes);
                        setSelectedMenu(data);
                        setSelectedRecipes(data.recipes.map(i => {
                            return i.recipe!;
                        }));
                    });
            }
    
            getAllRecipes()
                .then(recipes => setRecipes(recipes));
        }
    
        loadPage();

        

    }, [parsedId]);





    const handleNameChange = (event: ChangeEvent<HTMLInputElement>) => {
        const name = event.target.value;
        setSelectedMenu({...selectedMenu, name: name});
        setHasBeenEdited(true);
    }


    // const handleSearchChange = (event: ChangeEvent<HTMLInputElement>) => {

    //     const term = event.target.value;

    //     // var _ingredients = ingredients?.filter(i => i.name.includes(term));
        
    //     // setIngredients(_ingredients);
    //     setSearchTerm(term);

    // }

    const toggleSelectedRecipe = (_recipe: Recipe) => {

        let array = selectedRecipes!!;

        var index = array.findIndex(p => p.id === _recipe.id);

        if (index > -1) {
            
            array.splice(index, 1)

        }else{
            array.push(_recipe);
        }

        setSelectedRecipes([...array]);

        var menuItems = array.map(t => {

            var menuItem : MenuItem = { menuId: selectedMenu.id, recipeId: t.id, recipe: undefined };

            return menuItem;
        })

        setSelectedMenu({...selectedMenu, recipes: menuItems});
        setHasBeenEdited(true);

    }

    const handleDelete = async (event:any) => {
        event.preventDefault();

        if(window.confirm(`Are you sure you want to delete ${selectedMenu.name}`))
        {
            await deleteMenuById(selectedMenu.id);
            navigate('/Food?tab=Menus', {replace: true});
        };
    };

    const handleSubmit = async (event:any) => {
        const form = event.currentTarget;
        event.preventDefault();
    
        if (form.checkValidity() === false) {
          event.stopPropagation();
        }else{
            if (hasBeenEdited) {
                await postMenu(selectedMenu);
            }
            navigate('/Food?tab=Menus', {replace: true});
        }
        setValidated(true);
    };


    return (
        <>

        <Modal show={showModal} onHide={handleClose}>
            <Modal.Header closeButton>
            <Modal.Title className='centered'>
                Edit Recipes
            </Modal.Title>
            </Modal.Header>
            <Modal.Body>
                {/* <Form.Group className="mb-3">
                                <Form.Control 
                                type="text" 
                                placeholder="Search..." 
                                onChange={handleSearchChange} 
                                value={searchTerm} 
                                />
                </Form.Group> */}
                {
                    <Table>
                        {
                            recipes?.map((recipe: Recipe) => {

                                return (
                                    selectedRecipes &&
                                    <tr key={recipe.id}>
                                        <td>
                                            <Form.Check checked={selectedRecipes.filter(r => r.id === recipe.id).length > 0} onClick={() => toggleSelectedRecipe(recipe)} />
                                        </td>
                                        <td>
                                            <span>{recipe.name}</span>
                                        </td>
                                    </tr>
                                    )
                            })
                        }
                    </Table>
                }
            </Modal.Body>
        </Modal>

            {parsedId === "new" || selectedMenu.id !== undefined ? 
                <div className='page'>
                    <h1>Edit Menu</h1>
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

                        <div className='page-form'>
                            <Form.Group className="mb-3">
                                    <Form.Label className='form-label form-first-label'>Name</Form.Label>
                                    <Form.Control 
                                    id="edit-name"
                                    type="text" 
                                    placeholder="Name" 
                                    onChange={handleNameChange} 
                                    value={selectedMenu.name} 
                                    required
                                    />
                                </Form.Group>
                        </div>


                        <div className='flex-container'>
                            <div>
                                <Button className='page-btn edit-action-btns' variant="primary" onClick={handleShow}>
                                    Add Recipes
                                </Button>
                            </div>

                            <Table striped hover responsive>
                                <thead>
                                    <tr>
                                        <th>Name</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    {selectedRecipes?.map((recipe: Recipe) => {

                                        return (
                                        <tr key={recipe.id}>
                                            <td>{recipe.name}</td>
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

export default EditMenu;