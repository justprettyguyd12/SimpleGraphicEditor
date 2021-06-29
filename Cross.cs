using System.Drawing;

namespace Repin_kursovaya
{
    class Cross : Figure
    {
        public Cross(int x, int y)
        {
            VertexList.Add(new PointF(x - 45, y + 15));
            VertexList.Add(new PointF(x - 45, y - 15));
            VertexList.Add(new PointF(x - 15, y - 15));
            VertexList.Add(new PointF(x - 15, y - 45));
            VertexList.Add(new PointF(x + 15, y - 45));
            VertexList.Add(new PointF(x + 15, y - 15));
            VertexList.Add(new PointF(x + 45, y - 15));
            VertexList.Add(new PointF(x + 45, y + 15));
            VertexList.Add(new PointF(x + 15, y + 15));
            VertexList.Add(new PointF(x + 15, y + 45));
            VertexList.Add(new PointF(x - 15, y + 45));
            VertexList.Add(new PointF(x - 15, y + 15));
            Center = new Point(x, y);
            type = 2;
        }
    }
}
