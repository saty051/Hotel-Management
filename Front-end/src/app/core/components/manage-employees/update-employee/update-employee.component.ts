import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Employee } from 'src/app/core/models/Employee';
import { HotelAppDBService } from 'src/app/core/service/hotel-app-db.service';

@Component({
  selector: 'app-update-employee',
  templateUrl: './update-employee.component.html',
  styleUrls: ['./update-employee.component.css']
})
export class UpdateEmployeeComponent {
  id: number = 0;
  updateEmployee : Employee = {
    employeeId : 0,
    hotelId : 0,
    firstName : "",
    lastName : "",
    position: "",
  }
  constructor(private service : HotelAppDBService, private router : ActivatedRoute, private route:Router) {}
  ngOnInit()
  {
    this.id = Number(this.router.snapshot.paramMap.get('id'));
    console.log(this.id);

    if(this.id)
    {
      this.service.getEmployeeById(this.id).subscribe
      (
        {
          next:(response)=>this.updateEmployee = response
        }
      )
    }
  }

  Update()
  {
    this.service.updateEmployee(this.updateEmployee).subscribe
    (
      {
        next:(response)=>
        {
          console.log("Updated Successfully");
          alert("Updated Successfully");
          this.route.navigate(['/employees']);
        }
      }
    )
  }
}
