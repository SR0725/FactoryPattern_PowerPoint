using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework2
{
    public class Utility
    {

        // get random single dot position
        public static void GetRandomDotPosition(out int positionX, out int positionY)
        {
            const int MIN_NUMBER = 0;
            const int MAX_NUMBER = 100;

            Random random = new Random(Guid.NewGuid().GetHashCode());
            positionX = random.Next(MIN_NUMBER, MAX_NUMBER);
            positionY = random.Next(MIN_NUMBER, MAX_NUMBER);
        }

        // swap position1 and position2
        public static void SwapPosition(ref int positionX1, ref int positionY1, ref int positionX2, ref int positionY2)
        {
            int temp = positionX1;
            positionX1 = positionX2;
            positionX2 = temp;
            temp = positionY2;
            positionY2 = positionY1;
            positionY1 = temp;
        }

        // get random position
        public static void GetRandomPosition(ref int positionX1, ref int positionY1, ref int positionX2, ref int positionY2)
        {
            GetRandomDotPosition(out positionX1, out positionY1);
            GetRandomDotPosition(out positionX2, out positionY2);
            if (positionX1 > positionX2)
            {
                SwapPosition(ref positionX1, ref positionY1, ref positionX2, ref positionY2);
            }
        }

    }
}
