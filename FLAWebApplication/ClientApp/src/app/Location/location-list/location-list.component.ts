import { Component } from '@angular/core'
import { ResponseModel } from '../../../ViewModel/ResponseModel';
import { PickupDeliveryModel } from '../../../ViewModel/PickupDeliveryModel';
import { StateProvience } from '../../../ViewModel/StateProvience';
import { AppComponent } from '../../app.component';
import { LocationtApiService } from '../../../Services/LocationApiService';
import { CommonApiService } from '../../../Services/CommonApiService';
import { Router } from '@angular/router';
import { PortModel } from '../../../ViewModel/PortModel';
@Component({
  selector: "app-Location-location-list",
  templateUrl: './location-list.component.html',
})
//export class LocationListComponent {

//}
export class LocationListComponent {


  responseModel: ResponseModel = new ResponseModel();
  locationList: PickupDeliveryModel[];
  State: StateProvience[];
 
  constructor(private app: AppComponent, private service: LocationtApiService, private CommonService: CommonApiService, private router: Router) {
    app.Loading(true);
    this.CommonService.getAllState().subscribe(states => {
      this.State = states;
    },
      err => console.log(err)
    );
    //this.CommonService.getAllPorts().subscribe(port => {
    //  this.Ports = port;
    //},
    //  err => console.log(err)
    //);
  //  this.service.getLocationList().subscribe(Ouput => {
  //    this.locationList = Ouput.response;

  //    app.Loading(false);
  //  });
    app.Loading(false);
  }

  Edit(clientId) {
    this.router.navigate(['/Location/location-edit'], { queryParams: { ClientId: clientId } });
  }
}
