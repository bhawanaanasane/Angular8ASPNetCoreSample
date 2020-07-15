import { Component } from '@angular/core';
import { StateProvience } from './StateProvience';

export class Client {
  Name: string;
  Address1: string;
  Address2: string;
  City: string;
  StateProvinceId: number;
  StateProvince: StateProvience;
  ZipCode: string;
  PhoneNumber: string;
  FaxNumber: string;
  StartingDriverCodeNumber: string;
  StartingOrderNumber: string;
  CompanyImage: [];
  UserId: number;
  ClientCode: string;
  CreateDate: Date;
  LastUpdateDate: Date;
}
