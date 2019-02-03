using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThuatToanToMau
{
    public partial class Form1 : Form
    {

        bool drawing = false;
        List<Point> polyPoint;
        Point sPoint;
        Rectangle rect;
        Bitmap bitmap;
        Pen outlinePen;

        Brush delBrush;
        Graphics g;
        Rectangle ellipse;

        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            buttonFill.Enabled = false;
            bitmap = new Bitmap(pictureBox.Width, pictureBox.Height, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
            Graphics.FromImage(bitmap).Clear(Color.White);
            pictureBox.Image = bitmap;
            pictureBox.Invalidate();

            polyPoint = new List<Point>();

            comboBox_thuatToanToMau.Items.Add("Scanline");
            comboBox_thuatToanToMau.Items.Add("Fill boundary");
            comboBox_thuatToanToMau.Items.Add("Fill boundary cải tiến");
            comboBox_thuatToanToMau.SelectedIndex = 0;

            radioButtonPolygon.Checked = true;


        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }


        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left

                && radioButtonPolygon.Checked == true)
            {
                if (drawing == false)
                {
                    polyPoint.Clear();
                    Graphics.FromImage(bitmap).Clear(Color.White);
                }
                drawing = true;
                sPoint = e.Location;
                polyPoint.Add(e.Location);

                g = Graphics.FromImage(bitmap);

                outlinePen = new Pen(new SolidBrush(pictureBox_colorOutline.BackColor), 2);

                // delete brush
                delBrush = new TextureBrush(bitmap);
            }
            else if (e.Button == MouseButtons.Left
                && (radioButtonEllipse.Checked == true
            || radioButtonCircle.Checked == true))
            {
                Graphics.FromImage(bitmap).Clear(Color.White);
                drawing = true;
                sPoint = e.Location;

                g = Graphics.FromImage(bitmap);



                outlinePen = new Pen(pictureBox_colorOutline.BackColor, 3);
                // delete brush
                delBrush = new TextureBrush(bitmap);

            }

        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox.Cursor = Cursors.Cross;
            if (drawing && radioButtonPolygon.Checked == true)
            {
                // delete old line
                rect.Inflate(1, 1);
                g.FillRectangle(delBrush, rect);



                g.DrawLine(outlinePen, sPoint, e.Location);
                pictureBox.Invalidate();
                rect = GetRectangleFromPoints(sPoint, e.Location);

            }
            else if (drawing && radioButtonEllipse.Checked == true)
            {
                rect.Inflate(2, 2);
                g.FillEllipse(delBrush, rect);

                rect = GetRectangleFromPoints(sPoint, e.Location);
                //draw the new rect
                g.DrawEllipse(outlinePen, rect);
                pictureBox.Invalidate();

            }
            else if (drawing && radioButtonCircle.Checked == true)
            {
                rect.Inflate(2, 2);
                g.FillEllipse(delBrush, rect);

                rect = getSquareFrom2Points(sPoint, e.Location);
                //draw the new rect
                g.DrawEllipse(outlinePen, rect);
                pictureBox.Invalidate();
            }
        }

        private Rectangle GetRectangleFromPoints(Point p1, Point p2)
        {
            Point oPoint;
            Rectangle rect;

            if ((p2.X > p1.X) && (p2.Y > p1.Y))
            {
                rect = new Rectangle(p1, new Size(p2.X - p1.X, p2.Y - p1.Y));
            }
            else if ((p2.X < p1.X) && (p2.Y < p1.Y))
            {
                rect = new Rectangle(p2, new Size(p1.X - p2.X, p1.Y - p2.Y));
            }
            else if ((p2.X > p1.X) && (p2.Y < p1.Y))
            {
                oPoint = new Point(p1.X, p2.Y);
                rect = new Rectangle(oPoint, new Size(p2.X - p1.X, p1.Y - oPoint.Y));
            }
            else
            {
                oPoint = new Point(p2.X, p1.Y);
                rect = new Rectangle(oPoint, new Size(p1.X - p2.X, p2.Y - p1.Y));
            }
            return rect;
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (drawing && radioButtonPolygon.Checked == true)
            {
                if (e.Button == MouseButtons.Right)
                {
                    drawing = false;

                    polyPoint.Add(e.Location);

                    g.DrawPolygon(outlinePen, polyPoint.ToArray());


                    pictureBox.Invalidate();

                    buttonFill.Enabled = true;
                    // free resources
                    outlinePen.Dispose();
                    delBrush.Dispose();
                    g.Dispose();

                }
            }
            else if (drawing && (radioButtonEllipse.Checked == true
                || radioButtonCircle.Checked == true))
            {

                drawing = false;

                g.Clear(Color.White);
                g.DrawEllipse(outlinePen, rect);
                ellipse = rect;

                pictureBox.Invalidate();
                buttonFill.Enabled = true;

                if (outlinePen != null)
                    outlinePen.Dispose();
                delBrush.Dispose();
                g.Dispose();
            }
        }



        public void ScanLineForEllipse(Rectangle ellipseParentBox, Color color, Color outline)
        {
            int xmin = ellipseParentBox.X;
            int ymin = ellipseParentBox.Y;
            int xmax = xmin + ellipseParentBox.Width;
            int ymax = ymin + ellipseParentBox.Height;
            int a = ellipseParentBox.Width / 2;
            int b = ellipseParentBox.Height / 2;
            int a2 = a * a;
            int b2 = b * b;
            Point mid = getMid(ellipseParentBox);
            //(x-x0)^2*b^2 + (y-y0)^2*a^2 = a^2*b^2
            for (int y = ymin; y <= ymax; y++)
            {
                //tìm tọa độ giao điểm
                int tempInt = (a2 * b2 - a2 * (y - mid.Y) * (y - mid.Y)) / b2;

                if (tempInt != 0)
                {
                    double temp = Math.Sqrt(tempInt);


                    int x1 = (int)(-temp + mid.X + 0.5);
                    int x2 = (int)(temp + mid.X + 0.5);
                    if (x1 >= xmin && x2 <= xmax)
                        for (int x = x1; x <= x2; x++)
                            bitmap.SetPixel(x, y, color);
                }
            }
        }

        public void ScanLine(List<Point> p, Color color, Color outline)
        {
            int xmin, xmax, ymin, ymax, c;

            xmin = p.Min(point => point.X);
            xmax = p.Max(point => point.X);
            ymin = p.Min(point => point.Y);
            ymax = p.Max(point => point.Y);

            double y;
            int[] array = new int[xmax - xmin + 1];
            y = ymin + 0.01;
            while (y <= ymax)
            { //với y tăng dần từ ymin > ymax,tìm các giao điểm của từng y với các cặp cạnh
                int x, x1, x2, y1, y2, tg;
                c = 0;    //chỉ số của mảng phần tử
                for (int i = 0; i < p.Count; i++)
                { //xét trên tất cả các đỉnh
                    //xét 2 đỉnh liền kề nhau
                    x1 = p[i].X;
                    y1 = p[i].Y;
                    if (i < p.Count - 1)
                    {
                        x2 = p[i + 1].X;
                        y2 = p[i + 1].Y;
                    }
                    else
                    {
                        x2 = p[0].X;
                        y2 = p[0].Y;
                    }

                    if (y2 < y1)
                    { //sắp xếp lại y của 2 điểm liên tiếp
                        tg = x1; x1 = x2; x2 = tg;
                        tg = y1; y1 = y2; y2 = tg;
                    }

                    //mảng giao điểm
                    if (y <= y2 && y >= y1)
                    {
                        if (y1 == y2)
                        {
                            x = x1; //nếu y của 2 đỉnh liên tiếp trùng nhau => bỏ qua
                        }
                        else
                        {
                            x = (int)(((y - y1) * (x2 - x1)) / (y2 - y1) + 0.5); //hệ số góc
                            x += x1;
                        }
                        if (x <= xmax && x >= xmin)
                            array[c++] = x;   //cho phần tử c = x sau đó c++
                    }
                }

                //với từng y tăng dần ta vẽ luôn đường thằng nối 2 giao điểm
                for (int i = 0; i < c; i += 2)
                {
                    Point start = new Point(array[i], (int)y);
                    Point end = new Point(array[i + 1], (int)y);
                    Graphics.FromImage(bitmap).DrawLine(new Pen(color), start, end);

                    pictureBox.Invalidate();
                }
                y++;
            }
        }

        public void boundaryFill4(int x, int y, Color fill_color, Color boundary_color)
        {
            if (x > 0 && x < pictureBox.Width && y > 0 && y < pictureBox.Height)
            {
                if (!sameColor(bitmap.GetPixel(x, y), fill_color) &&
                  !sameColor(bitmap.GetPixel(x, y), boundary_color))
                {
                    bitmap.SetPixel(x, y, fill_color);

                    boundaryFill4(x + 1, y, fill_color, boundary_color);
                    boundaryFill4(x - 1, y, fill_color, boundary_color);
                    boundaryFill4(x, y + 1, fill_color, boundary_color);
                    boundaryFill4(x, y - 1, fill_color, boundary_color);
                }
            }

        }

        void ImprovedBoundary(int x, int y, Color fill_color, Color boundary_color)
        {
            //  Khai bao queue chua pixel chua duoc to mau
            Queue<Point> Q = new Queue<Point>();
            Point m = new Point(0, 0), Tg = new Point(0, 0);
            if (!sameColor(bitmap.GetPixel(x, y), fill_color) &&
                !sameColor(bitmap.GetPixel(x, y), boundary_color))
            {
                m.X = x;
                m.Y = y;
                bitmap.SetPixel(m.X, m.Y, fill_color);
                Q.Enqueue(m);  //  Them 1 diem vao queue, queue size tang 1
                while (Q.Count != 0)   //Xet 4 diem xung quanh voi moi diem luu trong queue (neu queue con phan tu)
                {
                    Q.Dequeue();//  Xoa 1 diem phia dau queue, queue size giam 1

                    //Xet cac diem lan can cua 1 diem
                    if (!sameColor(bitmap.GetPixel(m.X + 1, m.Y), fill_color) &&
                        !sameColor(bitmap.GetPixel(m.X + 1, m.Y), boundary_color))
                    {
                        bitmap.SetPixel(m.X + 1, m.Y, fill_color);
                        Tg.X = m.X + 1;
                        Tg.Y = m.Y;
                        Q.Enqueue(Tg);// Them 1 diem vao cuoi queue
                    }
                    if (!sameColor(bitmap.GetPixel(m.X - 1, m.Y), fill_color) &&
                         !sameColor(bitmap.GetPixel(m.X - 1, m.Y), boundary_color))
                    {
                        bitmap.SetPixel(m.X - 1, m.Y, fill_color);
                        Tg.X = m.X - 1;
                        Tg.Y = m.Y;
                        Q.Enqueue(Tg);// Them 1 diem vao cuoi queue
                    }
                    if (!sameColor(bitmap.GetPixel(m.X, m.Y + 1), fill_color) &&
                         !sameColor(bitmap.GetPixel(m.X, m.Y + 1), boundary_color))
                    {
                        bitmap.SetPixel(m.X, m.Y + 1, fill_color);
                        Tg.X = m.X;
                        Tg.Y = m.Y + 1;
                        Q.Enqueue(Tg);// Them 1 diem vao cuoi queue
                    }
                    if (!sameColor(bitmap.GetPixel(m.X, m.Y - 1), fill_color) &&
                        !sameColor(bitmap.GetPixel(m.X, m.Y - 1), boundary_color))
                    {
                        bitmap.SetPixel(m.X, m.Y - 1, fill_color);
                        Tg.X = m.X;
                        Tg.Y = m.Y - 1;
                        Q.Enqueue(Tg);// Them 1 diem vao cuoi queue
                    }
                    if (Q.Count != 0)
                        m = Q.Peek();// Dua ve gia tri dau tien cho hang doi
                }
            }
        }

        private bool sameColor(Color color, Color color1)
        {
            if (color.R == color1.R && color.B == color1.B && color.G == color1.G)
                return true;
            return false;
        }

        private void buttonFill_Click(object sender, EventArgs e)
        {

            if (comboBox_thuatToanToMau.SelectedIndex == 0)
            {
                if (radioButtonPolygon.Checked)
                {
                    ScanLine(polyPoint, pictureBox_colorFill.BackColor, pictureBox_colorOutline.BackColor);
                    Graphics.FromImage(bitmap).DrawPolygon(new Pen(pictureBox_colorOutline.BackColor), polyPoint.ToArray());
                }
                else if (radioButtonEllipse.Checked || radioButtonCircle.Checked)
                {
                    ScanLineForEllipse(ellipse, pictureBox_colorFill.BackColor, pictureBox_colorOutline.BackColor);
                    Graphics.FromImage(bitmap).DrawEllipse(new Pen(pictureBox_colorOutline.BackColor), ellipse);
                }
                pictureBox.Invalidate();
            }
            else if (comboBox_thuatToanToMau.SelectedIndex == 1)
            {
                if (radioButtonPolygon.Checked)
                {
                    Point mid = getMid(polyPoint);
                    boundaryFill4(mid.X, mid.Y, pictureBox_colorFill.BackColor, pictureBox_colorOutline.BackColor);
                    Graphics.FromImage(bitmap).DrawPolygon(new Pen(pictureBox_colorOutline.BackColor), polyPoint.ToArray());
                }
                if (radioButtonEllipse.Checked || radioButtonCircle.Checked)
                {
                    Point mid = getMid(ellipse);


                    boundaryFill4(mid.X, mid.Y, pictureBox_colorFill.BackColor, pictureBox_colorOutline.BackColor);
                    Graphics.FromImage(bitmap).DrawEllipse(new Pen(pictureBox_colorOutline.BackColor), ellipse);
                }

                pictureBox.Invalidate();
            }
            else if (comboBox_thuatToanToMau.SelectedIndex == 2)
            {
                if (radioButtonPolygon.Checked)
                {
                    Point mid = getMid(polyPoint);
                    ImprovedBoundary(mid.X, mid.Y, pictureBox_colorFill.BackColor, pictureBox_colorOutline.BackColor);
                    Graphics.FromImage(bitmap).DrawPolygon(new Pen(pictureBox_colorOutline.BackColor), polyPoint.ToArray());
                }
                if (radioButtonEllipse.Checked || radioButtonCircle.Checked)
                {
                    Point mid = getMid(ellipse);
                    ImprovedBoundary(mid.X, mid.Y, pictureBox_colorFill.BackColor, pictureBox_colorOutline.BackColor);
                    Graphics.FromImage(bitmap).DrawEllipse(new Pen(pictureBox_colorOutline.BackColor), ellipse);
                }

                pictureBox.Invalidate();
            }
        }

        Point getMid(Rectangle a)
        {
            Point mid = new Point(0, 0);

            mid.X = a.X + a.Width / 2;
            mid.Y = a.Y + a.Height / 2;
            return mid;
        }

        Point getMid(List<Point> p)
        {
            Point mid = new Point(0, 0);
            foreach (Point i in p)
            {
                mid.X += i.X;
                mid.Y += i.Y;
            }
            mid.X /= p.Count;
            mid.Y /= p.Count;
            return mid;
        }

        public Rectangle getSquareFrom2Points(Point p1, Point p2)
        {
            Point oPoint;
            Rectangle rect;

            //đường chéo chính 1 < 2
            if ((p2.X > p1.X) && (p2.Y > p1.Y))
            {
                rect = new Rectangle(p1, new Size(p2.X - p1.X, p2.X - p1.X));
            }
            //đường chéo chính 1 > 2
            else if ((p2.X < p1.X) && (p2.Y < p1.Y))
            {
                rect = new Rectangle(p2, new Size(p1.X - p2.X, p1.X - p2.X));
            }
            //đường chéo phụ
            else if ((p2.X > p1.X) && (p2.Y < p1.Y))
            {
                oPoint = new Point(p1.X, p2.Y);
                rect = new Rectangle(oPoint, new Size(p2.X - p1.X, p2.X - p1.X));
            }
            else
            {
                oPoint = new Point(p2.X, p1.Y);
                rect = new Rectangle(oPoint, new Size(p1.X - p2.X, p1.X - p2.X));
            }
            return rect;
        }

        private void pictureBox_colorOutline_Click(object sender, EventArgs e)
        {
            PictureBox picBox = (PictureBox)sender;
            ColorDialog colorDlg = new ColorDialog();
            colorDlg.FullOpen = true;

            colorDlg.Color = picBox.BackColor;
            if (colorDlg.ShowDialog() == DialogResult.OK)
            {
                picBox.BackColor = colorDlg.Color;
            }
        }

        private void pictureBox_colorFill_Click(object sender, EventArgs e)
        {
            PictureBox picBox = (PictureBox)sender;
            ColorDialog colorDlg = new ColorDialog();
            colorDlg.FullOpen = true;

            colorDlg.Color = picBox.BackColor;
            if (colorDlg.ShowDialog() == DialogResult.OK)
            {
                picBox.BackColor = colorDlg.Color;
            }
        }

        private void buttonHelp_Click(object sender, EventArgs e)
        {
            HelpForm help = new HelpForm();
            help.ShowInTaskbar = false;
            help.Show();
        }

    }
}
