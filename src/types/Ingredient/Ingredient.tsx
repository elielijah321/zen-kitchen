export interface Ingredient {
    id: string;
    name: string;
    calories: number;
    protein: number;
    weight: number;
    unitOfMeasurement: string;
}


export interface ShoppingListItem {
    ingredientName: string;
    quantity: number;
    totalAmountNeeded: number;
    unitOfMeasurement: string;
} 