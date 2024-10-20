import { Allergy } from "../types/Allergy/Allergy";
import { Ingredient } from "../types/Ingredient/Ingredient";
import { Menu } from "../types/Menu/Menu";
import { Order } from "../types/Order/Order";
import { Recipe } from "../types/Recipe/Recipe";
import { Setting } from "../types/Setting/Setting";


const domain = "https://zenkitchen.azurewebsites.net/api"; 
// const domain = "http://localhost:7071/api";

const getHeaders = () => {
   return  {
        'Content-Type': 'application/json',
    };
}

const getGETOptions = () => {
    return  {
        method: 'GET',
        headers: getHeaders()
    }
}

const getPOSTOptions = (object: any) => {
    return  {
        method: 'POST',
        headers: getHeaders(),
        body: JSON.stringify(object)
    }
}

// Allergies
export const getAllAllergies = async () => {
    const response = await fetch(`${domain}/GetAllAllergies`, getGETOptions())
        .then(response => response.json() as Promise<Allergy[]>);

    return response;
}

export const getAllergyById = async (id: string) => {

    const response = await fetch(`${domain}/GetAllergy/${id}`, getGETOptions())
        .then(response => response.json() as Promise<Allergy>);

    return response;
}

export const postAllergy = async (entity: Allergy) => {
    const response = await fetch(`${domain}/PostAllergy`, getPOSTOptions(entity));

    return response;
}

export const deleteAllergyById = async (id: string) => {
    await fetch(`${domain}/DeleteAllergy/${id}`, getGETOptions());;
}


// Ingredients
export const getAllIngredients = async () => {
    const response = await fetch(`${domain}/GetAllIngredients`, getGETOptions())
        .then(response => response.json() as Promise<Ingredient[]>);

    return response;
}

export const getIngredientById = async (id: string) => {

    const response = await fetch(`${domain}/GetIngredient/${id}`, getGETOptions())
        .then(response => response.json() as Promise<Ingredient>);

    return response;
}

export const postIngredient = async (entity: Ingredient) => {
    const response = await fetch(`${domain}/PostIngredient`, getPOSTOptions(entity));

    return response;
}

export const deleteIngredientById = async (id: string) => {
    await fetch(`${domain}/DeleteIngredient/${id}`, getGETOptions());;
}


// Recipes
export const getAllRecipes = async () => {
    const response = await fetch(`${domain}/GetAllRecipes`, getGETOptions())
        .then(response => response.json() as Promise<Recipe[]>);

    return response;
}

export const getRecipeById = async (id: string) => {

    const response = await fetch(`${domain}/GetRecipe/${id}`, getGETOptions())
        .then(response => response.json() as Promise<Recipe>);

    return response;
}

export const postRecipe = async (entity: Recipe) => {
    const response = await fetch(`${domain}/PostRecipe`, getPOSTOptions(entity));

    return response;
}

export const deleteRecipeById = async (id: string) => {
    await fetch(`${domain}/DeleteRecipe/${id}`, getGETOptions());;
}


// Menus
export const getAllMenus = async () => {
    const response = await fetch(`${domain}/GetAllMenus`, getGETOptions())
        .then(response => response.json() as Promise<Menu[]>);

    return response;
}

export const getMenuById = async (id: string) => {

    const response = await fetch(`${domain}/GetMenu/${id}`, getGETOptions())
        .then(response => response.json() as Promise<Menu>);

    return response;
}

export const postMenu = async (entity: Menu) => {
    const response = await fetch(`${domain}/PostMenu`, getPOSTOptions(entity));

    return response;
}

export const deleteMenuById = async (id: string) => {
    await fetch(`${domain}/DeleteMenu/${id}`, getGETOptions());;
}

export const postCurrentMenu = async (entity: Menu) => {
    const response = await fetch(`${domain}/PostCurrentMenu`, getPOSTOptions(entity));

    return response;
}

export const getCurrentMenuId = async () => {

    const response = await fetch(`${domain}/GetCurrentMenuId`, getGETOptions())
        .then(response => response.json() as Promise<string>);

    return response;
}

// Settings
export const getSettingById = async (settingId: string) => {
    const response = await fetch(`${domain}/GetSetting/${settingId}`, getGETOptions())
        .then(response => response.json() as Promise<Setting>);

    return response;
}

export const getAllSettings = async () => {
    const response = await fetch(`${domain}/GetSettings`, getGETOptions())
    .then(response => response.json() as Promise<Setting[]>);

    return response;
}

export const postSetting = async (setting: Setting) => {
    const response = await fetch(`${domain}/PostSetting`, getPOSTOptions(setting));

    return response;
}


// Order
export const getOrderById = async (orderId: string) => {
    const response = await fetch(`${domain}/GetOrder/${orderId}`, getGETOptions())
        .then(response => response.json() as Promise<Order>);

    return response;
}

export const getAllOrders = async () => {
    const response = await fetch(`${domain}/GetOrders`, getGETOptions())
    .then(response => response.json() as Promise<Order[]>);

    return response;
}