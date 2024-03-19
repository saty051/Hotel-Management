import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Customer } from '../../models/Customer';
import { HotelAppDBService } from '../../service/hotel-app-db.service';

@Component({
  selector: 'app-manage-customers',
  templateUrl: './manage-customers.component.html',
  styleUrls: ['./manage-customers.component.css']
})
export class ManageCustomersComponent {

  allCustomers : Customer[] = [];

  constructor(private service: HotelAppDBService, private route : Router)
  {

  }

  ngOnInit()
  {
    this.service.getAllCustomers().subscribe
    (
      (data) =>
      {
        this.allCustomers = data;
        console.log(this.allCustomers);
      }
    );
  }

  Delete(id : number)
  {
    this.service.deleteCustomerById(id).subscribe(
      {
        next:(response)=>{
          console.log("Deleted Successfully");

        }
        
      }
    )
  }

  Update(id:number)
  {
    this.route.navigate(['/updateCustomer',id]);
  }

}
