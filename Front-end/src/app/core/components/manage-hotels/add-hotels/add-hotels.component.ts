import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AddHotel } from 'src/app/core/models/Add-Hotel';
import { HotelAppDBService } from 'src/app/core/service/hotel-app-db.service';

@Component({
  selector: 'app-add-hotels',
  templateUrl: './add-hotels.component.html',
  styleUrls: ['./add-hotels.component.css']
})
export class AddHotelsComponent {
  addHotel : AddHotel = {
    name: null,
    address: null,
    rating : null
  };

  constructor(private service: HotelAppDBService, private route : Router)
  {

  }
  
  Add()
  {
    console.log(this.addHotel);
    this.service.addHotel(this.addHotel).subscribe(
      {
        next:(response)=>
        {
          console.log("Added Successfully");
          alert("Added Successfully");
           this.route.navigate(['/hotels']);
        }
      }
    );
  }
}
