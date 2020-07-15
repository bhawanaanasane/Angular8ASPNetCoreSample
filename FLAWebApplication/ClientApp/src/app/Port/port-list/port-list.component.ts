import { Component, Injectable } from '@angular/core'
import { UserLogin } from '../../../ViewModel/UserLogin';
import { StateProvience } from '../../../ViewModel/StateProvience';
import { ResponseModel } from '../../../ViewModel/ResponseModel';
import { BaseTableApiService } from '../../../Services/BaserTableService';
import { Router } from '@angular/router';
import { AppComponent } from '../../app.component';
import { PortModel } from '../../../ViewModel/PortModel';
@Component({
  selector: "App-Port-port-list",
  templateUrl: "./port-list.component.html"
})
@Injectable({ providedIn: 'root' })
export class PortListComponent {
  User: UserLogin;
  State: StateProvience[];
  responseModel: ResponseModel;
  PortList: PortModel[];

  constructor(private BaseService: BaseTableApiService, private router: Router, private App: AppComponent)
  {

    let UserDetail = localStorage.getItem('currentUser');
    this.User = JSON.parse(UserDetail);
    BaseService.getAllState().subscribe(states => {
      this.State = states.response;
    },
      err => console.log(err)
    );
    var data = 0;
    this.BaseService.GetPortList(this.User.clientId).subscribe(respone => {

      this.PortList = respone.response;

    },
      err => console.log(err)
    );
  }

  GetStateName(stateId)
  {
    return this.State.filter(a => a.id == stateId).map(x=>x.name);
    
  }
  Edit(portid) {

    this.router.navigate(['/PortEdit/port-edit'], { queryParams: { PortId: portid } });
  }
  checkboxFunction(condition)
  {
    if (condition == true) {
      return "checked";
    } else {
      return "";
    }

  }
  Delete(portid) {

    this.BaseService.DeleteBillToService(this.User.clientId, portid).subscribe(response => {
      this.responseModel = response;
      if (this.responseModel.status == 1) {
        this.App.ShowSuccess("Deleted Successfully...");

        this.PortList = this.PortList.filter(obj => obj.Id !== portid);
      }
      else {
        this.App.ShowError(this.responseModel.message);
      }
    },
      err => console.log(err)
    );
  }
}
