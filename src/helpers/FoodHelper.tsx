import { Ingredient } from "../types/Ingredient/Ingredient";

export const calculateTotalCalories = (ingredients: Ingredient[] | undefined) => {

    if (ingredients === undefined) {
        return 0
    }

    var result = ingredients?.reduce(function (acc, obj) { return acc + obj.calories; }, 0);

    return result;
}

export const calculateTotalProtein = (ingredients: Ingredient[] | undefined) => {

    if (ingredients === undefined) {
        return 0
    }

    var result = ingredients?.reduce(function (acc, obj) { return acc + obj.protein; }, 0);

    return result;
}