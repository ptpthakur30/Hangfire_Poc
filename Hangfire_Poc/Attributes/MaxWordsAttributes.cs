using System.ComponentModel.DataAnnotations;

namespace Hangfire_Poc.Attributes
{
    public class MaxWordsAttributes:ValidationAttribute
    {
        private readonly int _maxWords;
        public MaxWordsAttributes(int maxWords) : base("{0} has too many words.") 
        {
            _maxWords = maxWords;
        }
        protected override ValidationResult IsValid(object value,ValidationContext validationContext)
        {
            if (value == null) return ValidationResult.Success;
            var textValue = value.ToString();
            if (textValue.Split(' ').Length <= _maxWords) return ValidationResult.Success;
            var errorMessage = FormatErrorMessage((validationContext.DisplayName));
            return new ValidationResult(errorMessage);
           
        }
    }
}