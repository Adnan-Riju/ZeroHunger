using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZeroHungerAssignment.DTO
{
    public class RequestDTO
    {
        public int R_Id { get; set; }
        public string R_Name { get; set; }
        public string IteamName { get; set; }
        public int Quantity { get; set; }
        public string Location { get; set; }
        public string ExDate { get; set; }
        public string AssignEmployee { get; set; }
        public string Status { get; set; }
        public int RestaurantId { get; set; }
    }
}