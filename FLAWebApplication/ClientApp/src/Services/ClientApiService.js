"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
//import { ROOT_URL } from 'src/Models/Config'
var rxjs_1 = require("rxjs");
var ClientApiService = /** @class */ (function () {
    function ClientApiService(http) {
        this.http = http;
        this.statesUrl = 'http://132.148.19.41:8055/api/CommonService/GetAllState';
        ;
    }
    ClientApiService.prototype.getAllState = function () {
        return this.http.get("http://132.148.19.41:8055/api/CommonService/GetAllState");
    };
    ClientApiService.prototype.handleError = function (error) {
        console.error('server error:', error);
        if (error.error instanceof Error) {
            var errMessage = error.error.message;
            return rxjs_1.Observable.throw(errMessage);
            // Use the following instead if using lite-server
            //return Observable.throw(err.text() || 'backend server error');
        }
        return rxjs_1.Observable.throw(error || 'Server error');
    };
    return ClientApiService;
}());
exports.ClientApiService = ClientApiService;
//# sourceMappingURL=ClientApiService.js.map
