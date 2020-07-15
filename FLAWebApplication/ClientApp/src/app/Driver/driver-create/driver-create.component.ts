import { Component } from '@angular/core';
import { CommonApiService } from '../../../Services/CommonApiService';
import { Router } from '@angular/router';
import { DriverModel } from '../../../ViewModel/DriverModel';
import { FormGroup, NgForm } from '@angular/forms';
import { ResponseModel } from '../../../ViewModel/ResponseModel';
import { StateProvience } from '../../../ViewModel/StateProvience';
import { DriverApiService } from '../../../Services/DriverApiService';
import { OperatorType } from '../../../ViewModel/DriverEnum';
import { UserLogin } from '../../../ViewModel/UserLogin';

@Component({
  selector: 'app-Driver-driver-create',
  templateUrl: './driver-create.component.html'
})
export class DriverCreateComponent {
  keys = [];
  constructor(private driverservice: DriverApiService, private commonservice: CommonApiService, private route: Router) {
    let UserDetail = localStorage.getItem('currentUser');
    this.User = JSON.parse(UserDetail);

    this.commonservice.getAllState().subscribe(state => {
      this.states = state.response;
    },
      err => console.log(err)
    );
    this.driverservice.getDriverCode().subscribe(driverscode => {
      this.driverCode = driverscode;
    },
      err => console.log(err)
    );

    for (var enumMember in OperatorType) {
      if (!isNaN(parseInt(enumMember, 10))) {
        this.keys.push({ key: enumMember, value: OperatorType[enumMember] });
        // Uncomment if you want log
        // console.log("enum member: ", value[enumMember]);
      }
    }



  }
  DriverModel: DriverModel = new DriverModel();
  driverCreateForm: FormGroup;
  responseModel: ResponseModel;
  states: StateProvience[];
  driverCode: number;
  User: UserLogin;
  ngOnInit() { }

  onSubmit(form: NgForm) {
    debugger
    if (form.status != "INVALID") {
      this.driverservice.CreateDriver(form.value, this.User).subscribe(respone => {
        this.responseModel = respone;
      },
        err => console.log(err)
      );
    }


  }
}
