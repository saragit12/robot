import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-robot-data',
  templateUrl: './robot-data.component.html'
})
export class RobotDataComponent {
  public robots: Robot[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Robot[]>(baseUrl + '/api/robots').subscribe(result => {
      this.robots = result;
    }, error => console.error(error));

  }

}

interface Robot {
  id: number;
  name: string;
  description: string;
  isAvailable: boolean;
}
