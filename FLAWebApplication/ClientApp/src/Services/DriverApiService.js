"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var http_1 = require("@angular/common/http");
var operators_1 = require("rxjs/operators");
var DriverApiService = /** @class */ (function () {
    function DriverApiService(http) {
        this.http = http;
    }
    DriverApiService.prototype.CreateDriver = function (DriverModel) {
        var headers = new http_1.HttpHeaders();
        headers.append('Content-Type', 'application/json');
        debugger;
        var body = {
            name: DriverModel.name,
            address1: DriverModel.address1,
            address2: DriverModel.address2,
            city: DriverModel.city,
            stateProvinceId: Number(DriverModel.stateProvinceId),
            zipCode: DriverModel.zipCode,
            phoneNumber: DriverModel.phoneNumber,
            faxNumber: DriverModel.faxNumber,
            startingDriverCodeNumber: DriverModel.startingDriverCodeNumber,
            startingOrderNumber: DriverModel.startingOrderNumber,
            userId: 0,
            clientCode: DriverModel.clientCode,
            userName: DriverModel.userName,
            password: DriverModel.password,
            clientId: 0,
            contactNo: DriverModel.phoneNumber,
            active: Boolean(DriverModel.active),
            roleId: Number(DriverModel.roleId)
        };
        return this.http.post("http://132.148.19.41:8055/Api/Driver/CreateDriver", body)
            .pipe(operators_1.map(function (user) {
            return user;
        }));
    };
    return DriverApiService;
}());
exports.DriverApiService = DriverApiService;
//# sourceMappingURL=DriverApiService.js.map