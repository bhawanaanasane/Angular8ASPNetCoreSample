import { Component, OnInit, Injectable } from '@angular/core'
import { FormGroup} from '@angular/forms';
import { Router } from '@angular/router';
import { ClientApiService } from '../../../Services/ClientApiService';
import { Role } from '../../../ViewModel/Role';
import { StateProvience } from '../../../ViewModel/StateProvience';
import { NgForm } from '@angular/forms';
import { UserLogin } from '../../../ViewModel/UserLogin';
import { ResponseModel } from '../../../ViewModel/ResponseModel';
import { ClientModel } from '../../../ViewModel/ClientModel';
import { CommonApiService } from '../../../Services/CommonApiService';
@Component({
  selector: "app-Client",
  templateUrl: "./client-create.component.html",
})
@Injectable({ providedIn: 'root' })
export class CreateClientComponent implements OnInit {


 
  constructor(private clientservice: ClientApiService, private commonservice: CommonApiService, private route: Router) {
    this.clientservice.GetMaxClientCode().subscribe(data => {

      this.clientCodeValue = String(data.response);
    },
      err => console.log(err)
    );

    let UserDetail = localStorage.getItem('currentUser');
    this.User = JSON.parse(UserDetail);
    this.commonservice.getAllState().subscribe(state => {
      this.states = state;
    },
      err => console.log(err)
    );

    this.commonservice.getRoleById(this.User.clientId, this.User.id).subscribe(role => {
      this.roles = role;
    },
      err => console.log(err)
    );


  }
  ClientModel: ClientModel = new ClientModel();
  clientCreateForm: FormGroup;
  responseModel: ResponseModel;
  roles: Role[];
  states: StateProvience[];
  User: UserLogin;
  clientCodeValue: string;
  ngOnInit (){}
 
  onSubmit(form: NgForm) {
    
    if (form.status != "INVALID") {
      this.clientservice.CreateClient(form.value, this.User.clientId).subscribe(respone => {
        this.responseModel = respone;
      },
        err => console.log(err)
      );
    }

 
  }

}
