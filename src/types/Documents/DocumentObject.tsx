export interface DocumentObject {
    id: string;
    name: string;
    caseId: string;
    file: string | ArrayBuffer | null;
    url: string;
}