import { Component, Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { FormGroup, NgForm } from "@angular/forms";
import { PermissionService } from "../../../Services/PermissionService";
import { UserLogin } from "../../../ViewModel/UserLogin";
import { ResponseModel } from "../../../ViewModel/ResponseModel";
@Component({
  selector: 'app-Permission-create-role',
  templateUrl: './create-role.component.html',
})
@Injectable({ providedIn: 'root' })
export class CreateRoleComponent {
  constructor(private RoleService: PermissionService,private route: Router) {

  }
  userCreateRole: FormGroup;
  User: UserLogin;
  response: ResponseModel;
  ngOnInit() {
    
    //this.clientCreateForm = this.formBuilder.group({
    //  name: ['', Validators.required],
    //  userName: ['', Validators.required],
    //  password: ['', Validators.required]
    //});
    let UserDetail = localStorage.getItem('currentUser');
    this.User = JSON.parse(UserDetail);
  }

  onSubmit(form: NgForm) {
   
    form.value.name;
    this.RoleService.CreateRole(form.value.RoleName, this.User.clientId, this.User.id).subscribe(role => {
      this.response = role;
    },
      err => console.log(err)
    );
  }
}
