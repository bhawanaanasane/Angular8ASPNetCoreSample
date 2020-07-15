"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
core_1.Component({
    selector: "app-Order-order-edit",
    templateUrl: "./order-edit.component.html"
});
var OrderEditComponent = /** @class */ (function () {
    function OrderEditComponent() {
        this.ContailnerList = [];
        this.newDynamic = {};
    }
    OrderEditComponent.prototype.addRow = function (index) {
        this.newDynamic = { Id: "0", SizeId: "0", ContainerNumber: "", ChassisId: "0", ClientId: "0", SealNumber: "", Temperature: "", Weight: "", POPChassisFlag: false, UserId: "0", CreateDate: new Date(), LastUpdateDate: new Date(), StatusId: "0" };
        this.ContailnerList.push(this.newDynamic);
        return true;
    };
    OrderEditComponent.prototype.Remove = function (index) {
        if (this.ContailnerList.length == 1) {
            return false;
        }
        else {
            this.ContailnerList.splice(index, 1);
            return true;
        }
    };
    return OrderEditComponent;
}());
//# sourceMappingURL=order-edit.component.js.map