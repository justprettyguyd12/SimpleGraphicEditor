using System.Collections.Generic;
using System.Drawing;

namespace Repin_kursovaya
{
    public class AfterTMOFigure : Figure
    {
        public List<Figure> Primitives = new List<Figure>();
        public int TMO;
        public AfterTMOFigure(Figure P1, Figure P2, int TMO)
        {
            Primitives.Add(P1);
            Primitives.Add(P2);
            foreach (PointF P in P1.VertexList)
                VertexList.Add(P);
            foreach (PointF P in P2.VertexList)
                VertexList.Add(P);
            this.TMO = TMO;
            type = 5;
            FindCenter();
        }

        override public void Move(int x, int y)
        {
            foreach (Figure F in Primitives)
            {
                F.Move(x, y);
            }
            VertexList.Clear();
            foreach (Figure F in Primitives)
            {
                foreach (PointF P in F.VertexList)
                {
                    VertexList.Add(P);
                }
            }
            FindCenter();
        }

        //поворот
        public override void Turn(PointF P1, PointF P2, PointF Center)
        {
            foreach (Figure F in Primitives)
            {
                F.Turn(P1, P2, Center);
            }
            VertexList.Clear();
            foreach (Figure F in Primitives)
            {
                foreach (PointF P in F.VertexList)
                {
                    VertexList.Add(P);
                }
            }
            FindCenter();
        }

        //поворот на 60 градусов
        public override void Turn(PointF Center)
        {
            foreach (Figure F in Primitives)
            {
                F.Turn(Center);
            }
            VertexList.Clear();
            foreach (Figure F in Primitives)
            {
                foreach (PointF P in F.VertexList)
                {
                    VertexList.Add(P);
                }
            }
            FindCenter();
        }

        //масштабирование
        public override void Scaling(PointF P1, PointF P2, PointF Center)
        {
            foreach (Figure F in Primitives)
            {
                F.Scaling(P1, P2, Center);
            }
            VertexList.Clear();
            foreach (Figure F in Primitives)
            {
                foreach (PointF P in F.VertexList)
                {
                    VertexList.Add(P);
                }
            }
            FindCenter();
        }

        //поиск зоны захвата
        public override void Zone()
        {
            max_x = Primitives[0].VertexList[0].X;
            max_y = Primitives[0].VertexList[0].Y;
            min_x = Primitives[0].VertexList[0].X;
            min_y = Primitives[0].VertexList[0].Y;
            foreach (Figure F in Primitives)
            {
                foreach (PointF P in F.VertexList)
                {
                    if (P.X > max_x) max_x = P.X;
                    else if (P.X < min_x) min_x = P.X;
                    if (P.Y > max_y) max_y = P.Y;
                    else if (P.Y < min_y) min_y = P.Y;
                }
            }
        }

        //поиск центра
        public override void FindCenter()
        {
            float center_sum_x = 0;
            float center_sum_y = 0;
            foreach (Figure F in Primitives)
            {
                F.FindCenter();
                center_sum_x += F.Center.X;
                center_sum_y += F.Center.Y;
            }
            Center = new PointF(center_sum_x / Primitives.Count, center_sum_y / Primitives.Count);
        }

    }
}
