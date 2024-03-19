import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AddRoom } from 'src/app/core/models/Add-Room';
import { HotelAppDBService } from 'src/app/core/service/hotel-app-db.service';

@Component({
  selector: 'app-add-room',
  templateUrl: './add-room.component.html',
  styleUrls: ['./add-room.component.css']
})
export class AddRoomComponent {
  addRoom : AddRoom = {
    hotelId: null,
    roomNumber: null,
    capacity: null,
    price: null,
  };

  constructor(private service: HotelAppDBService, private route : Router)
  {

  }
  
  Add()
  {
    console.log(this.addRoom);
    this.service.addRoom(this.addRoom).subscribe(
      {
        next:(response)=>
        {
          console.log("Added Successfully");
          alert("Added Successfully");
          this.route.navigate(['/rooms']);
        }
      }
    );
    
  }
}
