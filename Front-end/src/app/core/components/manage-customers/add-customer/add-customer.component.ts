import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AddCustomer } from 'src/app/core/models/Add-Customer';
import { HotelAppDBService } from 'src/app/core/service/hotel-app-db.service';

@Component({
  selector: 'app-add-customer',
  templateUrl: './add-customer.component.html',
  styleUrls: ['./add-customer.component.css']
})
export class AddCustomerComponent {
  addCustomer : AddCustomer = {
    firstName : "",
    lastName : "",
    email : "",
    phone : ""
  };

  constructor(private service: HotelAppDBService, private route : Router)
  {

  }
  
  Add()
  {
    console.log(this.addCustomer);
    this.service.addCustomer(this.addCustomer).subscribe(
      {
        next:(response)=>
        {
          console.log("Added Successfully");
          alert("Added Successfully");
          this.route.navigate(['/customers']);
        }
      }
    );
    
  }

  
}
