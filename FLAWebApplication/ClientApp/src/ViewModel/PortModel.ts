import { DatePipe } from "@angular/common"

export class PortModel {
  Id: number;
  PortName: string;
  Address1: string;
  Address2: string;
  City: string;
  StateProvinceId: number;
  PortZipCode: string;
  ContactNo: string;
  ClientId: number;
  Active: boolean;
  CheckPort: boolean;
  UserLoginId: number;
  WebsiteURL: string;
  PortLoginFlag: boolean;
  CreateDate: DatePipe;
  LastUpdateDate: DatePipe;
}
