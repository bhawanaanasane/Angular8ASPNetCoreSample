import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './Login/login.component';
import { LayoutComponent } from './Layout/layout.component';
import { CreateRoleComponent } from './Permission/create-role/create-role.component';
import { FormPermissionComponent } from './Permission/form-permission/form-permission.component';
import { ClientUserComponent } from './User/client-user/client-user.component';
import { DriverCreateComponent } from './Driver/driver-create/driver-create.component';
import { DriverListComponent } from './Driver/driver-list/driver-list.component';
import { CreateBillToComponent } from './BillTo/billto-create/billto-create.component';
import { EditBillToComponent } from './BillTo/billto-Edit/billto-Edit.component';
import { BillToListComponent } from './BillTo/billto-list/billto-list.component';
import { CreateLocationComponent } from './Location/location-create/location-create.component';
import { LocationListComponent } from './Location/location-list/location-list.component';
import { CreateEditSalePersonComponent } from './SalePerson/saleperson-create_edit/saleperson-create_edit.component';
import { PortLoginComponent } from './Port/port-login/port-login.component';
import { CreateEditChassisComponent } from './Chassis/chassis-create_edit/chassis-create_edit.component';
import { CreateEditRentalCompany } from './RentalCompany/rentalcompany-create_edit/rentalcompany-create_edit.component';
import { CreateEditContainerSizeComponent } from './Container/containersize-create_edit/containersize-create_edit.component';
import { CreateEditFactorCompanyComponent } from './FactorCompany/factorcompany-create_edit/factorcompany-create_edit.component';
import { CreateOrderComponent } from './Order/order-create/order-create.component';
import { OrderListComponent } from './Order/order-list/order-list.component';
import { AvailibilityListComponent } from './Availibility/availibility-list/availibility-list.component';
import { CreateClientComponent } from './Client/client-create/client-create.component';
import { DatePipe } from '@angular/common';
import { AdminAuthGuardService } from '../Services/AdminAuthGuardService';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { ClientListComponent } from './Client/client-list/clientlist.component';
import { NgxLoadingModule } from 'ngx-loading';
import { CreatePortComponent } from './Port/create-port/create-port.component';
import { PortListComponent } from './Port/port-list/port-list.component';
import { LocationEditComponent } from './Location/location-edit/location-edit.component';
import { DriverEditComponent } from './Driver/driver-edit/driver-edit.component';





@NgModule({
  declarations: [
    AppComponent,
 
    NavMenuComponent,
    HomeComponent,
    LoginComponent,
    LayoutComponent,
    ClientUserComponent,
    DriverCreateComponent,
    CreateBillToComponent,
    EditBillToComponent,
    BillToListComponent,
    CreateRoleComponent,
    FormPermissionComponent,
    DriverListComponent,
    CreateLocationComponent,
    LocationListComponent,
    CreateEditSalePersonComponent,
    PortLoginComponent,
    CreateEditChassisComponent,
    CreateEditRentalCompany,
    CreateEditContainerSizeComponent,
    CreateEditFactorCompanyComponent,
    CreateOrderComponent,
    OrderListComponent,
    AvailibilityListComponent,
    CreateClientComponent,
    ClientListComponent,
    CreatePortComponent,
    PortListComponent,
    LocationEditComponent,
    DriverEditComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    BrowserAnimationsModule,
    NgxLoadingModule.forRoot({}),
    ToastrModule.forRoot({
      timeOut: 5000,
      positionClass:'toast-top-right',
      resetTimeoutOnDuplicate:false,
    })
      ,
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([

      { path: '', component: LoginComponent, pathMatch: 'full' },

      {
        path: 'Admin', component: AppComponent,
        children: [
          { path: 'layout', component: LayoutComponent, canActivate: [AdminAuthGuardService] }

        ]
      },
      {
        path: 'Client', component: AppComponent,
        children: [
          { path: 'client-create', component: CreateClientComponent, canActivate: [AdminAuthGuardService]  }

        ]
      },
      {
        path: 'Client', component: AppComponent,
        children: [
          { path: 'client-Edit', component: CreateClientComponent, canActivate: [AdminAuthGuardService] }

        ]
      },
      {
        path: 'Client', component: AppComponent,
        children: [
          { path: 'clientlist', component: ClientListComponent, canActivate: [AdminAuthGuardService]  }

        ]
      },
      {
        path: 'Role', component: AppComponent,
        children: [
          { path: 'create-role', component: CreateRoleComponent, canActivate: [AdminAuthGuardService] }
        ]
      },
      {
        path: 'BilltoEdit', component: AppComponent,
        children: [
          { path: 'billto-edit', component: EditBillToComponent, canActivate: [AdminAuthGuardService] }
        ]
      },
      {
        path: 'Billto', component: AppComponent,
        children: [
          { path: 'billto-create', component: CreateBillToComponent, canActivate: [AdminAuthGuardService] }
        ]
      },
      {
        path: 'Port', component: AppComponent,
        children: [
          { path: 'create-port', component: CreatePortComponent, canActivate: [AdminAuthGuardService] }
        ]
      },
      {
        path: 'PortList', component: AppComponent,
        children: [
          { path: 'port-list', component: PortListComponent, canActivate: [AdminAuthGuardService] }
        ]
      },
      {
        path: 'OrderCreate', component: AppComponent,
        children: [
          { path: 'order-create', component: CreateOrderComponent, canActivate: [AdminAuthGuardService] }
        ]
      },
      { path: 'home', component: HomeComponent },
      { path: 'form-permission', component: FormPermissionComponent },
      //Client
      { path: 'client-user', component: ClientUserComponent },
      //driver
      { path: 'driver-list', component: DriverListComponent },
      { path: 'driver-create', component: DriverCreateComponent },
      { path: 'driver-edit', component: DriverEditComponent },
      //Bill to
      { path: 'billto-list', component: BillToListComponent },
      { path: 'location-create', component: CreateLocationComponent },
      { path: 'location-list', component: LocationListComponent },
      { path: 'saleperson-create_edit', component: CreateEditSalePersonComponent },
      { path: 'port-login', component: PortLoginComponent },
      { path: 'chassis-create_edit', component: CreateEditChassisComponent },
      { path: 'rentalcompany-create_edit', component: CreateEditRentalCompany },
      { path: 'containersize-create_edit', component: CreateEditContainerSizeComponent },
      { path: 'factorcompany-create_edit', component: CreateEditFactorCompanyComponent },
      { path: 'order-list', component: OrderListComponent },
      { path: 'availibility-list', component: AvailibilityListComponent },
      { path: 'location-edit', component: LocationEditComponent },
     
    ])
  ],
  providers: [DatePipe, AdminAuthGuardService],
  bootstrap: [AppComponent]
})
export class AppModule { }
