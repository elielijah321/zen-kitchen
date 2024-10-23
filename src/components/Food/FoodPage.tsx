import { Tab, Tabs } from "react-bootstrap";
// import AllergiesComponent from "./Allergy/AllergiesComponent";
import IngredientsComponent from "./Ingredient/IngredientsComponent";
import RecipesComponent from "./Recipes/RecipesComponent";
import MenuComponent from "./Menu/MenuComponent";
import { useLocation } from "react-router-dom";
import { useEffect, useState } from "react";

function FoodPage() {


  const location = useLocation();

  const getDefaultTab = () => {
    const queryParams = new URLSearchParams(location.search);
    return queryParams.get('tab') || 'Menus';
  };

  const [activeTab, setActiveTab] = useState(getDefaultTab());

  

  useEffect(() => {
    setActiveTab(getDefaultTab());
  }, [location]);

  return (
    <>
      <div className='page'>
        <Tabs defaultActiveKey={activeTab} className="mb-3">
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