using Microsoft.Owin.BuilderProperties;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Policy;
using System.Web;

namespace MVC_ViewModel_ModalWindow.Models
{
    public class Customer
    {
        [Key] 
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Name is Required!")]
        [StringLength(30, ErrorMessage = "Name Must Be in 15 Character")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Email Must be Required")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Enter Customer Valid Email")]
        public string Email { get; set; }
        public string Gender { get; set; }

        [Required(ErrorMessage = "Enter Cellphone No.")]
        [MaxLength(11, ErrorMessage = "Contact Number Must be greater than 11 Digit")]
        [MinLength(11, ErrorMessage = "Contact Number Can't be less than 11 Digit")]
        public string Phone { get; set; }
       public string Address { get; set; }
        public string Image { get; set; }

        public virtual ICollection<Order> Order { get; set; }
    }
}