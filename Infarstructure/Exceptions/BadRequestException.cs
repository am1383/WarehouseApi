namespace Warehouse.Application.Excecptions
{
    public class BadRequestExceptions : ApplicationException
    {
        public BadRequestExceptions(string message)
            : base(message)
        {
            
        }
    }
}