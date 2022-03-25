using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Infrastructures
{
    public enum Menu : byte
    {
        BrandAdd = 1,
        BrandEdit,
        BrandRemove,
        BrandSingle,
        BrandAll,


        ModelAdd,
        ModelEdit,
        ModelRemove,
        ModelSingle,
        ModelAll,

        CarAdd,
        CarEdit,
        CarRemove,
        CarSingle,
        CarAll,

        All,
        Exit,
    }
}
