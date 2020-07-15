import { DatePipe } from "@angular/common";
import { UserLogin } from "./UserLogin";
import { Observable } from "rxjs";
import { StateProvience } from "./StateProvience";

export class ClientModel {
  id: number;
  name: string;
  address1: string;
  address2: string;
  city: string;
  stateProvinceId?: number;
  stateProvince: StateProvience[];
  zipCode: string;
  phoneNumber: string;
  faxNumber: string;
  startingDriverCodeNumber: string;
  startingOrderNumber: string;
  companyImage: string;
  userId: number;
  clientCode: string;
  //login
  loginId: number;
  clientId: number;
  firstName: string;
  lastName: string;
  userName: string;
  password: string;
  contactNo: string;
  parentId: number;
  active: boolean;
  loggedIn: boolean;
  roleId: number;
  token?: string;
 

}
