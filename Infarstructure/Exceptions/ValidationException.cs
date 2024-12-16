namespace Warehouse.Application.Excecptions
{
    public class ValidationException : ApplicationException
    {
        public ValidationException(string message)
            :base(message)
        {
            
        }
    }
}