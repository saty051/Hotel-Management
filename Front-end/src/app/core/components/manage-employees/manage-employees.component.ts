import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Employee } from '../../models/Employee';
import { HotelAppDBService } from '../../service/hotel-app-db.service';

@Component({
  selector: 'app-manage-employees',
  templateUrl: './manage-employees.component.html',
  styleUrls: ['./manage-employees.component.css']
})
export class ManageEmployeesComponent {
  allEmployees : Employee[] = [];

  constructor(private service: HotelAppDBService, private route : Router)
  {

  }

  ngOnInit()
  {
    this.service.getAllEmployees().subscribe
    (
      (data) =>
      {
        this.allEmployees = data;
        console.log(this.allEmployees);
      }
    );
  }

  Delete(id : number)
  {
    this.service.deleteEmployeeById(id).subscribe(
      {
        next:(response)=>{
          console.log("Deleted Successfully");

        }
        
      }
    )
  }

  Update(id:number)
  {
    this.route.navigate(['/updateEmployee',id]);
  }
}
