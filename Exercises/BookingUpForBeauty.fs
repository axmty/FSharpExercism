module BookingUpForBeauty

open System

let schedule = DateTime.Parse

let hasPassed (appointmentDate: DateTime) : bool = DateTime.Now > appointmentDate

let isAfternoonAppointment (appointmentDate: DateTime) : bool =
    let hour = appointmentDate.Hour
    hour >= 12 && hour < 18

let description (appointmentDate: DateTime) : string =
    sprintf "You have an appointment on %O." appointmentDate

let anniversaryDate () : DateTime = new DateTime(DateTime.Now.Year, 9, 15)
