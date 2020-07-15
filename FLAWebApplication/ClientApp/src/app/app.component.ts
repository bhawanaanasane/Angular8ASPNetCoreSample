import { Component } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
})
export class AppComponent {
  loading: boolean = false;
  hideName: boolean = true;
  constructor(private toast:ToastrService) {
    
    if (localStorage.getItem('currentUser') != '' && localStorage.getItem('currentUser')!=null) {
      this.hideName = true;
    }
    else {
      this.hideName = false;
    }
  }

  public Loading(Load: boolean) {
    this.loading = Load;
  }
  public ShowSuccess(Message) {
    this.toast.success(Message, "Success");
  }
  public ShowError(Message) {
    this.toast.error(Message, "Error");
  }
  public ShowWarning(Message) {
    this.toast.warning(Message, "Alert");
  }
  public ngOnInit() {
  
    this.loadScript('assets/js/es5/script.min.js');
    this.loadScript('assets/js/es5/sidebar.large.script.min.js');
    this.loadScript('assets/js/es5/echart.options.min.js');
    //this.loadScript('assets/js/toastr.script.js');
  };

  public loadScript(url) {
    let node = document.createElement('script');
    node.src = url;
    node.type = 'text/javascript';
    document.getElementsByTagName('head')[0].appendChild(node);
  }

  title = 'app';
  isPresent = ""
}


