using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace BT27012024
{
    public class Inventory<T> : IITem<T> where T:Item
    {
        public T CreateITem(string itemname, ItemType Type)
        {
            switch(Type)
            {
                case ItemType.Sword:
                {
                    return (T)(object) new Sword(itemname,Type);
                }
                case ItemType.Bow:
                {
                    return (T)(object)new Bow(itemname, Type);
                }
                case ItemType.Amor:
                {
                    return (T)(object)new Amor(itemname, Type);
                }
                case ItemType.Staff:
                {
                    return (T)(object)new Staff(itemname, Type);
                }
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
