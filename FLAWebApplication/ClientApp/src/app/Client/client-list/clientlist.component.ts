import { Component } from '@angular/core';
import { AppComponent } from '../../app.component';
import { ClientApiService } from '../../../Services/ClientApiService';
import { Router } from '@angular/router';
import { ResponseModel } from '../../../ViewModel/ResponseModel';
import { Client } from '../../../ViewModel/Client';
import { StateProvience } from '../../../ViewModel/StateProvience';
import { CommonApiService } from '../../../Services/CommonApiService';

@Component({
  selector: 'app-Client-client-list',
  templateUrl:'./clientlist.component.html'

})
export class ClientListComponent{
  responseModel: ResponseModel = new ResponseModel();
  ClientList: Client[];
  State: StateProvience[];
  constructor(private app: AppComponent, private service: ClientApiService, private CommonService:CommonApiService, private router: Router) {
    app.Loading(true);
    this.CommonService.getAllState().subscribe(states => {
      this.State = states;
    },
      err => console.log(err)
    );
    this.service.getClientList().subscribe(Ouput => {
      this.ClientList = Ouput.response;
     
      app.Loading(false); 
    });
    
  }

  Edit(clientId) {
    this.router.navigate(['/Client/Client-edit'], { queryParams: { ClientId: clientId } });
  }
}
