using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseBuilder.FixedCreator
{
    interface IFix
    {
        public void SaveToDatabaseSequentially();
    }
}
