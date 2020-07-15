import { Component } from '@angular/core'
import { Containers } from '../../../ViewModel/Containers';
Component({
  selector:"app-Order-order-edit",
  templateUrl:"./order-edit.component.html"
})
class OrderEditComponent{

  ContailnerList: Array<Containers> = [];
  newDynamic: any = {};



  addRow(index) {
    this.newDynamic = { Id: "0", SizeId: "0", ContainerNumber: "", ChassisId: "0", ClientId: "0", SealNumber: "", Temperature: "", Weight: "", POPChassisFlag: false, UserId: "0", CreateDate: new Date(), LastUpdateDate: new Date(), StatusId: "0" };
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
}
