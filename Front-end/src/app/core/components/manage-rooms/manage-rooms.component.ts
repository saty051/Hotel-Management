import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Room } from '../../models/Room';
import { HotelAppDBService } from '../../service/hotel-app-db.service';

@Component({
  selector: 'app-manage-rooms',
  templateUrl: './manage-rooms.component.html',
  styleUrls: ['./manage-rooms.component.css']
})
export class ManageRoomsComponent {
  allRooms : Room[] = [];

  constructor(private service: HotelAppDBService, private route : Router)
  {

  }

  ngOnInit()
  {
    this.service.getAllRooms().subscribe
    (
      (data) =>
      {
        this.allRooms = data;
        console.log(this.allRooms);
      }
    );
  }

  Delete(id : number)
  {
    this.service.deleteRoomById(id).subscribe(
      {
        next:(response)=>{
          console.log("Deleted Successfully");

        }
        
      }
    )
  }

  Update(id:number)
  {
    this.route.navigate(['/updateRoom',id]);
  }

}
