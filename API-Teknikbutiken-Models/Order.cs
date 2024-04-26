using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Teknikbutiken_Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public DateTime OrderPlace {  get; set; }
        public int CustomerId { get; set; }

        
        public Customer Customer { get; set; }
    }
}
