using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ado_Net.Services.Interfaces
{
    internal interface IService
    {
        void InsertIntoTable();
        void ReadTable();
        void UpdateTable(int id);
        void DeleteTable(int id);
    }
}
