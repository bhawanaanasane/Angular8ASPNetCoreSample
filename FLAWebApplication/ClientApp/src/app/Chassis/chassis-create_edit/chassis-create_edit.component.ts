import { Component } from '@angular/core'
import { AppComponent } from '../../app.component';

@Component({
  selector: "app-Chassis-chassis-create_edit",
  templateUrl: "./chassis-create_edit.component.html",
})
export class CreateEditChassisComponent {
  constructor(private app: AppComponent) { }

  sucess() {
    this.app.ShowSuccess("This Is New Form...");
  }
}
