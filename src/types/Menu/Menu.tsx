import { Recipe } from "../Recipe/Recipe";

export interface Menu {
    id: string;
    name: string;
    recipes: MenuItem[];
}


export interface MenuItem {
    menuId: string;
    recipeId: string;
    recipe: Recipe | undefined;
}