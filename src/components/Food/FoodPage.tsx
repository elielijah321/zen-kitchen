import { Tab, Tabs } from "react-bootstrap";
// import AllergiesComponent from "./Allergy/AllergiesComponent";
import IngredientsComponent from "./Ingredient/IngredientsComponent";
import RecipesComponent from "./Recipes/RecipesComponent";
import MenuComponent from "./Menu/MenuComponent";

function FoodPage() {

  return (
    <>
      <div className='page'>
        <Tabs defaultActiveKey={"Menus"} className="mb-3">
          <Tab eventKey="Menus" title="Menus">
            <MenuComponent />
          </Tab>
          <Tab eventKey="Recipes" title="Recipes">
            <RecipesComponent />
          </Tab>
          <Tab eventKey="Ingredients" title="Ingredients">
            <IngredientsComponent />
          </Tab>
          {/* <Tab eventKey="Allergies" title="Allergies">
            <AllergiesComponent />
          </Tab> */}
        </Tabs>
      </div>
    </>
  )
}

export default FoodPage;