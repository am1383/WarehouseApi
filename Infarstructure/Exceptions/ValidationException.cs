using FluentValidation.Results;

namespace Warehouse.Application.Excecptions
{
    public class ValidationException : ApplicationException
    {
        public List<string> Errors { get; set; } = new List<string>();

        public ValidationException(string message)
            :base(message)
        {
            
        }
        public ValidationException(ValidationResult validationResult)
        {
            foreach (var err in validationResult.Errors)
            {
                Errors.Add(err.ErrorMessage);
            }
        }
    }
}