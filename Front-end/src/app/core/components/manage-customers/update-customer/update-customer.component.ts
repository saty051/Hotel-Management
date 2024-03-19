import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Customer } from 'src/app/core/models/Customer';
import { HotelAppDBService } from 'src/app/core/service/hotel-app-db.service';

@Component({
  selector: 'app-update-customer',
  templateUrl: './update-customer.component.html',
  styleUrls: ['./update-customer.component.css']
})
export class UpdateCustomerComponent {
  id: number = 0;
  updateCustomer : Customer = {
    customerId : 0,
    firstName : "",
    lastName : "",
    email : "",
    phone : ""
  }
  constructor(private service : HotelAppDBService, private router : ActivatedRoute, private route:Router) {}
  ngOnInit()
  {
    this.id = Number(this.router.snapshot.paramMap.get('id'));
    console.log(this.id);

    if(this.id)
    {
      this.service.getCustomerById(this.id).subscribe
      (
        {
          next:(response)=>this.updateCustomer = response
        }
      )
    }
  }

  Update()
  {
    this.service.updateCustomer(this.updateCustomer).subscribe
    (
      {
        next:(response)=>
        {
          console.log("Updated Successfully");
          alert("Updated Successfully");
          this.route.navigate(['/customers']);
        }
      }
    )
  }
}
