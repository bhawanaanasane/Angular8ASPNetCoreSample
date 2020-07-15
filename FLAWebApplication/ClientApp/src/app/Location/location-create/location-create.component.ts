import {Component, OnInit} from '@angular/core'
import { CommonApiService } from '../../../Services/CommonApiService';
import { Router } from '@angular/router';
import { FormGroup, NgForm } from '@angular/forms';
import { ResponseModel } from '../../../ViewModel/ResponseModel';
import { Role } from '../../../ViewModel/Role';
import { StateProvience } from '../../../ViewModel/StateProvience';
import { UserLogin } from '../../../ViewModel/UserLogin';
import { PickupDeliveryModel } from '../../../ViewModel/PickupDeliveryModel';
import { LocationtApiService } from '../../../Services/LocationApiService';
import { PortModel } from '../../../ViewModel/PortModel';


@Component({
  selector: 'app-Location-location-create',
  templateUrl: './location-create.component.html',
})
//export class CreateLocationComponent {

//}
export class CreateLocationComponent implements OnInit {



  constructor(private locationservice: LocationtApiService, private commonservice: CommonApiService, private route: Router) {
    //this.locationservice.GetMaxClientCode().subscribe(data => {

    //  this.locationCodeValue = String(data.response);
    //},
    //  err => console.log(err)
    //);

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
 LocationModel: PickupDeliveryModel = new PickupDeliveryModel();
  locationCreateForm: FormGroup;
  responseModel: ResponseModel;
  roles: Role[];
  states: StateProvience[];
  User: UserLogin;

  locationCodeValue: string;
  ngOnInit() { }

  onSubmit(form: NgForm) {

    if (form.status != "INVALID") {
      this.locationservice.CreateLocation(form.value, this.User.clientId).subscribe(respone => {
        this.responseModel = respone;
      },
        err => console.log(err)
      );
    }


  }

}

