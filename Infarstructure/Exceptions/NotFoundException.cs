namespace Warehouse.Application.Excecptions
{
    public class NotFoundExceptions : ApplicationException
    {
        public NotFoundExceptions(string message)
            :base(message)
        {
            
        }
    }
}