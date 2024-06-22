using System;
using System.ComponentModel.DataAnnotations;

namespace RestaurantManagement.Models
{
    public class Reservation
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter your name.")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Please enter a reservation date.")]
        [DataType(DataType.Date)]
        public DateTime ReservationDate { get; set; }

        [Required(ErrorMessage = "Please select the number of guests.")]
        public int NumberOfGuests { get; set; }

        public string SpecialRequests { get; set; }
    }
}
