using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT27012024
{
    public class GameHelper
    {
        public static int GetRandomValue (int min, int max)
        {
            Random r = new Random();
            return r.Next(min, max);
        }
    }
}
