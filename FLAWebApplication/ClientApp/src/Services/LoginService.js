"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var operators_1 = require("rxjs/operators");
var http_1 = require("@angular/common/http");
var rxjs_1 = require("rxjs");
var LoginService = /** @class */ (function () {
    function LoginService(http) {
        this.http = http;
        this.apiUrl = "http://132.148.19.41:8055/api/Login/authenticateWeb";
        ;
    }
    LoginService.prototype.validateLoginUser = function (loginmodel) {
        var headers = new http_1.HttpHeaders({ 'Content-Type': 'application/json' });
        return this.http.post(this.apiUrl, loginmodel, { headers: headers })
            .pipe(operators_1.tap(function (data) {
            console.log(data);
            ;
            if (data.Token != null) {
                if (data.status == "1") {
                    // store username and jwt token in local storage to keep user logged in between page refreshes
                    localStorage.setItem('AdminUser', JSON.stringify({ username: loginmodel.userName, token: data.Token }));
                }
                // return true to indicate successful login
                return data;
            }
            else {
                // return false to indicate failed login
                return null;
            }
        }), operators_1.catchError(this.handleError));
    };
    LoginService.prototype.LogoutUser = function () {
        localStorage.removeItem('currentUser');
    };
    LoginService.prototype.handleError = function (error) {
        if (error.error instanceof ErrorEvent) {
            // A client-side or network error occurred. Handle it accordingly.
            console.error('An error occurred:', error.error.message);
        }
        else {
            // The backend returned an unsuccessful response code.
            // The response body may contain clues as to what went wrong,
            console.error("Backend returned code " + error.status + ", " + ("body was: " + error.error));
        }
        // return an observable with a user-facing error message
        return rxjs_1.throwError('Something bad happened; please try again later.');
    };
    ;
    return LoginService;
}());
exports.LoginService = LoginService;
//# sourceMappingURL=LoginService.js.map
