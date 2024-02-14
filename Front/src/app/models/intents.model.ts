export interface Intent {
    id: string;
    createdDate: Date;
    contact: Contact;
    suburb: string;
    category: number;
    description: string;
    price: number;
    status: number;
  }
  
  export interface Contact {
    id: string;
    firstName: string;
    fullName: string;
    phoneNumber: string;
    email: string;
  }  