export interface AddReservation{
    roomId: number |null,
    customerId: number |null,
    guestName: string |null,
    checkInDate: Date |null,
    checkOutDate: Date |null,
}