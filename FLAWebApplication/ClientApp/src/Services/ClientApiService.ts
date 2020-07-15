import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
//import { ROOT_URL } from 'src/Models/Config'
import { Observable } from 'rxjs';
import { StateProvience } from '../ViewModel/StateProvience';
import { Injectable } from '@angular/core';
import { Client } from '../ViewModel/Client';
import { map } from 'rxjs/operators';
import { environment } from '../environments/environment';
import { Role } from '../ViewModel/Role';
import { ResponseModel } from '../ViewModel/ResponseModel';
@Injectable({
  providedIn: "root"
})
export class ClientApiService {

  statesUrl: string = 'http://132.148.19.41:8055/api/CommonService/GetAllState';
  constructor(private http: HttpClient) {
  }

  GetMaxClientCode() {
    return this.http.get<ResponseModel>("http://132.148.19.41:8055/Api/Client/GetMaxClientCode");
  }
  getEditClientData(ClientId) {
    return this.http.get<any>("http://132.148.19.41:8055/Api/Client/GetEditClientData/" + ClientId);
  }
  getClientList() {
    return this.http.get<any>("http://132.148.19.41:8055/Api/Client/GetAllClient");
  }
  getClientData(ClientId) {
    return this.http.get<any>("http://132.148.19.41:8055/Api/Client/GetEditClientData/" + ClientId);
  }
  CreateClient(ClientModel,parentId) {
    let headers = new HttpHeaders();
    headers.append('Content-Type', 'application/json');
    
    let body = {
      name: ClientModel.name,
      address1: ClientModel.address1,
      address2: ClientModel.address2,
      city: ClientModel.city,
      stateProvinceId: Number(ClientModel.stateProvinceId),
      zipCode: ClientModel.zipCode,
      phoneNumber: ClientModel.phoneNumber,
      faxNumber: ClientModel.faxNumber,
      startingDriverCodeNumber: ClientModel.startingDriverCodeNumber,
      startingOrderNumber: ClientModel.startingOrderNumber,
      userId: 0,
      clientCode: ClientModel.clientCode,
      userName: ClientModel.userName,
      password: ClientModel.password,
      clientId: 0,
      contactNo: ClientModel.phoneNumber,
      parentId: Number(parentId),
      active: Boolean(ClientModel.active),
      roleId: Number(ClientModel.roleId)
    };
    
    return this.http.post<any>("http://132.148.19.41:8055/Api/Client/CreateClient",
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
