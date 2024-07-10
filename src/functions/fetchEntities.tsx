import { Customer } from "../types/Customer";


const domain = "https://gym-template.azurewebsites.net/api"; 
// const domain = "http://localhost:7071/api";

const getHeaders = () => {
   return  {
        'Content-Type': 'application/json',
    };
}

const getGETOptions = () => {
    return  {
        method: 'GET',
        headers: getHeaders()
    }
}

const getPOSTOptions = (object: any) => {
    return  {
        method: 'POST',
        headers: getHeaders(),
        body: JSON.stringify(object)
    }
}

export const getTestFunction = async () => {
    const response = await fetch(`${domain}/TestFunction`, getGETOptions())
        .then(response => response.json() as Promise<string>);

    return response;
}

export const getAllCustomers = async () => {
    const response = await fetch(`${domain}/GetAllCustomers`, getGETOptions())
        .then(response => response.json() as Promise<Customer[]>);

    return response;
}

export const searchAllCustomers = async (searchTerm: string) => {
    const response = await fetch(`${domain}/GetAllCustomers?searchTerm=${searchTerm}`, getGETOptions())
        .then(response => response.json() as Promise<Customer[]>);

    return response;
}

export const getCustomerById = async (id: string) => {

    const response = await fetch(`${domain}/GetCustomer/${id}`, getGETOptions())
        .then(response => response.json() as Promise<Customer>);

    return response;
}

export const postCustomer = async (customer: Customer) => {
    const response = await fetch(`${domain}/PostCustomer`, getPOSTOptions(customer));

    return response;
}

export const deleteCustomerById = async (id: string) => {
    await fetch(`${domain}/DeleteCustomer/${id}`, getGETOptions());;
}
