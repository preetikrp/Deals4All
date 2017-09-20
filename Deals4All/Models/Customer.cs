using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Deals4All.Models
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }

        [DisplayName("First Name")]
        [Required(ErrorMessage = "Please enter First Name")]
        public String CustomerFName { get; set; }

        [DisplayName("Last Name")]
        [Required(ErrorMessage = "Please enter Last Name")]
        public String CustomerLName { get; set; }

        [DisplayName("Email Address")]
        [Required(ErrorMessage = "Please enter Email Address")]
        public String CustomerEmail { get; set; }

        [DisplayName("Mobile Number")]
        [Required(ErrorMessage = "Please enter Mobile Number")]
        public String CustomerMobile { get; set; }

        public String CustomerPhone { get; set; }

        [DisplayName("Address")]
        [Required(ErrorMessage = "Please enter Address")]
        public String CustomerAddress { get; set; }

        [DisplayName("City")]
        [Required(ErrorMessage = "Please enter City")]
        public String CustomerCity { get; set; }

        [DisplayName("State")]
        [Required(ErrorMessage = "Please select Address")]
        public String CustomerState { get; set; }

        [DisplayName("Zip")]
        [Required(ErrorMessage = "Please enter Zip")]
        public String CustomerZip { get; set; }

        public String CustomerCountry { get; set; }

        [DisplayName("Eating Out")]
        public Boolean Pref1 { get; set; }

        [DisplayName("Movies/Shows")]
        public Boolean Pref2 { get; set; }

        [DisplayName("Outdoor Activities")]
        public Boolean Pref3 { get; set; }

        [DisplayName("Family Fun")]
        public Boolean Pref4 { get; set; }

        [DisplayName("Deals")]
        public Boolean Pref5 { get; set; }

    }
}