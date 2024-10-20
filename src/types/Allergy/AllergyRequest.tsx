import { BaseRequestModel } from "../RequestModels/BaseRequestModel";
import { Allergy } from "./Allergy";

export interface AllergyRequest extends Allergy, BaseRequestModel { }