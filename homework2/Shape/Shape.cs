namespace homework2
{
    public abstract class Shape
    {
        protected string _shapeName;

        // set position
        public abstract void SetPosition(int positionX, int positionY, int width, int height);

        // get info
        public abstract string GetInfo();

        // get position
        public abstract void GetPosition(ref int positionX1, ref int positionY1, ref int positionX2, ref int positionY2);

        // get shape name
        public abstract string GetShapeName();

        // render
        public abstract void Draw(IGraphics graphics);

        // render selected
        public abstract void DrawSelectedBorder(IGraphics graphics);

        // IsPointInsideShape
        public abstract bool IsPointInsideShape(double positionX, double positionY);
    }
}
