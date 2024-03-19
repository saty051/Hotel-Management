import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AddEmployee } from 'src/app/core/models/Add-Employee';
import { HotelAppDBService } from 'src/app/core/service/hotel-app-db.service';

@Component({
  selector: 'app-add-employee',
  templateUrl: './add-employee.component.html',
  styleUrls: ['./add-employee.component.css']
})
export class AddEmployeeComponent {
  addEmployee : AddEmployee = {
    hotelId : null,
    firstName : null,
    lastName : null,
    position: null
  };

  constructor(private service: HotelAppDBService, private route : Router)
  {

  }
  
  Add()
  {
    console.log(this.addEmployee);
    this.service.addEmployee(this.addEmployee).subscribe(
      {
        next:(response)=>
        {
          console.log("Added Successfully");
          alert("Added Successfully");
          this.route.navigate(['/employees']);
        }
      }
    );
  }
}
