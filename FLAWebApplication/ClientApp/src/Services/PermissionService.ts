import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ResponseModel } from '../ViewModel/ResponseModel';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: "root"
})
export class PermissionService {
  constructor(private http: HttpClient) {
  }
  CreateRole(RoleName,ClientId, UserId) {
    return this.http.get<ResponseModel>("http://132.148.19.41:8055/Api/CommonService/CreateRole/" + RoleName + ',' + ClientId + ',' + UserId);
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
