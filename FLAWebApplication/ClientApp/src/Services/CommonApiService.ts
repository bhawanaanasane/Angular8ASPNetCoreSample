import { Component, Injectable } from '@angular/core'
import { StateProvience } from '../ViewModel/StateProvience';
import { Role } from '../ViewModel/Role';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { PickupDeliveryModel } from '../ViewModel/PickupDeliveryModel';
import { PortModel } from '../ViewModel/PortModel';
@Injectable({
  providedIn: 'root'
})
export class CommonApiService { 
  constructor(private http: HttpClient)
  {
  }

  getAllState() {
    return this.http.get<any>("http://132.148.19.41:8055/Api/CommonService/GetAllState");
  }
  getRoleById(ClientId, UserId) {
    return this.http.get<Role[]>("http://132.148.19.41:8055/Api/CommonService/GetRoleById/" + ClientId + ',' + UserId);
  }
  //getAllPorts() {
  //  return this.http.get<PortModel[]>("http://132.148.19.41:8055/Api/CommonService/GetAllPorts");
  //}
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
