// intents.model.ts
export interface Intent {
    id: string;
    contact: Contact;
    suburb: string;
    category: string;
    description: string;
    price: number;
    status: number;
  }
  
  export interface Contact {
    id: string;
    fullName: string;
    phoneNumber: string;
    email: string;
  }  