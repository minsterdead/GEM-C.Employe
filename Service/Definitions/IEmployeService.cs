using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GEM_C_E.Models.Entities;

namespace GEM_C_E.Service.Definitions
{
    public interface IEmployeService
    {
        IList<Employe> RetriveAll();

    }
}
