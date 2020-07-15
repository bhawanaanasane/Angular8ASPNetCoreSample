"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var rxjs_1 = require("rxjs");
core_1.Injectable({
    providedIn: 'root'
});
var CommonApiService = /** @class */ (function () {
    function CommonApiService(http) {
        this.http = http;
    }
    CommonApiService.prototype.getAllState = function () {
        return this.http.get("http://132.148.19.41:8055/Api/CommonService/GetAllState");
    };
    CommonApiService.prototype.getRoleById = function (ClientId, UserId) {
        return this.http.get("http://132.148.19.41:8055/Api/CommonService/GetRoleById/" + ClientId + ',' + UserId);
    };
    CommonApiService.prototype.handleError = function (error) {
        console.error('server error:', error);
        if (error.error instanceof Error) {
            var errMessage = error.error.message;
            return rxjs_1.Observable.throw(errMessage);
            // Use the following instead if using lite-server
            //return Observable.throw(err.text() || 'backend server error');
        }
        return rxjs_1.Observable.throw(error || 'Server error');
    };
    return CommonApiService;
}());
exports.CommonApiService = CommonApiService;
//# sourceMappingURL=CommonApiService.js.map