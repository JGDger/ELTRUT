using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeneticTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            int[,] field = new int[10, 10] {
                {0,0,1,0,1,0,0,1,0,1},
                {0,0,1,0,1,0,1,1,0,1},
                {0,0,0,0,1,0,0,0,0,0},
                {1,1,0,1,1,0,1,1,1,0},
                {1,0,0,0,0,0,0,0,1,0},
                {0,0,1,0,1,0,1,0,1,1},
                {1,1,1,0,1,0,0,0,0,1},
                {0,0,0,0,1,0,0,1,0,0},
                {1,1,0,1,1,0,0,1,1,0},
                {1,0,0,0,0,1,0,0,1,0}
            };
            Creature.field = field;
            Image I = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics G = Graphics.FromImage(I);
            float w = I.Width / (Creature.field.GetUpperBound(0) + 1);
            float h = I.Height / (Creature.field.GetUpperBound(1) + 1);
            G.Clear(Color.White);
            G.FillRectangle(Brushes.Yellow, 0, 0, w, h);
            G.FillRectangle(Brushes.LimeGreen, w * field.GetUpperBound(0), h * field.GetUpperBound(0), w, h);
            for (int i = 0; i < field.GetUpperBound(0)+1; i++)
            {
                G.DrawLine(Pens.Black, 0, h * i, I.Width, h * i);
                G.DrawLine(Pens.Black, w * i, 0, w * i, I.Height);
                for (int j = 0; j < field.GetUpperBound(0)+1; j++)
                {
                    if (Creature.field[i, j] == 1) G.FillRectangle(Brushes.Black, i * w, j * h, w, h);
                }
            }
            pictureBox1.Image = I;
        }
        Creature cr;
        Creature[] generation;
        int crNext = 0;
        int gen;
        private void button1_Click(object sender, EventArgs e)
        {
            cr = new Creature(-1);
            cr.program.Clear();
            Command F = new Command(4);
            F.forM = 2;
            F.forOps = 1;
            cr.program.Add(F);
            cr.program.Add(new Command(Commands.X_INC));
            cr.program.Add(F);
            cr.program.Add(new Command(Commands.Y_INC));
            cr.program.Add(F);
            cr.program.Add(new Command(Commands.X_INC));
            foreach (Command c in cr.program) { Console.Write(c.ToString() + "; "); }
            Console.WriteLine();
            tmr.Start();
        }

        private void tmr_Tick(object sender, EventArgs e)
        {
            Image I = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics G = Graphics.FromImage(I);
            float w = I.Width / (Creature.field.GetUpperBound(0) + 1);
            float h = I.Height / (Creature.field.GetUpperBound(1) + 1);
            G.Clear(Color.White);
            G.FillRectangle(Brushes.Yellow, 0, 0, w, h);
            G.FillRectangle(Brushes.LimeGreen, w * Creature.field.GetUpperBound(0), h * Creature.field.GetUpperBound(1), w, h);
            G.FillRectangle(Brushes.SteelBlue, cr.X * w, cr.Y * h, w, h);
            for (int i = 0; i < Creature.field.GetUpperBound(0)+1; i++)
            {
                G.DrawLine(Pens.Black, 0, h * i, I.Width, h * i);
                G.DrawLine(Pens.Black, w * i, 0, w * i, I.Height);
                for (int j = 0; j < Creature.field.GetUpperBound(1) + 1; j++)
                {
                    if (Creature.field[i, j] == 1) G.FillRectangle(Brushes.Black, i * w, j * h, w, h);
                }
            }
            G.DrawString(cr.Distance() + "", Font, Brushes.Black, 0, 0);
            pictureBox1.Image = I;
            cr.Step();
            if (cr.Stopped) { listBox1.Enabled = true; tmr.Stop(); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 200; i++)
            {
                btnNextGen_Click(sender, e);
                Array.Sort(generation);
                if (generation[0].Distance() == 0) break;
            }
        }

        private void btnNewGen_Click(object sender, EventArgs e)
        {
            crNext = 0;
            gen = 1;
            stsGeneration.Text = "Generation: 1";
            generation = new Creature[100];
            listBox1.Enabled = true;
            tmr.Stop();
            listBox1.Items.Clear();
            double sum = 0;
            for (int i=0; i<100; i++)
            {
                generation[i] = new Creature(crNext++);
                generation[i].Mutate();
                for (int j = 0; j < generation[i].program.Count; j++) generation[i].Step();
                listBox1.Items.Add("Creation #" + generation[i].ID + " (reached " + generation[i].Distance() + ")");
                sum += generation[i].Distance();
                generation[i].Restart();
            }
            stsAvgDistance.Text = "Average Distance: " + Math.Round(sum) / 100;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.Enabled = false;
            cr = generation[listBox1.SelectedIndex];
            cr.Restart();
            foreach (Command c in cr.program) { Console.Write(c.ToString() + "; "); }
            Console.WriteLine();
            tmr.Start();
        }

        private void btnNextGen_Click(object sender, EventArgs e)
        {
            gen++;
            stsGeneration.Text = "Generation: " + gen;
            Array.Sort(generation);
            for (int i = 10; i < 100; i++)
            {
                generation[i].Mutate();
            }
            for (int i = 70; i < 100; i++)
            {
                generation[i] = new Creature(crNext++);
                generation[i].Mutate();
            }
                listBox1.Items.Clear();
            Array.Sort(generation);
            double sum = 0;
            foreach (Creature c in generation)
            {
                c.Restart();
                while(!c.Stopped) c.Step();
                listBox1.Items.Add("Creation #" + c.ID + " (reached " + c.Distance() + ")");
                sum += c.Distance();
            }
            Image I = new Bitmap(pictureBox1.Image);
            Graphics G = Graphics.FromImage(I);
            float w = I.Width / (Creature.field.GetUpperBound(0) + 1);
            float h = I.Height / (Creature.field.GetUpperBound(1) + 1);
            G.Clear(Color.White);
            G.FillRectangle(Brushes.Yellow, 0, 0, w, h);
            G.FillRectangle(Brushes.LimeGreen, w * Creature.field.GetUpperBound(0), h * Creature.field.GetUpperBound(1), w, h);
            for (int i = 0; i < Creature.field.GetUpperBound(0)+1; i++)
            {
                G.DrawLine(Pens.Black, 0, h * i, I.Width, h * i);
                G.DrawLine(Pens.Black, w * i, 0, w * i, I.Height);
                for (int j = 0; j < Creature.field.GetUpperBound(1)+1; j++)
                {
                    if (Creature.field[i, j] == 1) G.FillRectangle(Brushes.Black, i * w, j * h, w, h);
                }
            }
            Creature C = generation[0];
            int old_X = 0, old_Y = 0;
            C.Restart();
            while (!C.Stopped)
            {
                C.Step();
                G.DrawLine(Pens.Red, w / 2 + w * old_X, h / 2 + h * old_Y, w / 2 + w * C.X, h / 2 + h * C.Y);
                old_X = C.X;
                old_Y = C.Y;
            }
            pictureBox1.Image = I;
            stsAvgDistance.Text = "Average Distance: " + Math.Round(sum) / 100;
            this.Refresh();
        }
    }
}
