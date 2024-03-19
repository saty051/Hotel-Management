import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Room } from 'src/app/core/models/Room';
import { HotelAppDBService } from 'src/app/core/service/hotel-app-db.service';

@Component({
  selector: 'app-update-room',
  templateUrl: './update-room.component.html',
  styleUrls: ['./update-room.component.css']
})
export class UpdateRoomComponent {
  id: number = 0;
  updateRoom : Room = {
    roomId: 0,
    hotelId: 0,
    roomNumber: 0,
    capacity: 0,
    price: 0
  }
  constructor(private service : HotelAppDBService, private router : ActivatedRoute, private route:Router) {}
  ngOnInit()
  {
    this.id = Number(this.router.snapshot.paramMap.get('id'));
    console.log(this.id);

    if(this.id)
    {
      this.service.getRoomById(this.id).subscribe
      (
        {
          next:(response)=>this.updateRoom = response
        }
      )
    }
  }

  Update()
  {
    this.service.updateRoom(this.updateRoom).subscribe
    (
      {
        next:(response)=>
        {
          console.log("Updated Successfully");
          alert("Updated Successfully");
          this.route.navigate(['/rooms']);
        }
      }
    )
  }
}
