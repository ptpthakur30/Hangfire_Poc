using Hangfire_Poc.Attributes;
using System;
using System.ComponentModel.DataAnnotations;
using M=System.Web.Mvc;

namespace Hangfire_Poc.Models
{
    public class Registration
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required(ErrorMessage = ValidationMessages.EmailRequiredMsg)]
        [StringLength(50, MinimumLength = 5)]
        [RegularExpression(@"^([A-Za-z0-9][^'!&\\#*$%^?<>()+=:;`~\[\]{}|/,₹€@ ][a-zA-z0-9-._][^!&\\#*$%^?<>()+=:;`~\[\]{}|/,₹€@ ]*\@[a-zA-Z0-9][^!&@\\#*$%^?<>()+=':;~`.\[\]{}|/,₹€ ]*\.[a-zA-Z]{2,6})$")]
        [Display(Name = "Email Address", Order = 2, GroupName = "FormInfo", Description = "Set the Email Adderess", AutoGenerateField = true)]
        [EmailAddress]
        [M.Remote("CheckUserName", "Registration")]
        public string Email { get; set; }

        [Display(Name = "Password", Order = 1, GroupName = "FormInfo", Description = "Set the Password", AutoGenerateField = true)]
        [Required(ErrorMessage = ValidationMessages.PasswordRequiredMsg)]
        [StringLength(16, ErrorMessage = ValidationMessages.PasswordLengthMsg, MinimumLength = 6)]
        [DataType(DataType.Password)]
        [MaxLength(10)]
        public string Password { get; set; }

        [Display(Name = "Confirm Password", Order = 3, GroupName = "FormInfo", Description = "Set the Confirm Password", AutoGenerateField = true)]
        [Compare("Password", ErrorMessage = ValidationMessages.ConfirmPasswordMsg)]
        [Required]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "Date of Birth",AutoGenerateField = true)]
        public DateTime DateofBirth { get; set; }

        [DataType(DataType.Currency)]
        [Required(ErrorMessage =ValidationMessages.IncomeMsg)]
        [DisplayFormat(NullDisplayText = "0.00", ApplyFormatInEditMode = true, ConvertEmptyStringToNull = false, DataFormatString = "{0:0.##}")]
        [Range(typeof(double), "0.00", "100.00")]
        [Display(Name = "Income", AutoGenerateField = true)]
        public double Income { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [MaxWordsAttributes(10,ErrorMessage ="{0} has too many words")]
        [Display(Name = "Address", AutoGenerateField = true)]
        public string Address { get; set; }
    }
    

}