using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fire_department_api.LibraryCore
{
    public interface ILoginCore
    {
        string CheckLogin(string LoginId, string LoginPw);

    }
}