import { StateProvience } from "./StateProvience";
import { PortModel } from "./PortModel";

export class PickupDeliveryModel {
  ClientId: number;
  UserId: number;
  CompanyName: string;
  Address1: string;
  Address2: string;
  City: string;
  stateProvinceId?: number;
  stateProvince: StateProvience[];
  ZipCode: string;
  PhoneNumber: string;
  FaxNumber: string;
  PortsId: number;
  Port: boolean;
  Active: boolean;
  StateName: string;
  CreateDate: Date;
  LastUpdateDate: Date;
  ports: PortModel[];
 
 
  




}

export class PickupListModel {
  CompanyName: string;
  CheckActive: boolean;
  Pickupid: number;
}   
   
