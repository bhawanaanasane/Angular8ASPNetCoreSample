"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var AdminAuthGuardService = /** @class */ (function () {
    function AdminAuthGuardService(router) {
        this.router = router;
    }
    AdminAuthGuardService.prototype.canActivate = function () {
        if (localStorage.getItem('AdminUser')) {
            // logged in so return true
            return true;
        }
        // not logged in so redirect to login page
        this.router.navigate(['/Login']);
        return false;
    };
    return AdminAuthGuardService;
}());
exports.AdminAuthGuardService = AdminAuthGuardService;
//# sourceMappingURL=AdminAuthGuardService.js.map