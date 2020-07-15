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
export class BaseTableApiService {

  statesUrl: string = 'http://132.148.19.41:8055/api/CommonService/GetAllState';
  constructor(private http: HttpClient) {
  }
  getAllState() {
    return this.http.get<any>("http://132.148.19.41:8055/Api/CommonService/GetAllState");
  }

  DeleteBillToService(clientId,BillToId) {
    return this.http.get<any>("http://132.148.19.41:8055/Api/BaseTable/DeleteBillTo/" + clientId + "," + BillToId);
  }
 

  CreateBillto(BillToModel, User) {
    let headers = new HttpHeaders();
    headers.append('Content-Type', 'application/json');
    
    let body = {
      Id: 0,
      ClientId: Number(User.clientId),
      TermsId: 0,
      UserLoginId: Number(User.id),
      CompanyName: BillToModel.CompanyName,
      Address1: BillToModel.Address1,
      Address2: BillToModel.Address2,
      City: BillToModel.City,
      StateProvinceId:Number( BillToModel.StateProvienceId),
      ZipCode: BillToModel.ZipCode,
      PhoneNumber: BillToModel.PhoneNumber,
      InvoiceEmailAddress: BillToModel.InvoiceEmailAddress,
      FaxNumber: BillToModel.FaxNumber,
      Factor: Boolean( BillToModel.Factor),
      EDI: BillToModel.EDI,
      Active: Boolean(BillToModel.Active),
      InvoicePreferenceId: Number(BillToModel.InvoicePreferenceId)
    };
    
    return this.http.post<any>("http://132.148.19.41:8055/Api/BaseTable/CreateEditBillTo",
      body)
      .pipe(map(user => {
        

        

        return user;
      }));
  
  }

  EditBillto(BillToModel, User) {
    let headers = new HttpHeaders();
    headers.append('Content-Type', 'application/json');

    let body = {
      Id: BillToModel.Id,
      ClientId: Number(User.clientId),
      TermsId: 0,
      UserLoginId: Number(User.id),
      CompanyName: BillToModel.CompanyName,
      Address1: BillToModel.Address1,
      Address2: BillToModel.Address2,
      City: BillToModel.City,
      StateProvinceId: Number(BillToModel.StateProvienceId),
      ZipCode: BillToModel.ZipCode,
      PhoneNumber: BillToModel.PhoneNumber,
      InvoiceEmailAddress: BillToModel.InvoiceEmailAddress,
      FaxNumber: BillToModel.FaxNumber,
      Factor: Boolean(BillToModel.Factor),
      EDI: BillToModel.EDI,
      Active: Boolean(BillToModel.Active),
      InvoicePreferenceId: Number(BillToModel.InvoicePreferenceId)
    };
    
    return this.http.post<any>("http://132.148.19.41:8055/Api/BaseTable/CreateEditBillTo",
      body)
      .pipe(map(user => {


        

        return user;
      }));

  }
  GetBillToList(ClientId) {
    
    return this.http.get<any>("http://132.148.19.41:8055/Api/BaseTable/GetBillToList/" + ClientId).pipe(map(user => {
      

      return user;
    }));
  }

 
  
  GetBillToEdit(ClientId,BillToId) {
    
    return this.http.get<any>("http://132.148.19.41:8055/Api/BaseTable/GetBillToEditDetail/" + ClientId + "," + BillToId).pipe(map(user => {
      

      return user;
    }));
  }

  //Port

  GetPortList(ClientId)
  {

    return this.http.get<any>("http://132.148.19.41:8055/Api/BaseTable/GetAllPort/" + ClientId).pipe(map(user => {


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
