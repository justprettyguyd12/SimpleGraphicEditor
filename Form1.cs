using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Repin_kursovaya
{
    //Вариант 40
    public partial class Form1 : Form
    {
        public Graphics g;
        Bitmap myBitmap;
        List<Figure> PrimitivesList = new List<Figure>();
        Pen DrawPen = new Pen(Color.Black);
        Pen Pointer = new Pen(Color.Red);
        Point MousePos1; //зафиксированное положение курсора
        Pointer pointer; //указатель зафиксированный позиции курсора

        //переменные списков
        int mode; //0 - ввод, 1 - операция, 2 - ТМО, 3 - удаление примитива
        int primitive; //0 - отрезок, 1 - Эрмит, 2 - крест, 3 - флаг
        int operation; //0 - перемещение, 1 - поворот, 2 - поворот на 60, 3 - масштабирование
        int TMO; //0 - объединение, 1 - разность
        int? selectedPrimitive = null; // номер выбранного примитива, или null если примитив не выбран
        int? pr_TMO_1 = null; //номер первого примитива для ТМО, или null если примитив не выбран
        int? pr_TMO_2 = null;//номер второго примитива для ТМО, или null если примитив не выбран

        int pointCounter = 0; //количество введённых точек при вводе примитива

        public Form1()
        {
            InitializeComponent();
            myBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(myBitmap);
        }

        //обработчик кнопки выбора цвета
        private void Color_Button_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            DrawPen.Color = colorDialog1.Color;
        }

        //удаление фигуры
        private void Delete_Button_Click(object sender, EventArgs e)
        {
            mode = 3;
            Primitives_List.Enabled = false;
            Operation_List.Enabled = false;
            TMO_List.Enabled = false;
        }

        //обработчик кнопки очистки холста
        private void Clear_Button_Click(object sender, EventArgs e)
        {
            g.Clear(pictureBox1.BackColor);
            PrimitivesList.Clear();
            pictureBox1.Image = myBitmap;
            Primitives_List.Enabled = true;
            Operation_List.Enabled = false;
            TMO_List.Enabled = false;
            pointCounter = 0;
        }

        //выбор режима
        private void Mode_List_SelectedIndexChanged(object sender, EventArgs e)
        {
            mode = Mode_List.SelectedIndex;
            switch (mode)
            {
                case 0: //ввод
                    Primitives_List.Enabled = true;
                    Operation_List.Enabled = false;
                    TMO_List.Enabled = false;
                    return;
                case 1: //операция
                    Primitives_List.Enabled = false;
                    Operation_List.Enabled = true;
                    TMO_List.Enabled = false;
                    return;
                case 2: //ТМО
                    Primitives_List.Enabled = false;
                    Operation_List.Enabled = false;
                    TMO_List.Enabled = true;
                    return;
            }
        }

        //выбор примитива
        private void Primitives_List_SelectedIndexChanged(object sender, EventArgs e)
        {
            primitive = Primitives_List.SelectedIndex;
        }

        //выбор операции
        private void Operation_List_SelectedIndexChanged(object sender, EventArgs e)
        {
            operation = Operation_List.SelectedIndex;
        }

        //выбор ТМО
        private void TMO_List_SelectedIndexChanged(object sender, EventArgs e)
        {
            TMO = TMO_List.SelectedIndex;
        }

        //метод добавления точки в примитив
        private void AddPoint(int x, int y)
        {
            g.DrawRectangle(DrawPen, x, y, 1, 1);
            if (pointCounter == 0)
            {
                switch (primitive)
                {
                    case 0: //отрезок
                        PrimitivesList.Add(new Line(x, y));
                        Primitives_List.Enabled = false;
                        pointCounter++;
                        return;
                    case 1: //Эрмит
                        PrimitivesList.Add(new Ermit(x, y));
                        Primitives_List.Enabled = false;
                        pointCounter++;
                        return;
                    case 2: //крест
                        PrimitivesList.Add(new Cross(x, y));
                        DrawPrimitive(PrimitivesList[PrimitivesList.Count - 1].VertexList,
                            PrimitivesList[PrimitivesList.Count - 1].type);
                        return;
                    case 3: //флаг
                        PrimitivesList.Add(new Flag(x, y));
                        DrawPrimitive(PrimitivesList[PrimitivesList.Count - 1].VertexList,
                            PrimitivesList[PrimitivesList.Count - 1].type);
                        return;
                }

            }
            else if (pointCounter == 1)
            {
                switch (primitive)
                {
                    case 0:
                        Line newLine = (Line)PrimitivesList.Last();
                        newLine.Add(x, y);
                        PrimitivesList[PrimitivesList.Count - 1] = newLine;
                        DrawPrimitive(PrimitivesList[PrimitivesList.Count - 1].VertexList,
                            PrimitivesList[PrimitivesList.Count - 1].type);
                        Primitives_List.Enabled = true;
                        pointCounter = 0;
                        return;
                    case 1:
                        Ermit newErmit = (Ermit)PrimitivesList.Last();
                        newErmit.Add(x, y);
                        PrimitivesList[PrimitivesList.Count - 1] = newErmit;
                        pointCounter++;
                        return;
                }
            }
            else if (pointCounter == 3) //прорисовка сплайна
            {
                Ermit newErmit = (Ermit)PrimitivesList.Last();
                newErmit.Add(x, y);
                PrimitivesList[PrimitivesList.Count - 1] = newErmit;
                RedrawAllPrimitives();
                Primitives_List.Enabled = true;
                pointCounter = 0;
            }
            else if (pointCounter > 1 && pointCounter < 3)
            {
                if (primitive == 1)
                {
                    Ermit newErmit = (Ermit)PrimitivesList.Last();
                    newErmit.Add(x, y);
                    PrimitivesList[PrimitivesList.Count - 1] = newErmit;
                    pointCounter++;
                }
            }
        }

        //метод прорисовки/закрашивания фигуры
        public void PaintOver(List<PointF> VertexList)
        {
            int Ylow = Convert.ToInt32(VertexList[0].Y), Yhigh = Convert.ToInt32(VertexList[0].Y);
            List<int> Xb = new List<int>();
            int k, x;
            float xF;
            for (int i = 0; i < VertexList.Count; i++)
            {
                if (VertexList[i].Y > Ylow)
                {
                    Ylow = Convert.ToInt32(VertexList[i].Y);
                }
                if (VertexList[i].Y < Yhigh)
                {
                    Yhigh = Convert.ToInt32(VertexList[i].Y);
                }
            }

            for (int Y = Yhigh; Y <= Ylow; Y++)
            {
                Xb.Clear();
                for (int i = 0; i < VertexList.Count; i++)
                {
                    if (i < VertexList.Count - 1)
                    {
                        k = i + 1;
                    }
                    else k = 0;
                    if (((VertexList[i].Y > Y) && (VertexList[k].Y <= Y)) || ((VertexList[k].Y > Y) && (VertexList[i].Y <= Y)))
                    {
                        xF = ((float)Y - (float)VertexList[i].Y) / ((float)VertexList[k].Y - (float)VertexList[i].Y) * ((float)VertexList[k].X - (float)VertexList[i].X) + (float)VertexList[i].X; //нахождение точки пересечения с помощью уравнения
                        if (xF % 1 >= 0.5f) x = (int)xF + 1;
                        else x = (int)xF;
                        Xb.Add(x);
                    }
                }

                Xb.Sort();

                for (int i = 0; i < Xb.Count; i += 2)
                {
                    g.DrawLine(DrawPen, Xb[i], Y, Xb[i + 1], Y);
                }
            }
        }

        //методы рисования примитива
        public void DrawPrimitive(List<PointF> VertexList, int type) //для примитива
        {
            switch (type)
            {
                case 0: //отрезок
                    g.DrawLine(DrawPen, VertexList[0], VertexList[1]);
                    return;
                case 1: //кривая Эрмита
                    PointF[] P = VertexList.ToArray();
                    g.DrawBezier(DrawPen, P[0], P[1], P[2], P[3]);
                    return;
                default: //крест или флаг
                    PaintOver(VertexList);
                    return;
            }
        }
        public void DrawPrimitive(AfterTMOFigure P) //для фигуры после ТМО
        {
            List<Point>[] firstFigure;
            List<Point>[] secondFigure;
            if (P.Primitives[0].type == 5)
            {
                ReTMO((AfterTMOFigure)P.Primitives[0]);
                //DrawPrimitive((AfterTMOFigure)P.Primitives[0]);
                firstFigure = P.Primitives[0].Borders;
            }
            else
                firstFigure = P.Primitives[0].GetBorders();
            if (P.Primitives[1].type == 5)
            {
                ReTMO((AfterTMOFigure)P.Primitives[1]);
                //DrawPrimitive((AfterTMOFigure)P.Primitives[1]);
                secondFigure = P.Primitives[1].Borders;
            }
            else
                secondFigure = P.Primitives[1].GetBorders();
            P.Borders = GoTMO(P.TMO, firstFigure, secondFigure);
            for (int i = 0; i < P.Borders[0].Count; i++)
            {
                g.DrawLine(DrawPen, P.Borders[0][i], P.Borders[1][i]);
            }
        }

        //метод перерисовки всх примитивов
        public void RedrawAllPrimitives()
        {
            g.Clear(pictureBox1.BackColor);
            foreach (Figure P in PrimitivesList)
            {
                if (P.type == 5)
                {
                    DrawPrimitive((AfterTMOFigure)P);
                }
                else
                    DrawPrimitive(P.VertexList, P.type);
            }
        }

        //обработчик щелчка мыши
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            switch (mode)
            {
                case 0:
                    AddPoint(e.X, e.Y);
                    pictureBox1.Image = myBitmap;
                    return;
            }

        }

        //обработчик двойного щелчка мыши
        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left & mode == 1 & operation == 2 && selectedPrimitive != null) //поворот 60
            {
                Figure SelectedPrimitive = PrimitivesList[(int)selectedPrimitive];
                if (SelectedPrimitive.type != 5)
                    SelectedPrimitive.Turn();
                else
                    SelectedPrimitive.Turn(SelectedPrimitive.Center);
                RedrawAllPrimitives();
                pictureBox1.Image = myBitmap;
                MousePos1 = new Point(e.X, e.Y);
            }
            else if (e.Button == MouseButtons.Left & mode == 1 && operation == 3) //масштабирование: задание центра
            {
                for (int i = PrimitivesList.Count - 1; i >= 0; i--)
                {
                    PrimitivesList[i].Zone();
                    if (MousePos1.X < PrimitivesList[i].max_x &
                        MousePos1.X > PrimitivesList[i].min_x &
                        MousePos1.Y < PrimitivesList[i].max_y &
                        MousePos1.Y > PrimitivesList[i].min_y)
                    {
                        pointer = new Pointer(e.Location);
                        RedrawAllPrimitives();
                        g.DrawLine(Pointer, pointer.Points[0], pointer.Points[1]);
                        g.DrawLine(Pointer, pointer.Points[2], pointer.Points[3]);
                        pictureBox1.Image = myBitmap;
                        selectedPrimitive = i;
                        return;
                    }
                }
            }
            else if (e.Button == MouseButtons.Left && mode == 2) //ТМО
            {
                for (int i = PrimitivesList.Count - 1; i >= 0; i--)
                {
                    PrimitivesList[i].Zone();
                    if (e.X < PrimitivesList[i].max_x &
                        e.X > PrimitivesList[i].min_x &
                        e.Y < PrimitivesList[i].max_y &
                        e.Y > PrimitivesList[i].min_y)
                    {
                        if (pr_TMO_1 == null) //выбор первого примитива для ТМО
                        {
                            pr_TMO_1 = i;
                            pointer = new Pointer(e.Location);
                            RedrawAllPrimitives();
                            g.DrawLine(Pointer, pointer.Points[0], pointer.Points[1]);
                            g.DrawLine(Pointer, pointer.Points[2], pointer.Points[3]);
                            pictureBox1.Image = myBitmap;
                            break;
                        }
                        else if (pr_TMO_1 != null && pr_TMO_2 == null && pr_TMO_1 != i) //выбор второго примитива для ТМО и его выполнение
                        {
                            pr_TMO_2 = i;
                            PrimitivesList.Add(new AfterTMOFigure(PrimitivesList[(int)pr_TMO_1],
                                PrimitivesList[(int)pr_TMO_2], TMO)); //обе фигуры - примитивы
                            List<Figure> L = new List<Figure>();
                            for (int k = 0; k < PrimitivesList.Count; k++)
                            {
                                if (k != pr_TMO_1 && k != pr_TMO_2)
                                    L.Add(PrimitivesList[k]);
                            }
                            PrimitivesList = L;
                            pr_TMO_1 = null;
                            pr_TMO_2 = null;
                            RedrawAllPrimitives();
                            pictureBox1.Image = myBitmap;
                            break;
                        }
                    }
                }
            }
            else if (e.Button == MouseButtons.Left && mode == 3) //удаление фигуры
            {
                MousePos1 = new Point(e.X, e.Y);
                for (int i = PrimitivesList.Count - 1; i >= 0; i--)
                {
                    PrimitivesList[i].Zone();
                    if (MousePos1.X < PrimitivesList[i].max_x &
                        MousePos1.X > PrimitivesList[i].min_x &
                        MousePos1.Y < PrimitivesList[i].max_y &
                        MousePos1.Y > PrimitivesList[i].min_y)
                    {
                        PrimitivesList.RemoveAt(i);
                        RedrawAllPrimitives();
                        pictureBox1.Image = myBitmap;
                        return;
                    }
                }
            }
        }

        //обработчик движения мыши
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left & mode == 1 & selectedPrimitive != null)
            {
                Figure SelectedPrimitive = PrimitivesList[(int)selectedPrimitive];
                switch (operation)
                {
                    case 0: //перемещение
                        SelectedPrimitive.Move(e.X - MousePos1.X, e.Y - MousePos1.Y);
                        if (SelectedPrimitive.type == 5)
                        {
                            foreach (Figure F in ((AfterTMOFigure)SelectedPrimitive).Primitives)
                            {
                                if (F.type == 5)
                                {
                                    ReTMO((AfterTMOFigure)F);
                                }
                            }
                        }
                        RedrawAllPrimitives();
                        pictureBox1.Image = myBitmap;
                        MousePos1 = e.Location;
                        return;
                    case 1: //поворот
                        if (SelectedPrimitive.type != 5)
                            SelectedPrimitive.Turn(MousePos1, e.Location);
                        else
                            SelectedPrimitive.Turn(MousePos1, e.Location, SelectedPrimitive.Center);
                        if (SelectedPrimitive.type == 5)
                        {
                            foreach (Figure F in ((AfterTMOFigure)SelectedPrimitive).Primitives)
                            {
                                if (F.type == 5)
                                {
                                    ReTMO((AfterTMOFigure)F);
                                }
                            }
                        }
                        RedrawAllPrimitives();
                        pictureBox1.Image = myBitmap;
                        MousePos1 = e.Location;
                        return;
                    case 3: //масштабирование
                        SelectedPrimitive.Scaling(MousePos1, e.Location, pointer.Center);
                        if (SelectedPrimitive.type == 5)
                        {
                            foreach (Figure F in ((AfterTMOFigure)SelectedPrimitive).Primitives)
                            {
                                if (F.type == 5)
                                {
                                    ReTMO((AfterTMOFigure)F);
                                }
                            }
                        }
                        RedrawAllPrimitives();
                        pictureBox1.Image = myBitmap;
                        MousePos1 = e.Location;
                        return;
                }
            }

        }

        //обработчик нажатия мыши
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left & mode == 1)
            {
                MousePos1 = new Point(e.X, e.Y);
                for (int i = PrimitivesList.Count - 1; i >= 0; i--)
                {
                    PrimitivesList[i].Zone();
                    if (MousePos1.X < PrimitivesList[i].max_x &
                        MousePos1.X > PrimitivesList[i].min_x &
                        MousePos1.Y < PrimitivesList[i].max_y &
                        MousePos1.Y > PrimitivesList[i].min_y)
                    {
                        selectedPrimitive = i;
                        return;
                    }
                    else selectedPrimitive = null;
                }
            }
        }

        //методы для выполнения ТМО
        private List<Point>[] GoTMO(int TMO, List<Point>[] firstFigure, List<Point>[] secondFigure) //из двух примитивов
        {
            if (TMO == 0)
            {
                List<Point>[] res = new List<Point>[2];
                res[0] = new List<Point>();
                res[1] = new List<Point>();
                int yMin = 0;
                int yMax = pictureBox1.Height;
                for (int i = yMin; i < yMax; i++)
                {
                    // Добавление левых границ первой фигуры в массив.
                    foreach (Point points in firstFigure[0])
                    {
                        if (points.Y == i)
                        {
                            res[0].Add(points);
                        }
                    }
                    // Добавление правых границ первой фигуры в массив.
                    foreach (Point points in firstFigure[1])
                    {
                        if (points.Y == i)
                        {
                            res[1].Add(points);
                        }
                    }
                    // Добавление левых границ второй фигуры в массив.
                    foreach (Point points in secondFigure[0])
                    {
                        if (points.Y == i)
                        {
                            res[0].Add(points);
                        }
                    }
                    // Добавление правых границ первой фигуры в массив.
                    foreach (Point points in secondFigure[1])
                    {
                        if (points.Y == i)
                        {
                            res[1].Add(points);
                        }
                    }
                }
                return res;
            }
            int[] SetQ = new int[2];
            switch (TMO)
            {
                case 0:
                    SetQ[0] = 1;
                    SetQ[1] = 3;
                    break;
                case 1:
                    SetQ[0] = 2;
                    SetQ[1] = 2;
                    break;
                default:
                    break;
            }
            int ymin = 0;
            int ymax = pictureBox1.Height;
            List<Point> Xrl = new List<Point>();
            List<Point> Xrr = new List<Point>();
            for (int Y = ymin; Y < ymax; Y++)
            {
                // Массив левых границ сегментов сечения Sa.
                List<int> Xal = new List<int>();
                // Массив правых границ сегментов сечения Sa.
                List<int> Xar = new List<int>();
                for (int i = 0; i < firstFigure[0].Count; i++)
                {
                    if (firstFigure[0][i].Y == Y)
                    {
                        Xal.Add(firstFigure[0][i].X);
                        Xar.Add(firstFigure[1][i].X);
                    }
                }
                // Массив левых границ сегментов сечения Sb.
                List<int> Xbl = new List<int>();
                // Массив правых границ сегментов сечения Sb.
                List<int> Xbr = new List<int>();
                for (int i = 0; i < secondFigure[0].Count; i++)
                {
                    if (secondFigure[0][i].Y == Y)
                    {
                        Xbl.Add(secondFigure[0][i].X);
                        Xbr.Add(secondFigure[1][i].X);
                    }
                }
                List<int[]> M = new List<int[]>();
                int n = Xal.Count;
                for (int i = 0; i < n; i++)
                {
                    M.Add(new[] { Xal[i], 2 });
                }
                n = Xar.Count();
                for (int i = 0; i < n; i++)
                {
                    M.Add(new[] { Xar[i], -2 });
                }
                n = Xbl.Count();
                for (int i = 0; i < n; i++)
                {
                    M.Add(new[] { Xbl[i], 1 });
                }
                n = Xbr.Count();
                for (int i = 0; i < n; i++)
                {
                    M.Add(new[] { Xbr[i], -1 });
                }
                for (int i = 0; i < M.Count; i++)
                {
                    for (int j = 0; j < M.Count - 1; j++)
                    {
                        if (M[j][0] > M[j + 1][0])
                        {
                            int[] temp = M[j];
                            M[j] = M[j + 1];
                            M[j + 1] = temp;
                        }
                    }
                }
                int Q = 0;
                int Xemin = 0;
                int Xemax = pictureBox1.Width;
                if (M.Count != 0 && M[0][0] >= Xemin && M[0][1] < 0)
                {
                    Xrl.Add(new Point(Xemin, Y));
                    Q = -M[1][1];
                }
                for (int i = 0; i < M.Count; i++)
                {
                    int x = M[i][0];
                    int Qnew = Q + M[i][1];
                    if ((!SetQ.Contains(Q)) && SetQ.Contains(Qnew))
                    {
                        Xrl.Add(new Point(x, Y));
                    }
                    if (SetQ.Contains(Q) && (!SetQ.Contains(Qnew)))
                    {
                        Xrr.Add(new Point(x, Y));
                    }
                    Q = Qnew;
                }
                if (SetQ.Contains(Q))
                {
                    Xrr.Add(new Point(Xemax, Y));
                }

            }
            return new[] { Xrl, Xrr };
        }
        private void ReTMO(AfterTMOFigure F)
        {
            List<Point>[] firstFigure;
            List<Point>[] secondFigure;
            if (F.Primitives[0].type == 5)
            {
                ReTMO((AfterTMOFigure)F.Primitives[0]);
                firstFigure = ((AfterTMOFigure)F.Primitives[0]).Borders;
            }
            else
                firstFigure = F.Primitives[0].GetBorders();
            if (F.Primitives[1].type == 5)
            {
                ReTMO((AfterTMOFigure)F.Primitives[1]);
                secondFigure = ((AfterTMOFigure)F.Primitives[1]).Borders;
            }
            else
                secondFigure = F.Primitives[1].GetBorders();
            F.Borders = GoTMO(F.TMO, firstFigure, secondFigure);
        }
    }
}
