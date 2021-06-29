using System.Drawing;

namespace Repin_kursovaya
{
    class Line : Figure
    {
        public Line(int x, int y)
        {
            VertexList.Add(new PointF(x, y));
            type = 0;
        }

        public void Add(int x, int y)
        {
            if (VertexList.Count < 2) VertexList.Add(new PointF(x, y));
        }
    }
}
