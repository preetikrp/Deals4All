using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace Deals4All.Models
{
    public class Merchant
    {
        [Key]
        public int MerchantID { get; set; }

        [DisplayName("First Name")]
        [Required(ErrorMessage = "Please enter First Name")]
        public String MerchantFName { get; set; }

        [DisplayName("Last Name")]
        [Required(ErrorMessage = "Please enter Last Name")]
        public String MerchantLName { get; set; }

        [DisplayName("Email Address")]
        [Required(ErrorMessage = "Please enter Email Address")]
        public String MerchantEmail { get; set; }

        [DisplayName("Mobile Number")]
        [Required(ErrorMessage = "Please enter Mobile Number")]
        public String MerchantMobile { get; set; }

        public String MerchantPhone { get; set; }

        [DisplayName("Business Name")]
        [Required(ErrorMessage = "Please enter Business Name")]
        public String BusinessName { get; set; }

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

        public String BusinessCountry { get; set; }


    }
}