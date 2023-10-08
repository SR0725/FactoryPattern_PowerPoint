using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework2
{
    public abstract class Shape
    {
        protected string _shapeName;

        // set position
        public abstract void SetPosition(int positionX1, int positionY1, int positionX2, int positionY2);

        // get info
        public abstract string GetInfo();

        // get shape name
        public abstract string GetShapeName();
    }
}
