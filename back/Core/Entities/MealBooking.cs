using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class MealBooking: BaseEntity
    {
        public string StudentSSN { get; set; }    
        public string StudentName { get; set; }    
        public string StudentEmail { get; set; }    
        public DateTime BookingDate { get; set; } = DateTime.Now;
    }
}