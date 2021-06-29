using System.Drawing;

namespace Repin_kursovaya
{
    class Flag : Figure
    {
        public Flag(int x, int y)
        {
            VertexList.Add(new PointF(x - 45, y + 45));
            VertexList.Add(new PointF(x - 45, y - 45));
            VertexList.Add(new PointF(x + 45, y - 45));
            VertexList.Add(new PointF(x, y));
            VertexList.Add(new PointF(x + 45, y + 45));
            Center = new PointF(x, y);
            type = 4;
        }
    }
}
