import { Case } from "../types/Case/Case";
import { Defendant } from "../types/Defendant/Defendant";
import { DocumentObject } from "../types/Documents/DocumentObject";


// const domain = "https://court-app-template.azurewebsites.net/api"; 
const domain = "http://localhost:7071/api";

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

export const getAllDefendants = async () => {
    const response = await fetch(`${domain}/GetAllDefendants`, getGETOptions())
        .then(response => response.json() as Promise<Defendant[]>);

    return response;
}

export const searchAllDefendants = async (searchTerm: string) => {
    const response = await fetch(`${domain}/GetAllDefendants?searchTerm=${searchTerm}`, getGETOptions())
        .then(response => response.json() as Promise<Defendant[]>);

    return response;
}

export const getDefendantById = async (id: string) => {

    const response = await fetch(`${domain}/GetDefendant/${id}`, getGETOptions())
        .then(response => response.json() as Promise<Defendant>);

    return response;
}

export const postDefendant = async (defendant: Defendant) => {
    const response = await fetch(`${domain}/PostDefendant`, getPOSTOptions(defendant));

    return response;
}

export const deleteDefendantById = async (id: string) => {
    await fetch(`${domain}/DeleteDefendant/${id}`, getGETOptions());;
}


export const getAllCases = async () => {
    const response = await fetch(`${domain}/GetAllCases`, getGETOptions())
        .then(response => response.json() as Promise<Case[]>);

    return response;
}

export const searchAllCases = async (searchTerm: string) => {
    const response = await fetch(`${domain}/GetAllCases?searchTerm=${searchTerm}`, getGETOptions())
        .then(response => response.json() as Promise<Case[]>);

    return response;
}

export const searchAllDocuments = async (searchTerm: string) => {
    const response = await fetch(`${domain}/GetAllDocuments?searchTerm=${searchTerm}`, getGETOptions())
        .then(response => response.json() as Promise<DocumentObject[]>);

    return response;
}

export const searchAllCaseDocuments = async (caseId: string, searchTerm: string) => {
    const response = await fetch(`${domain}/GetCaseDocuments/${caseId}?searchTerm=${searchTerm}`, getGETOptions())
        .then(response => response.json() as Promise<DocumentObject[]>);

    return response;
}

export const postDocument = async (documentObject: DocumentObject) => {
    const response = await fetch(`${domain}/PostDocument`, getPOSTOptions(documentObject));

    return response;
}

export const getCaseById = async (id: string) => {

    const response = await fetch(`${domain}/GetCase/${id}`, getGETOptions())
        .then(response => response.json() as Promise<Case>);

    return response;
}

export const postCase = async (_case: Case) => {
    const response = await fetch(`${domain}/PostCase`, getPOSTOptions(_case));

    return response;
}

export const deleteCaseById = async (id: string) => {
    await fetch(`${domain}/DeleteCase/${id}`, getGETOptions());;
}
