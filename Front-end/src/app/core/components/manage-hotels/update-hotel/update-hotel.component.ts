import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Hotel } from 'src/app/core/models/Hotel';
import { HotelAppDBService } from 'src/app/core/service/hotel-app-db.service';

@Component({
  selector: 'app-update-hotel',
  templateUrl: './update-hotel.component.html',
  styleUrls: ['./update-hotel.component.css']
})
export class UpdateHotelComponent {
  id: number = 0;
  updateHotel : Hotel = {
    hotelId : 0,
    name : "",
    address : "",
    rating: 0,
  }
  constructor(private service : HotelAppDBService, private router : ActivatedRoute, private route:Router) {}
  ngOnInit()
  {
    this.id = Number(this.router.snapshot.paramMap.get('id'));
    console.log(this.id);

    if(this.id)
    {
      this.service.getHotelById(this.id).subscribe
      (
        {
          next:(response)=>this.updateHotel = response
        }
      )
    }
  }

  Update()
  {
    this.service.updateHotel(this.updateHotel).subscribe
    (
      {
        next:(response)=>
        {
          console.log("Updated Successfully");
          alert("Updated Successfully");
          this.route.navigate(['/hotels']);
        }
      }
    )
  }
}
