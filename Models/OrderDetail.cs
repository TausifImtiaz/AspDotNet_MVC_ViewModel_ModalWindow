using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace MVC_ViewModel_ModalWindow.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }

        public int OrderId { get; set; }

        public int ProductId { get; set; }
        [Display(Name = "Order Quantity")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than zero.")]
        public int Quantity { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Quantity must be a positive number.")]
        public decimal UnitPrice { get; set; }

        public virtual Order Order { get; set; }
    }
}