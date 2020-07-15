import { Component, OnInit } from '@angular/core'
import { Containers } from '../../../ViewModel/Containers';
import { getLocaleDateFormat } from '@angular/common';
import { Dropdown } from '../../../ViewModel/DropdownModel';
import { Import_ExportStatus } from '../../../ViewModel/CommonEnum';
@Component({
  selector: "app-Order-order-create",
  templateUrl: "./order-create.component.html",
})
export class CreateOrderComponent implements OnInit {
 
 
  public ExportImportOptions = {};
  ImportExport: Dropdown[];
  OrderStatus: Dropdown[];
  
  

  constructor() {
    this.ExportImportOptions = [{ Id: 7, Name: "Import" }, { Id: 8, Name: "Export" }];
    this.OrderStatus = [{ Id: 4, Name: "Open" }, { Id: 5, Name: "Filled" }, { Id: 6, Name: "Cancelled" }];
    
  }
  ContailnerList: Array<Containers> = [];
  newDynamic: any = {};
 
  ngOnInit() {
    this.ContailnerList.push(this.newDynamic);
  }
  
  


  addRow(index) {
    this.newDynamic = { Id: "0", SizeId: "0", ContainerNumber: "", ChassisId: "0", ClientId: "0", SealNumber: "", Temperature: "", Weight: "", POPChassisFlag: false, UserId: "0", CreateDate: new Date(), LastUpdateDate: new Date(),StatusId:"0" };
    this.ContailnerList.push(this.newDynamic);
    return true;
  }

  Remove(index) {
    if (this.ContailnerList.length == 1) {
      return false;
    } else {
      this.ContailnerList.splice(index, 1);
      return true;
    }
  }
  ChnageValue(dat, index) {
    let k = dat;
  }
}
