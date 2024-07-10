import { BaseRequestModel } from "../RequestModels/BaseRequestModel";
import { Case } from "./Case";

export interface CaseRequest extends Case, BaseRequestModel { }