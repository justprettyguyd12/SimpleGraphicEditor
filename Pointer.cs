using System.Drawing;

namespace Repin_kursovaya
{
    class Pointer
    {
        public Point[] Points = new Point[4];
        public Point Center;
        public Pointer(Point P)
        {
            Center = P;
            Points[0] = new Point(P.X - 5, P.Y);
            Points[1] = new Point(P.X + 5, P.Y);
            Points[2] = new Point(P.X, P.Y - 5);
            Points[3] = new Point(P.X, P.Y + 5);
        }

    }
}
