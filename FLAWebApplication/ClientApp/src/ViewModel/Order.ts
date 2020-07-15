import { Component } from '@angular/core'
export class Order {
  Id: number;
  Ordernumber: number;
  DeliveryID: number;
  PickupID: number;
  BillToID: number;
  ClientId: number;
  ReturnLocationID: number;
  SalesRepID: number;
  SalesPersonId: number;
  OrderStatusId: number;
  Import_ExportId: number;
  BillofLading: String;
  BookingNumber: String;
  OrderDate: Date;
  BrokerRefNumber: String;
  InvoiceNotes: String;
  DriverNotes: String;
  PoNumber: String;
  InvoiceExceptionFlag: Boolean;
  ReturnPickup: Boolean;
  UserId: number;
  CreateDate: Date;
  LastUpdateDate: Date;
  StatusId: number;

}
