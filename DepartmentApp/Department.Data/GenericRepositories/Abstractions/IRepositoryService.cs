using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Department.Data.Repositories.Abstractions
{
    public interface IRepositoryService<Tentity> where Tentity :class
    {
        void Update(Tentity tentity); 
    }
}
