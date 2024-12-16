namespace Warehouse.Application.Excecptions
{
    public class NotFoundExceptions : ApplicationException
    {
        public NotFoundExceptions(object key, string name = "")
            :base($"{name} ({key}) was not found")
        {
            //
        }
    }
}