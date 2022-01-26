using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeelineTest.Utils
{
    public static class RandomUtil
    {
        private static Random random = new Random();

        public static int GetRandomNumber(int maxValue)
        {
            return random.Next(1,maxValue);
        }
    }
}
