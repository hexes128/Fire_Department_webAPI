﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fire_department_api.LibraryCore.GetitembyplaceFolder
{
    interface IGetitembyplace
    {
        DataTable getitem(string place);
    }
}