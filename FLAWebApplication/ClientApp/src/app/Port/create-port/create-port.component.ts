import { Component, OnInit, Injectable } from '@angular/core'
import { Router } from '@angular/router';
import { CommonApiService } from '../../../Services/CommonApiService';
import { StateProvience } from '../../../ViewModel/StateProvience';
import { FormGroup, NgForm } from '@angular/forms';
import { ResponseModel } from '../../../ViewModel/ResponseModel';
import { SuperadminApiServices } from '../../../Services/SuperadminApiServices';
import { UserLogin } from '../../../ViewModel/UserLogin';
import { PortModel } from '../../../ViewModel/PortModel';
import { AppComponent } from '../../app.component';

@Component({
  selector: "app-Port-create-port",
  templateUrl:"./create-port.component.html"

})
@Injectable({ providedIn: 'root' })
export class CreatePortComponent implements OnInit
{

  constructor(private commonservice: CommonApiService, private App: AppComponent, private PortApi: SuperadminApiServices, private route: Router) {
    let UserDetail = localStorage.getItem('currentUser');
    this.User = JSON.parse(UserDetail);
    this.commonservice.getAllState().subscribe(state => {
      this.states = state;
    },
      err => console.log(err)
    );
  }
  PortsModel: PortModel = new PortModel();
  portCreateForm: FormGroup;
  responseModel: ResponseModel;
  states: StateProvience[];
  User: UserLogin;
  ngOnInit() { }
  onSubmit(form: NgForm) {

    if (form.status != "INVALID") {
      this.PortApi.CreatePort(form.value, this.User.clientId, this.User.id).subscribe(respone => {
        this.responseModel = respone;
        if (this.responseModel.status == 1) {
          this.App.ShowSuccess("Save Successfully");
        }
        else {
          this.App.ShowError(this.responseModel.message);
        }
      },
        err => console.log(err)
      );
    }


  }
}

