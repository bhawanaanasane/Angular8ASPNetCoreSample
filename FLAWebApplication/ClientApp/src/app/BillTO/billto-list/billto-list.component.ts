import { Component } from '@angular/core'
import { UserLogin } from '../../../ViewModel/UserLogin';
import { BaseTableApiService } from '../../../Services/BaserTableService';
import { ResponseModel } from '../../../ViewModel/ResponseModel';
import { BillTo } from '../../../ViewModel/BillTo';
import { from } from 'rxjs';
import { StateProvience } from '../../../ViewModel/StateProvience';
import { Route, Router } from '@angular/router';
import { AppComponent } from '../../app.component';

@Component({
  selector: 'app-BillTO-billto-list',
  templateUrl: './billto-list.component.html',
})
export class BillToListComponent {
  User: UserLogin;
  State: StateProvience[];
  responseModel: ResponseModel;
  BillToList: BillTo[];

  constructor(private BaseService: BaseTableApiService, private router: Router, private App: AppComponent) {
  
    let UserDetail = localStorage.getItem('currentUser');
    this.User = JSON.parse(UserDetail);
    BaseService.getAllState().subscribe(states => {
      this.State = states;
    },
      err => console.log(err)
    );
    this.BaseService.GetBillToList( this.User.clientId).subscribe(respone => {
      
      this.BillToList = respone.response;
     
    },
      err => console.log(err)
    );
  }
  Edit(BillToId) {
    
    this.router.navigate(['/BilltoEdit/billto-edit'], { queryParams: { BilltoId: BillToId } });
  }
  Delete(BillToId) {
    
    this.BaseService.DeleteBillToService(this.User.clientId, BillToId).subscribe(response => {
      this.responseModel = response;
      if (this.responseModel.status == 1) {
        this.App.ShowSuccess("Deleted Successfully...");
        
        this.BillToList = this.BillToList.filter(obj => obj.Id !== BillToId);
      }
      else {
        this.App.ShowError(this.responseModel.message);
      }
    },
      err => console.log(err)
    );
  }
}
