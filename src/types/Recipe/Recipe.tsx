import { Ingredient } from "../Ingredient/Ingredient";

export interface Recipe {
    id: string;
    name: string;
    ingredients: RecipeItem[];
    price: number;
}


export interface RecipeItem {
    ingredientId: string;
    recipeId: string;
    ingredient: Ingredient | undefined;
}