using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TravelExpertsData
{
    [Index("AgentId", Name = "EmployeesCustomers")]
    public partial class Customer
    {
        public Customer()
        {
            Bookings = new HashSet<Booking>();
            CreditCards = new HashSet<CreditCard>();
            CustomersRewards = new HashSet<CustomersReward>();
        }

        [Key]
        public int CustomerId { get; set; }

        [Required(ErrorMessage ="Please add your first name")]
        [Display(Name = "First Name")]
        [StringLength(25)]
        public string CustFirstName { get; set; } = null!;

        [Required(ErrorMessage = "Please add your last name")]
        [Display(Name = "Last Name")]
        [StringLength(25)]
        public string CustLastName { get; set; } = null!;

        [Required(ErrorMessage = "Please add your address")]
        [Display(Name = "Address")]
        [StringLength(75)]
        public string CustAddress { get; set; } = null!;

        [Required(ErrorMessage = "Please add your city")]
        [Display(Name = "City")]
        [StringLength(50)]
        public string CustCity { get; set; } = null!;

        [Required(ErrorMessage = "Please add your province")]
        [Display(Name = "Province")]
        [StringLength(2)]
        public string CustProv { get; set; } = null!;


        //[RegularExpression("^(?:[A-Za-z]\\d[A-Za-z][- ]?){2}\\d[A-Za-z]\\d$|^\\d{5}(?:[- ]\\d{4})?$",
        //ErrorMessage = "Format needs to be A1A 1A1 (Canada) or 99999 (US) or 99999-9999 (US)")]
        [Required(ErrorMessage = "Please add your postal code")]
        [RegularExpression("^[A-Za-z]\\d[A-Za-z][- ]?\\d[A-Za-z]\\d$",
                            ErrorMessage = "Format needs to be A1A 1A1")]
        [Display(Name = "Postal Code")]
        [StringLength(7)]
        public string CustPostal { get; set; } = null!;

        [Required(ErrorMessage = "Please add your country")]
        [StringLength(25)]
        [Display(Name ="Country")]
        public string? CustCountry { get; set; }

        [Required(ErrorMessage ="Please add your home phone number")]
        [Display(Name = "Phone Number")]
        [RegularExpression("^\\(?([0-9]{3})\\)?[-.]?([0-9]{3})[-.]?([0-9]{4})$",
                            ErrorMessage = "Format of phone number is: (xxx) xxx-xxxx or xxx-xxx-xxxx")]
        [StringLength(20)]
        public string? CustHomePhone { get; set; }

        [RegularExpression("^\\(?([0-9]{3})\\)?[-.]?([0-9]{3})[-.]?([0-9]{4})$",
                            ErrorMessage = "Format of phone number is: (xxx) xxx-xxxx or xxx-xxx-xxxx")]
        [Display(Name = "Business Phone Number")]
        [StringLength(20)]
        public string CustBusPhone { get; set; } //= null!;

        [Required(ErrorMessage ="Please add your email")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        [StringLength(50)]
        [Display(Name ="Email")]
        public string CustEmail { get; set; } //= null!;

        public int? AgentId { get; set; }

        [Required(ErrorMessage ="Please add a username")]
        [StringLength(30)]
        [Unicode(false)]
        public string Username { get; set; } = null!;

        [Required(ErrorMessage = "Please add a password")]
        [StringLength(30)]
        [Unicode(false)]
        public string Password { get; set; } = null!;

        [Required(ErrorMessage ="Please add the same password from the password field")]
        [Compare("Password")]
        [StringLength(30)]
        [NotMapped]
        public string ConfirmPassword { get; set; } = null!;


        // navigation properties
        [ForeignKey("AgentId")]
        [InverseProperty("Customers")]
        public virtual Agent? Agent { get; set; }
        [InverseProperty("Customer")]
        public virtual ICollection<Booking> Bookings { get; set; }
        [InverseProperty("Customer")]
        public virtual ICollection<CreditCard> CreditCards { get; set; }
        [InverseProperty("Customer")]
        public virtual ICollection<CustomersReward> CustomersRewards { get; set; }
    }
}
