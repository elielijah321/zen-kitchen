export interface Customer {
    id: string;
    name: string;
    email: string;
    sortCode: string;
    accountNumber: string;
    address_Line1: string;
    address_City: string;
    address_PostalCode: string;
    lastPaymentDate: Date;
    paymentStatus: string;
}