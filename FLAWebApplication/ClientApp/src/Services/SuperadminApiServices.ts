import { Component, Injectable } from '@angular/core'
import { StateProvience } from '../ViewModel/StateProvience';
import { Role } from '../ViewModel/Role';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { isNull } from 'util';
@Injectable({
  providedIn: 'root'
})

export class SuperadminApiServices {
  constructor(private http: HttpClient) {

  }
  CreatePort(PortModel, parentId,UserLoginId) {
    let headers = new HttpHeaders();
    headers.append('Content-Type', 'application/json');

    let body = {
      PortName: PortModel.PortName,
      Address1: PortModel.Address1,
      Address2: PortModel.Address2,
      City: PortModel.City,
      StateProvinceId:Number( PortModel.StateProvinceId),
      PortZipCode: PortModel.PortZipCode,
      ContactNo: PortModel.ContactNo,
      ClientId: parentId,
      Active: (PortModel.Active == "" ? false : PortModel.Active),
      CheckPort: false,
      UserLoginId: UserLoginId,
      WebsiteURL: PortModel.WebsiteURL,
      PortLoginFlag: (PortModel.PortLoginFlag == "" ? false : PortModel.PortLoginFlag)
    };
   
    return this.http.post<any>("http://132.148.19.41:8055/Api/BaseTable/CreatePort",
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
