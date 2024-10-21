import { Recipe } from "../Recipe/Recipe";

export interface Order {
    createdAt: Date;
    orderDetails: Recipe[];
    name: string;
    phoneNumber: string
}
