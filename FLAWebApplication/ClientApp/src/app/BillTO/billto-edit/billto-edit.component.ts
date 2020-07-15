import { Component, Injectable } from '@angular/core'
import { FormGroup, NgForm } from '@angular/forms';
import { UserLogin } from '../../../ViewModel/UserLogin';
import { ResponseModel } from '../../../ViewModel/ResponseModel';
import { BaseTableApiService } from '../../../Services/BaserTableService';
import { StateProvience } from '../../../ViewModel/StateProvience';
import { BillTo } from '../../../ViewModel/BillTo';
import { InvoicePreference } from '../../../ViewModel/CommonEnum';
import { Router, ActivatedRoute } from '@angular/router';
import { map } from 'rxjs/operators';
import { AppComponent } from '../../app.component';

@Component({
  selector: 'app-BillTo-billto-edit',
  templateUrl: './billto-edit.component.html',

})
@Injectable({ providedIn: 'root' })
export class EditBillToComponent {
  State: StateProvience[];
  Billto: BillTo = new BillTo;
  keys = [];
  BillToId: number;
  constructor(private activateRouter: ActivatedRoute, private BaseService: BaseTableApiService, private route: Router, private app:AppComponent) {
    
     this.activateRouter.queryParams.subscribe(data => { this.BillToId = Number(data["BilltoId"]) });/*.subscribe(data => { this.BillToId = Number(data["BilltoId"]) })*/
    //this.BillToId = Number(this.activateRouter.snapshot.queryParams('BilltoId'));
    let UserDetail = localStorage.getItem('currentUser');
    this.User = JSON.parse(UserDetail);
    BaseService.getAllState().subscribe(states => {
      this.State = states;
    },
      err => console.log(err)
    );


    for (var enumMember in InvoicePreference) {
      if (!isNaN(parseInt(enumMember, 10))) {
        this.keys.push({ key: enumMember, value: InvoicePreference[enumMember] });
        // Uncomment if you want log
        // console.log("enum member: ", value[enumMember]);
      }
    }
    this.BaseService.GetBillToEdit(this.User.clientId, this.BillToId).subscribe(data => {
      
      this.Billto = data.response;
    },
      err => console.log(err));
   
  }
  
  billtoEditForm: FormGroup;
  User: UserLogin;
  responseModel: ResponseModel;
  onSubmit(form: NgForm) {
    

    if (form.status != "INVALID") {
      this.BaseService.EditBillto(form.value, this.User).subscribe(respone => {
        
        this.responseModel = respone;
        if (this.responseModel.status == 1) {
          form.reset();
          this.app.ShowSuccess("Detail Updated Successfully..");
        }
        else {
          this.app.ShowError(this.responseModel.message);
        }
       
      },
        err => console.log(err)
      );
    }


  }
} 
