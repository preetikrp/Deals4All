using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Deals4All.Models
{
    public class Coupon
    {
        
        [Key]
        public int CouponMasterID { get; set; }

        [DisplayName("Coupon Name")]
        [Required(ErrorMessage = "Please enter Coupon Name")]
        public String CouponName { get; set; }

        [DisplayName("Coupon Description")]
        [Required(ErrorMessage = "Please enter Coupon Description")]
        public String CouponDescription { get; set; }

        [DisplayName("Merchant ID")]
        [Required(ErrorMessage = "Please enter Merchant ID")]
        public int MerchantID { get; set; }

        [DisplayName("StartDate")]
        [Required(ErrorMessage = "Please enter Start Date")]
        public DateTime StartDate { get; set; }

        [DisplayName("EndDate")]
        [Required(ErrorMessage = "Please enter End Date")]
        public DateTime EndDate { get; set; }

        [DisplayName("Status")]
        [Required(ErrorMessage = "Is this Coupon Active")]
        public String Status { get; set; }

        [DisplayName("Commission Type")]
        [Required(ErrorMessage = "Select Commission Type")]
        public String CommissionType { get; set; }

        [DisplayName("Commision Value")]
        [Required(ErrorMessage = "Enter Commition Valie")]
        public String CommissionValue { get; set; }

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