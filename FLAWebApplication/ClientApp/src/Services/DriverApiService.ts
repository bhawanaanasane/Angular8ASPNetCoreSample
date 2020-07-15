import { HttpHeaders, HttpClient } from "@angular/common/http";
import { map } from "rxjs/operators";
import { Injectable } from "@angular/core";
@Injectable({
  providedIn: "root"
})
export class DriverApiService {
  constructor(private http: HttpClient) {
  }

  getDriverCode() {
    return this.http.get<number>("http://132.148.19.41:8055/api/Driver/GetDriverCode");
  }
  CreateDriver(DriverModel, User) {
    let headers = new HttpHeaders();
    headers.append('Content-Type', 'application/json');
    debugger
    let body = {
      firstName: DriverModel.firstname,
      lastName: DriverModel.lastname,
      birthDate: new Date(DriverModel.birthdate),
      sSN: DriverModel.ssn,
      homePhone: DriverModel.home,
      mobilePhone: DriverModel.mobile,
      dateStarted: DriverModel.hiredate,
      dateLeft: DriverModel.leftdate,
      address: DriverModel.address1,
      address2: DriverModel.address2,
      stateProvinceId: Number(DriverModel.stateProvinceId),
      city: DriverModel.city,
      zipCode: DriverModel.zipcode,
      activeDriver: Boolean(DriverModel.active),
      Owner_Company_Driver: Number(DriverModel.operatortypeId),
      truckOwnerFirstName: DriverModel.truckOwnerFirstName,
      truckOwnerLastName: DriverModel.truckOwnerLastName,
      truckOwnerPhoneNumber: DriverModel.truckOwnerPhoneNumber,
      driverLicenseNumber: DriverModel.driverLicenseNumber,
      driverLicenseExpiry: DriverModel.driverLicenseExpiry,
      tractorLicense: DriverModel.tractorLicense,
      classALicenseFlag: Boolean(DriverModel.classALicenseFlag),
      doublesLicenseFlag: Boolean(DriverModel.doublesLicenseFlag),
      uIIAFlag: Boolean(DriverModel.uIIAFlag),
      hazardousLicenseFlag: Boolean(DriverModel.hazardousLicenseFlag),
      triplesLicenseFlag: Boolean(DriverModel.triplesLicenseFlag),
      aRBFlag: Boolean(DriverModel.aRBFlag),
      notes: DriverModel.notes,
      truckMake: DriverModel.truckMake,
      vINNumber: DriverModel.vINNumber,
      eINNumber: DriverModel.eINNumber,
      leaseDateExpiry: DriverModel.leaseDateExpiry,
      twicCardExpiry: DriverModel.twicCardExpiry,
      truckRegDate: DriverModel.truckRegDate,
      apportionedPlatesExpiry: DriverModel.apportionedPlatesExpiry,
      rFIDNumber: DriverModel.rFIDNumber,
      pDTRLB: DriverModel.pDTRLB,
      pDTRLA: DriverModel.pDTRLA,
      dMVDateAdd: DriverModel.dMVDateAdd,
      dMVDateDelete: DriverModel.dMVDateDelete,
      fuelCardNumber: DriverModel.fuelCardNumber,
      truckInspectionDate: DriverModel.truckInspectionDate,
      cHPInspectionDate: DriverModel.cHPInspectionDate,
      smokeCheckDate: DriverModel.smokeCheckDate,
      occInsuranceStartDate: DriverModel.occInsuranceStartDate,
      occInsuranceEndDate: DriverModel.occInsuranceEndDate,
      liabilityInsuranceStartDate: DriverModel.liabilityInsuranceStartDate,
      liabilityInsuranceEndDate: DriverModel.liabilityInsuranceEndDate,
      driverLiabilityInsuranceNumber: DriverModel.driverLiabilityInsuranceNumber,
      driverLiabilityExpiry: DriverModel.driverLiabilityExpiry,
      medicalCard: DriverModel.medicalCard,
      insurenceExpiry: DriverModel.insuranceExpiry,

      driverTypeId: DriverModel.driverTypeId   ,
    
      driverCode: DriverModel.drivercode   ,
       smartPhoneFlag: Boolean(DriverModel.smartPhoneFlag ) ,
        emergencyContactName: DriverModel.emergencyContactName   ,
      emergencyPhoneNumber: DriverModel.emergencyPhoneNumber   ,
      statusFlag: Boolean(DriverModel.statusFlag),
      medicalCardExpiry: new Date(DriverModel.medicalCardExpiry)  ,
      companyInsuredFlag: Boolean(DriverModel.companyInsuredFlag)   ,
      tankerLicenseFlag: Boolean(DriverModel.tankerLicenseFlag)   ,
      emodalFlag: Boolean(DriverModel.emodalFlag)   ,
      UserLoginId: Number(User.id),

      ClientId: Number(User.clientId)
    };

    return this.http.post<any>("http://132.148.19.41:8055/Api/Driver/CreateDriver",
      body)
      .pipe(map(user => {
        return user;
      }));

  }}
