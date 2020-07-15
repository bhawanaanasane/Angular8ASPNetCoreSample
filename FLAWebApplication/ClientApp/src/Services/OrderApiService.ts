import { Component, Injectable } from "@angular/core"
import { ResponseModel } from "../ViewModel/ResponseModel";
import { HttpClient } from "@angular/common/http";

@Injectable({
  providedIn: "root"
})

export class OrderApiService {

  constructor(private http: HttpClient) {
  }

  GetMaxClientCode() {
    return this.http.get<ResponseModel>("http://132.148.19.41:8055/Api/Client/GetMaxClientCode");
  }
}
