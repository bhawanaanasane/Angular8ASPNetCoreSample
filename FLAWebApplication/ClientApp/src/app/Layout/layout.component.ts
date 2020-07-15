import { Component } from '@angular/core';

@Component({
  selector: "app-Layout",
  templateUrl: "layout.component.html",
})

export class LayoutComponent {
  hideName: boolean = true;
  constructor() {
    
    if (localStorage.getItem('currentUser') != '' && localStorage.getItem('currentUser') != null) {
      this.hideName = true;
    }
    else {
      this.hideName = false;
    }
  }

  public ngOnInit() {

    this.loadScript('assets/js/es5/script.min.js');
    this.loadScript('assets/js/es5/sidebar.large.script.min.js');
    this.loadScript('assets/js/es5/echart.options.min.js');

  };

  public loadScript(url) {
    let node = document.createElement('script');
    node.src = url;
    node.type = 'text/javascript';
    document.getElementsByTagName('head')[0].appendChild(node);
  }
}
