import { Defendant } from "../Defendant/Defendant";
import { BaseRequestModel } from "../RequestModels/BaseRequestModel";

export interface DefendantRequest extends Defendant, BaseRequestModel { }