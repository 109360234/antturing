using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Button button;
        Button[,] buttons;
        int[,] board = new int[80, 80];
        int[,] newboard = new int[80, 80];
        bool keydown = true;
        int x, y;
        private void Form1_Load(object sender, EventArgs e)
        {
            int i, j, number = 0;
            button1.Text = "start";
            this.Width = 1000;
            this.Height = 1000;
            buttons = new Button[80, 80];
            for (i = 0; i < 80; i++)
            {
                for (j = 0; j < 80; j++)
                {
                    buttons[i, j] = new Button
                    {
                        Name = i.ToString() + j.ToString(),
                        Text= i.ToString() + j.ToString(),
                        Location = new Point(10 * i, 10 * j),
                        BackColor = Color.White,
                        Size = new Size(10, 10),
                    };
                    buttons[i, j].MouseClick += antfirst;
                    this.Controls.Add(buttons[i, j]);
                }
            }
        }
        private void antfirst(object sender, EventArgs e)
        {
            button = (Button)sender;
            if (keydown == true)
            {
               button.BackColor = Color.Black;
                keydown = !keydown;
            }
            else
            {
                button.BackColor = Color.White;
                keydown = !keydown;
            }
        }   
   
         private void button1_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < 80; i++)
            {
                for (int j = 0; j < 80; j++)
                {
                    if (buttons[i, j].BackColor == Color.Black)
                    {
                        x = i;
                        y = j;
                    }
                }
            }
            while (true)
            {
                ant();
            }
        }
        private void ant()
        {        
            int tx, ty;
            int firstdirection = 3;
            for (int i = 0; i <80; i++)
            {
                for (int j = 0; j <80; j++)
                {
                    switch (firstdirection)
                    {
                        case 0:     ///上
                            ty = y -1;
                            tx = x;
                            break;
                        case 1:     ///左                        
                            ty = y;
                            tx = x - 1;
                            break;


                        case 2:  ///下
                            ty = y + 1;
                            tx = x;
                            break;

                        case 3:  ///右
                            ty = y;
                            tx = x + 1;

                            break;

                       default:
                            ty = y;
                            tx = x;
                            break;
                    }
                    if (tx >= 0)               //邊界限制
                        if (tx <80)
                           x=tx;
                        else
                            x = tx - 80;
                    else
                        x = tx + 80;
                    if (ty >= 0)
                        if (ty < 80)
                            y = ty;
                        else
                            y = ty - 80;
                    else
                        y = ty + 80;

                    if (buttons[x,y].BackColor==Color.White)
                    {               
                        buttons[x, y].BackColor = Color.Black;
                        firstdirection = firstdirection % 4 - 1;
                          if (firstdirection <0) firstdirection = 3;
                   }                      
                    else if(buttons[x, y].BackColor != Color.White)
                    {
                        buttons[x, y].BackColor = Color.White;
                        firstdirection = firstdirection % 4 + 1;
                        if (firstdirection > 3) firstdirection = 0;
                    }
                    Application.DoEvents();
                    Thread.Sleep(1);
                }
            }
        }   
    }
}
