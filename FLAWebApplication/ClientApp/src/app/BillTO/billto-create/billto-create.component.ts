import {Component, Injectable} from '@angular/core'
import { FormGroup, NgForm } from '@angular/forms';
import { UserLogin } from '../../../ViewModel/UserLogin';
import { ResponseModel } from '../../../ViewModel/ResponseModel';
import { BaseTableApiService } from '../../../Services/BaserTableService';
import { StateProvience } from '../../../ViewModel/StateProvience';
import { BillTo } from '../../../ViewModel/BillTo';
import { InvoicePreference } from '../../../ViewModel/CommonEnum';
import { AppComponent } from '../../app.component';

@Component({
  selector: 'app-BillTo-billto-create',
  templateUrl: './billto-create.component.html',

})
@Injectable({ providedIn: 'root' })
export class CreateBillToComponent{
  State: StateProvience[];
  Billto: BillTo = new BillTo;
  keys = [];
  constructor(private BaseService: BaseTableApiService, private app:AppComponent) {
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
  }
  billtoCreateForm: FormGroup;
  User: UserLogin;
  responseModel: ResponseModel;
  onSubmit(form: NgForm) {
    
  
    if (form.status != "INVALID") {
      this.BaseService.CreateBillto(form.value, this.User).subscribe(respone => {
        
        this.responseModel = respone;
        if (this.responseModel.status == 1) {
          this.app.ShowSuccess("Save Successfully...");
          form.reset();
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
