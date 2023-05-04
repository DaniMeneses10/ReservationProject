using System.Collections.Generic;
using System;

namespace ReservationsProject.Models.Responses
{
    public class ReservationResponse
    {
        public bool IsSuccessful { get; set; }
        public List<string> Errors { get; set; }        
    }
}
