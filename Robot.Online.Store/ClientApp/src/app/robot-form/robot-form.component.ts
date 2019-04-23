import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-robot-form',
  templateUrl: './robot-form.component.html'
})
export class RobotFormComponent {
  robot: Robot;

  constructor(private router: Router, private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
    this.robot = new Robot();
  }

  public register(form): void {
    this.robot.name = form.value.name;
    this.robot.description = form.value.description;
    this.robot.isAvailable = (form.value.select == 1);

    let apiUrl = this.baseUrl + 'api/robots';

    this.http.post<Robot>(apiUrl, this.robot).subscribe(() => {
      this.router.navigate(['/robot'])
    }, error => console.error(error));
  }

}
class Robot {
  name: string;
  description: string;
  isAvailable: boolean;
}
