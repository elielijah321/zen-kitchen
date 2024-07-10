import { Customer } from "../Customer";
import { BaseRequestModel } from "./BaseRequestModel";

export interface CustomerRequest extends Customer, BaseRequestModel { }