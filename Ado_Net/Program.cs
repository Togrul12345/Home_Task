



using Ado_Net.Models;
using Ado_Net.Services.Concretes;

namespace Ado_Net
{
    internal class Program
    {
        static void Main(string[] args)
        {

           Service service= new Service();
            service.ReadTable();


         }

    }
}
