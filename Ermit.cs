using System.Drawing;

namespace Repin_kursovaya
{
    class Ermit : Figure
    {
        public Ermit(int x, int y)
        {
            VertexList.Add(new PointF(x, y));
            type = 1;
        }

        public void Add(int x, int y)
        {
            VertexList.Add(new PointF(x, y));
        }
    }
}
