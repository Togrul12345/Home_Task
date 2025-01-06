using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.Bl.Exceptions
{
    public class ModelSateException:Exception
    {
        public ModelSateException(string str):base(str)
        {
            throw new Exception(str);
        }
        public ModelSateException()
        {
            throw new Exception("ModelState is not valid");
        }
    }
}
