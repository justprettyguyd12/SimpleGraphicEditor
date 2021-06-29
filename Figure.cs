using System;
using System.Collections.Generic;
using System.Drawing;

namespace Repin_kursovaya
{
    public class Figure
    {
        //список вершин
        public List<PointF> VertexList;
        public PointF Center = new Point();
        public int type;
        public float max_x, max_y, min_x, min_y;
        public List<Point>[] Borders;

        //конструктор
        public Figure()
        {
            VertexList = new List<PointF>();
            Center = new PointF();
        }

        //поворот
        public virtual void Turn(PointF P1, PointF P2)
        {
            float x, y;
            double alpha; //угол поворота в радианах
            double a, b; //a, b - радиус к первой и второй точке;
            double a2, b2, c2; //квадраты сторон
            FindCenter();
            //поиск угла поворота
            a2 = Math.Pow(P1.X - Center.X, 2) + Math.Pow(P1.Y - Center.Y, 2);
            b2 = Math.Pow(P2.X - Center.X, 2) + Math.Pow(P2.Y - Center.Y, 2);
            c2 = Math.Pow(P2.X - P1.X, 2) + Math.Pow(P2.Y - P1.Y, 2);
            a = (Math.Sqrt(a2));
            b = (Math.Sqrt(b2));
            if (P1.X >= Center.X & P1.Y <= Center.Y) //1 четверть
            {
                if ((P2.X - P1.X + P2.Y - P1.Y) > 0) alpha = Math.Acos((a2 + b2 - c2) / (2 * a * b)); //по часовой
                else alpha = -Math.Acos((a2 + b2 - c2) / (2 * a * b)); //против часовой
            }
            else if (P1.X < Center.X & P1.Y < Center.Y) //2 четверть
            {
                if ((P2.X - P1.X) > (P2.Y - P1.Y)) alpha = Math.Acos((a2 + b2 - c2) / (2 * a * b)); //по часовой
                else alpha = -Math.Acos((a2 + b2 - c2) / (2 * a * b)); //против часовой
            }
            else if (P1.X <= Center.X & P1.Y >= Center.Y) //3 четверть
            {
                if ((P2.X - P1.X + P2.Y - P1.Y) < 0) alpha = Math.Acos((a2 + b2 - c2) / (2 * a * b)); //по часовой
                else alpha = -Math.Acos((a2 + b2 - c2) / (2 * a * b)); //против часовой
            }
            else // 4 четверть
            {
                if ((P2.X - P1.X) < (P2.Y - P1.Y)) alpha = Math.Acos((a2 + b2 - c2) / (2 * a * b)); //по часовой
                else alpha = -Math.Acos((a2 + b2 - c2) / (2 * a * b)); //против часовой
            }
            if (Double.IsNaN(alpha)) alpha = 0;

            for (int j = 0; j < VertexList.Count; j++)
            {
                x = Convert.ToSingle((VertexList[j].X - Center.X) * Math.Cos(alpha) -
                    (VertexList[j].Y - Center.Y) * Math.Sin(alpha) + Center.X);
                y = Convert.ToSingle((VertexList[j].X - Center.X) * Math.Sin(alpha) +
                    (VertexList[j].Y - Center.Y) * Math.Cos(alpha) + Center.Y);
                VertexList[j] = new PointF(x, y);
            }
        }
        public virtual void Turn(PointF P1, PointF P2, PointF Center)
        {
            float x, y;
            double alpha; //угол поворота в радианах
            double a, b; //a, b - радиус к первой и второй точке;
            double a2, b2, c2; //квадраты сторон
                               //поиск угла поворота
            a2 = Math.Pow(P1.X - Center.X, 2) + Math.Pow(P1.Y - Center.Y, 2);
            b2 = Math.Pow(P2.X - Center.X, 2) + Math.Pow(P2.Y - Center.Y, 2);
            c2 = Math.Pow(P2.X - P1.X, 2) + Math.Pow(P2.Y - P1.Y, 2);
            a = (Math.Sqrt(a2));
            b = (Math.Sqrt(b2));
            if (P1.X >= Center.X & P1.Y <= Center.Y) //1 четверть
            {
                if ((P2.X - P1.X + P2.Y - P1.Y) > 0) alpha = Math.Acos((a2 + b2 - c2) / (2 * a * b)); //по часовой
                else alpha = -Math.Acos((a2 + b2 - c2) / (2 * a * b)); //против часовой
            }
            else if (P1.X < Center.X & P1.Y < Center.Y) //2 четверть
            {
                if ((P2.X - P1.X) > (P2.Y - P1.Y)) alpha = Math.Acos((a2 + b2 - c2) / (2 * a * b)); //по часовой
                else alpha = -Math.Acos((a2 + b2 - c2) / (2 * a * b)); //против часовой
            }
            else if (P1.X <= Center.X & P1.Y >= Center.Y) //3 четверть
            {
                if ((P2.X - P1.X + P2.Y - P1.Y) < 0) alpha = Math.Acos((a2 + b2 - c2) / (2 * a * b)); //по часовой
                else alpha = -Math.Acos((a2 + b2 - c2) / (2 * a * b)); //против часовой
            }
            else // 4 четверть
            {
                if ((P2.X - P1.X) < (P2.Y - P1.Y)) alpha = Math.Acos((a2 + b2 - c2) / (2 * a * b)); //по часовой
                else alpha = -Math.Acos((a2 + b2 - c2) / (2 * a * b)); //против часовой
            }
            if (Double.IsNaN(alpha)) alpha = 0;

            for (int j = 0; j < VertexList.Count; j++)
            {
                x = Convert.ToSingle((VertexList[j].X - Center.X) * Math.Cos(alpha) -
                    (VertexList[j].Y - Center.Y) * Math.Sin(alpha) + Center.X);
                y = Convert.ToSingle((VertexList[j].X - Center.X) * Math.Sin(alpha) +
                    (VertexList[j].Y - Center.Y) * Math.Cos(alpha) + Center.Y);
                VertexList[j] = new PointF(x, y);
            }
        }

        //перемещение
        public virtual void Move(int x, int y)
        {
            for (int i = 0; i < VertexList.Count; i++)
            {
                VertexList[i] = new PointF(VertexList[i].X + x, VertexList[i].Y + y);
            }
            Center = new PointF(Center.X + x, Center.Y + y);
        }

        //поворот на 60 градусов
        public virtual void Turn()
        {
            float x, y;
            double alpha = 1.0472;
            FindCenter();
            for (int j = 0; j < VertexList.Count; j++)
            {
                x = Convert.ToSingle((VertexList[j].X - Center.X) * Math.Cos(alpha) -
                    (VertexList[j].Y - Center.Y) * Math.Sin(alpha) + Center.X);
                y = Convert.ToSingle((VertexList[j].X - Center.X) * Math.Sin(alpha) +
                    (VertexList[j].Y - Center.Y) * Math.Cos(alpha) + Center.Y);
                VertexList[j] = new PointF(x, y);
            }
        }
        public virtual void Turn(PointF Center)
        {
            float x, y;
            double alpha = 1.0472;
            for (int j = 0; j < VertexList.Count; j++)
            {
                x = Convert.ToSingle((VertexList[j].X - Center.X) * Math.Cos(alpha) -
                    (VertexList[j].Y - Center.Y) * Math.Sin(alpha) + Center.X);
                y = Convert.ToSingle((VertexList[j].X - Center.X) * Math.Sin(alpha) +
                    (VertexList[j].Y - Center.Y) * Math.Cos(alpha) + Center.Y);
                VertexList[j] = new PointF(x, y);
            }
        }

        //масштабирование
        public virtual void Scaling(PointF P1, PointF P2, PointF Center)
        {
            float k;
            PointF P;
            FindCenter();
            if (P2.X != Center.X) //проверка перехода через центр
            {
                //поиск коэффицента растяжения
                if (P1.X != Center.X)
                    k = (P2.X - Center.X) / (P1.X - Center.X);
                else
                    k = P2.X - Center.X;
                //перезапись точек
                for (int i = 0; i < VertexList.Count; i++)
                {
                    if (VertexList[i].X < Center.X) //точка слева от центра
                    {
                        float new_x = (VertexList[i].X - Center.X) * k + Center.X;
                        if (new_x == Center.X)
                            return; //защита от "схлопывания"
                        P = new PointF(new_x, VertexList[i].Y);
                        VertexList[i] = P;
                    }
                    else if (VertexList[i].X > Center.X) //точка справа от центра
                    {
                        float new_x = Center.X - ((Center.X - VertexList[i].X) * k);
                        if (new_x == Center.X)
                            return; //защита от "схлопывания"
                        P = new PointF(new_x, VertexList[i].Y);
                        VertexList[i] = P;
                    }
                }
            }
        }

        //поиск центра
        public virtual void FindCenter()
        {
            float sum_x = 0, sum_y = 0;
            foreach (PointF P in VertexList) sum_x += P.X;
            foreach (PointF P in VertexList) sum_y += P.Y;
            Center.X = sum_x / VertexList.Count;
            Center.Y = sum_y / VertexList.Count;
        }

        //поиск зоны захвата
        public virtual void Zone()
        {
            max_x = VertexList[0].X;
            max_y = VertexList[0].X;
            min_x = VertexList[0].X;
            min_y = VertexList[0].X;
            foreach (PointF P in VertexList)
            {
                if (P.X > max_x) max_x = P.X;
                else if (P.X < min_x) min_x = P.X;
                if (P.Y > max_y) max_y = P.Y;
                else if (P.Y < min_y) min_y = P.Y;
            }
        }

        //нахождение границ примитива
        public virtual List<Point>[] GetBorders()
        {
            List<Point> points = new List<Point>();
            foreach (PointF P in VertexList)
            {
                points.Add(Point.Round(P));
            }
            List<Point> Xl = new List<Point>();
            List<Point> Xr = new List<Point>();
            int ymax = points[0].Y;
            int ymin = points[0].Y;
            for (int i = 0; i < points.Count; i++)
            {
                if (points[i].Y > ymax)
                {
                    ymax = points[i].Y;
                }
                if (points[i].Y < ymin)
                {
                    ymin = points[i].Y;
                }
            }
            for (int Y = ymin; Y < ymax; Y++)
            {
                List<int> Xb = new List<int>();
                int n = points.Count;
                int k;
                for (int i = 0; i < n; i++)
                {
                    if (i < n - 1)
                    {
                        k = i + 1;
                    }
                    else
                    {
                        k = 0;
                    }
                    if ((points[i].Y < Y && points[k].Y >= Y) || (points[i].Y >= Y && points[k].Y < Y))
                    {
                        int x1, y1, x2, y2;
                        x1 = points[i].X;
                        y1 = points[i].Y;
                        x2 = points[k].X;
                        y2 = points[k].Y;
                        int x = ((Y - y1) * (x2 - x1) / (y2 - y1)) + x1;
                        Xb.Add(x);
                    }
                }
                Xb.Sort();
                for (int i = 0; i < Xb.Count - 1; i += 2)
                {
                    Xl.Add(new Point(Xb[i], Y));
                    Xr.Add(new Point(Xb[i + 1], Y));
                }
            }
            return new[] { Xl, Xr };
        }
    }
}
