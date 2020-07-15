
import { StateProvience } from "./StateProvience";

import { OperatorType } from "./DriverEnum";
export class DriverModel {
  
  DriverTypeId: number;

  FirstName: string;

  LastName: string;

  DriverCode: number;
  SSN: string;
  Address: string;
  Address2: string;
  City: string;
  ZipCode: string;
  HomePhone: string;
  MobilePhone: string;
  SmartPhoneFlag: boolean;
  BirthDate?: Date;

  DateStarted?: Date;
  DateLeft?: Date;
  EmergencyContactName: string;
  EmergencyPhoneNumber: string;
  Notes: string;
  StatusFlag: boolean;
  DriverLicenseNumber: string;
  DriverLicenseExpiry?: Date;
  MedicalCard: string;
  MedicalCardExpiry?: Date;
  TractorLicense: string;
  VINNumber: string;
  EINNumber: string;
  TruckMake: string;
  TruckInspectionDate?: Date;
  CHPInspectionDate?: Date;
  SmokeCheckDate?: Date;
  CompanyInsuredFlag: boolean;
  DriverLiabilityInsuranceNumber: string;
  DriverLiabilityExpiry?: Date;
  OccInsuranceStartDate?: Date;
  OccInsuranceEndDate?: Date;
  LiabilityInsuranceStartDate?: Date;
  LiabilityInsuranceEndDate?: Date;
  TruckOwnerFirstName: string;
  TruckOwnerLastName: string;
  TruckOwnerPhoneNumber: string;
  DMVDateAdd?: Date;
  DMVDateDelete?: Date;
  ClassALicenseFlag: boolean;
  HazardousLicenseFlag: boolean;
  TankerLicenseFlag: boolean;
  TriplesLicenseFlag: boolean;
  DoublesLicenseFlag: boolean;
  TwicCardExpiry?: Date;
  TruckRegDate?: Date;
  ApportionedPlatesExpiry?: Date;
  RFIDNumber: string;
  LeaseDateExpiry?: Date;
  PDTRLB?: Date;
  PDTRLA?: Date;
  EmodalFlag: boolean;
  UIIAFlag: boolean;
  ARBFlag: boolean;
  FuelCardNumber: string;
  ActiveDriver: boolean;
  CreateDate?: Date;
  LastUpdateDate?: Date;
  InsurenceExpiry?: Date;
  ClientId: number;
  // Id
  UserLogID: number;

  //Enum List
  Owner_Company_Driver: number;
  OperatorType: OperatorType[];
 
 

  //State 

  StateProvienceId?: number;
  StateProvience: StateProvience[];

}
