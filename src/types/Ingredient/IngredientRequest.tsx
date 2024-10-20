import { BaseRequestModel } from "../RequestModels/BaseRequestModel";
import { Ingredient } from "./Ingredient";

export interface IngredientRequest extends Ingredient, BaseRequestModel { }