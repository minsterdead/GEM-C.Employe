using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEM_C_E.Service
{
    public interface IApplicationService
    {
        void ChangeView<T>(T view);
    }
}
