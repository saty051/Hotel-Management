import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddCustomerComponent } from './core/components/manage-customers/add-customer/add-customer.component';
import { ManageCustomersComponent } from './core/components/manage-customers/manage-customers.component';
import { UpdateCustomerComponent } from './core/components/manage-customers/update-customer/update-customer.component';
import { AddEmployeeComponent } from './core/components/manage-employees/add-employee/add-employee.component';
import { ManageEmployeesComponent } from './core/components/manage-employees/manage-employees.component';
import { UpdateEmployeeComponent } from './core/components/manage-employees/update-employee/update-employee.component';
import { ManageHotelsComponent } from './core/components/manage-hotels/manage-hotels.component';
import { AddHotelsComponent } from './core/components/manage-hotels/add-hotels/add-hotels.component';
import { UpdateHotelComponent } from './core/components/manage-hotels/update-hotel/update-hotel.component';
import { ManageReservationsComponent } from './core/components/manage-reservations/manage-reservations.component';
import { UpdateReservationComponent } from './core/components/manage-reservations/update-reservation/update-reservation.component';
import { AddReservationComponent } from './core/components/manage-reservations/add-reservation/add-reservation.component';
import { ManageRoomsComponent } from './core/components/manage-rooms/manage-rooms.component';
import { AddRoomComponent } from './core/components/manage-rooms/add-room/add-room.component';
import { UpdateRoomComponent } from './core/components/manage-rooms/update-room/update-room.component';



const routes: Routes = [
  { path: 'hotels', component: ManageHotelsComponent },
  { path: 'addHotel', component: AddHotelsComponent },
  {path: 'updateHotel/:id', component: UpdateHotelComponent },

  { path: 'rooms', component: ManageRoomsComponent },
  { path: 'addRoom', component: AddRoomComponent },
  { path: 'updateRoom/:id', component: UpdateRoomComponent },

  { path: 'employees', component: ManageEmployeesComponent },
  { path: 'addEmployee', component: AddEmployeeComponent },
  {path: 'updateEmployee/:id', component: UpdateEmployeeComponent },
  
  { path: 'customers', component: ManageCustomersComponent },
  { path: 'addCustomer', component: AddCustomerComponent },
  { path: 'updateCustomer/:id', component: UpdateCustomerComponent },

  { path: 'reservations', component: ManageReservationsComponent },
  { path: 'addReservation', component: AddReservationComponent },
  { path: 'updateReservation/:id', component: UpdateReservationComponent },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}