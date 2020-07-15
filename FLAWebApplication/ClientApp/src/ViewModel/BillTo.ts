import { StateProvience } from "./StateProvience";

export class BillTo {
  Id: number;
  ClientId: number;
  TermsId: number;
  UserLoginId: number;
  CompanyName: string;
  Address1: string;
  Address2: string;
  City: string;
  StateProvinceId: number;
  StateProvince: StateProvience;
  ZipCode: string;
  PhoneNumber: string;
  InvoiceEmailAddress: string;
  FaxNumber: string;
  Factor: boolean;
  EDI: boolean;
  Active: boolean;
  InvoicePreferenceId: number;
}
