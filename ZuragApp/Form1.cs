namespace mouse_event_paint
{
    public partial class Form1 : Form
    {
        bool drawing = false;          // Хулганы товч дарагдсан эсэх
        Point last;                    // Харандаагаар зурахад: өмнөх цэг
        Point start;                   // Тэгш өнцөгт зурахад: эхлэх цэг

        Color penColor = Color.Black;  // Өнгө
        int penWidth = 1;              // Өргөн
        string mode = "pen";           // "pen" = хулганаар зурах, "rect" = тэгш өнцөгт

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        // ===== Хулганы үйл явдлууд =====

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            drawing = true;
            last = e.Location;
            start = e.Location;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (drawing && mode == "pen")
            {
                Graphics g = CreateGraphics();
                Pen pen = new Pen(penColor, penWidth);

                g.DrawLine(pen, last, e.Location);

                pen.Dispose();
                g.Dispose();
                last = e.Location;
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (drawing && mode == "rect")
            {
                // Хулганыг аль чиглэлд чирсэн ч зөв тэгш өнцөгт гаргана
                int x = Math.Min(start.X, e.X);
                int y = Math.Min(start.Y, e.Y);
                int w = Math.Abs(e.X - start.X);
                int h = Math.Abs(e.Y - start.Y);

                Graphics g = CreateGraphics();
                Pen pen = new Pen(penColor, penWidth);

                g.DrawRectangle(pen, x, y, w, h);

                pen.Dispose();
                g.Dispose();
            }
            drawing = false;
        }

        // ===== Tools цэс =====

        // Tools → Хулганаар зурах
        private void customizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mode = "pen";
        }

        // Tools → Тэгш өнцөгт
        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mode = "rect";
        }

        // Tools → Өнгө
        private void өнгөToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = penColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                penColor = colorDialog1.Color;
            }
        }

        // Өргөн сонгох ComboBox
        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            penWidth = int.Parse(toolStripComboBox1.SelectedItem.ToString());
        }

        private void хулганаарЗурахToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
