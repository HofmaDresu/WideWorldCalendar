using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WideWorldCalendar.Persistence.Models
{
    public class GameNotification
    {
        public int TeamId { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public DateTime? FirstGameTime { get; set; }
    }
}
