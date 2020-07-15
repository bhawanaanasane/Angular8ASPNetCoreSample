"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var router_1 = require("@angular/router");
var home_component_1 = require("./home/home.component");
var login_component_1 = require("./Login/login.component");
var auth_guard_1 = require("./_helpers/auth.guard");
var client_create_component_1 = require("./Client/client-create/client-create.component");
var create_role_component_1 = require("./Permission/create-role/create-role.component");
exports.routes = [
    { path: '', component: home_component_1.HomeComponent, canActivate: [auth_guard_1.AuthGuard] },
    { path: 'login', component: login_component_1.LoginComponent },
    { path: 'client-create', component: client_create_component_1.CreateClientComponent },
    { path: 'create-role', component: create_role_component_1.CreateRoleComponent },
    { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
    // otherwise redirect to home
    { path: '**', redirectTo: '' }
];
exports.appRoutingModule = router_1.RouterModule.forRoot(exports.routes);
//# sourceMappingURL=app.routing.js.map