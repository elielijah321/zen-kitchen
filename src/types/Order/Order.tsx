import { Recipe } from "../Recipe/Recipe";

export interface Order {
    id: string;
    createdAt: Date;
    orderDetails: Recipe[];
    name: string;
    phoneNumber: string
}
