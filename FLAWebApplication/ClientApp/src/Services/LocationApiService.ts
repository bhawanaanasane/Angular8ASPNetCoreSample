import { Injectable } from "@angular/core";
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { ResponseModel } from "../ViewModel/ResponseModel";
import { PickupDeliveryModel } from "../ViewModel/PickupDeliveryModel";
import { map } from "rxjs/operators";
import { Observable } from 'rxjs';

@Injectable({
  providedIn: "root"
})
export class LocationtApiService {

  statesUrl: string = 'http://132.148.19.41:8055/api/CommonService/GetAllState';
  constructor(private http: HttpClient) {
  }
  
 
  //GetMaxClientCode() {
  //  return this.http.get<ResponseModel>("http://132.148.19.41:8055/Api/Client/GetMaxClientCode");
  //}
  //getEditClientData(ClientId) {
  //  return this.http.get<any>("http://132.148.19.41:8055/Api/Client/GetEditClientData/" + ClientId);
  //}
  //getClientList() {
  //  return this.http.get<any>("http://132.148.19.41:8055/Api/Client/GetAllClient");
  //}
  //getClientData(ClientId) {
  //  return this.http.get<any>("http://132.148.19.41:8055/Api/Client/GetEditClientData/" + ClientId);
  //}
  CreateLocation(LocationModel, parentId) {
    let headers = new HttpHeaders();
    headers.append('Content-Type', 'application/json');

    let body = {
      CompanyName: LocationModel.CompanyName,
      address1: LocationModel.address1,
      address2: LocationModel.address2,
      city: LocationModel.city,
      stateProvinceId: Number(LocationModel.stateProvinceId),
      zipCode: LocationModel.zipCode,
      phoneNumber: LocationModel.phoneNumber,
      faxNumber: LocationModel.faxNumber,
     
      userId: 0,
      clientCode: LocationModel.clientCode,
      userName: LocationModel.userName,
      password: LocationModel.password,
      clientId: 0,
      contactNo: LocationModel.phoneNumber,
      parentId: Number(parentId),
      active: Boolean(LocationModel.active),
      roleId: Number(LocationModel.roleId)
    };

    return this.http.post<any>("http://132.148.19.41:8055/Api/Location/CreateLocation",
      body)
      .pipe(map(user => {



        return user;
      }));

  }

  private handleError(error: HttpErrorResponse) {
    console.error('server error:', error);
    if (error.error instanceof Error) {
      let errMessage = error.error.message;
      return Observable.throw(errMessage);
      // Use the following instead if using lite-server
      //return Observable.throw(err.text() || 'backend server error');
    }
    return Observable.throw(error || 'Server error');
  }
}  
