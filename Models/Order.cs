using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_ViewModel_ModalWindow.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }

        public DateTime OrderDate { get; set; }

        public string Note { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}