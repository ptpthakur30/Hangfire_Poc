using System.ComponentModel.DataAnnotations;

namespace Hangfire_Poc.Models
{
    public class Login
    {
        [Required(ErrorMessage = "{0} is Required")]
        [Display(Name = "Email Address", Order = 2, GroupName = "FormInfo", Description = "Set the Email Adderess", AutoGenerateField = true)]
        [RegularExpression("\\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\\Z",ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [DataType(DataType.Password)]
        [Display(AutoGenerateField =true,Name = "Password")]
        public string Password { get; set; }
    }
}