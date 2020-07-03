namespace Hangfire_Poc.Models
{
    public static class ValidationMessages
    {
        public const string EmailRequiredMsg = "Please enter email address";
        public const string PasswordRequiredMsg = "Please enter a password";
        public const string ConfirmPasswordMsg = "Password does not match";
        public const string PasswordLengthMsg = "Password length (6-16) characters";
        public const string EmailAddressExampleMsg = "Ex: abc@gmail.com";
        public const string DoBMsg = "Age should be greater than 10 years";
        public const string ValidDoBMsg = "Enter Valid Date of Birth";
        public const string IncomeMsg = "Income Cannot be Empty";
    }
}