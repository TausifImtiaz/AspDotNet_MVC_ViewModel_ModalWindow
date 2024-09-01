using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace MVC_ViewModel_ModalWindow.Models
{
    public class DataSeeder
    {
        public void Seed(ApplicationDbContext context)
        {
            context.Customers.AddOrUpdate(
                c => c.CustomerName,
                new Customer
                {
                    CustomerName= "Amin",
                    Email = "moin@mail.com",
                    Phone = "87549269541",
                    Address = "Ctg"
                },
                new Customer
                {
                    CustomerName="Momin",
                    Email = "joshim@mail.com",
                    Phone = "87541269541",
                    Address = "Ctg"
                }
                );

                        context.Supplliers.AddOrUpdate(
                c => c.SupplierName,
                new Suppllier
                {
                    SupplierName = "Aman Ali",
                    Email = "aman@mail.com",
                    Phone = "15421365247",
                    Address = "Dhk"
                },
                new Suppllier
                {
                    SupplierName = "Zaman Khan",
                    Email = "Zaman@mail.com",
                    Phone = "54126983254",
                    Address = "Cum"
                }
                );
        }
    }
}