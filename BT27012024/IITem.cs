using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT27012024
{
    public interface IITem<T> where T:Item
    {
        T CreateITem(string itemname, ItemType Type);
    }
}
