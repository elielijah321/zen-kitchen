import { BaseRequestModel } from "../RequestModels/BaseRequestModel";
import { Recipe } from "./Recipe";

export interface RecipeRequest extends Recipe, BaseRequestModel { }