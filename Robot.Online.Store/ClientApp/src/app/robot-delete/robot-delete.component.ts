import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-robot-delete',
  template: '`<ng-content></ng-content>`'
})

export class RobotDeleteComponent {

  constructor(private route: ActivatedRoute, private router: Router, private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {

  }

  ngOnInit() {
    let robotId = this.route.snapshot.params.id;

    if (robotId != undefined) {
      let apiUrl = this.baseUrl + '/api/robots/' + robotId;
      this.http.delete(apiUrl).subscribe(() => {
        this.router.navigate(['/robot'])
      }, error => console.error(error));
    }
  }



}

