namespace Warehouse.Application.Excecptions
{
    public class NotFoundExceptions : ApplicationException
    {
        public NotFoundExceptions(string name, object key)
            :base($"{name} ({key}) was not found")
        {
            
        }
    }
}