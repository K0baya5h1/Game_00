using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Graphics graph;
        int nowp = 0;
        int drawflag = 0;
        int jjf = 0;
        float u = 50.0f;
        System.Random r = new System.Random();
        int turn = 0;
        new float [,]p={ 
            { 0,0,0,0,0,0,0,0,0,0,0},
            { 0,0,0,0,0,0,0,0,0,0,0},           
            { 0,0,0,0,0,0,0,0,0,0,0},       
            { 0,0,0,0,0,0,0,0,0,0,0},       
            { 0,0,0,0,0,0,0,0,0,0,0},        
            { 0,0,0,0,0,0,0,0,0,0,0},       
            { 0,0,0,0,0,0,0,0,0,0,0},        
            { 0,0,0,0,0,0,0,0,0,0,0},        
            { 0,0,0,0,0,0,0,0,0,0,0},       
            { 0,0,0,0,0,0,0,0,0,0,0},
            { 0,0,0,0,0,0,0,0,0,0,0}};
        new float[,] p_pp ={
            { 0,0,0,0,0,0,0,0,0,0,0},
            { 0,0,0,0,0,0,0,0,0,0,0},
            { 0,0,0,0,0,0,0,0,0,0,0},
            { 0,0,0,0,0,0,0,0,0,0,0},
            { 0,0,0,0,0,0,0,0,0,0,0},
            { 0,0,0,0,0,0,0,0,0,0,0},
            { 0,0,0,0,0,0,0,0,0,0,0},
            { 0,0,0,0,0,0,0,0,0,0,0},
            { 0,0,0,0,0,0,0,0,0,0,0},
            { 0,0,0,0,0,0,0,0,0,0,0},
            { 0,0,0,0,0,0,0,0,0,0,0}};
        float p_p1 = 0,p_p2=0;

        void chanp()
        {
            if (nowp == 1)
            {
                nowp = 2;
            }
            else
            {
                nowp = 1;
            }
        }

        void drawmap(int x,int y)
        {
            if (nowp == 1)
            {
                if (p_pp[x, y] !=0)
                {
                    listBox1.Items.Add("ここにはおけません");
                }
                else
                {
                    graph.FillEllipse(Brushes.Red, u * (x - 1), u * (y - 1), 50, 50);
                    p_pp[x, y] = nowp;
                    p_p1 += p[x, y];
                    textBox1.Text = Convert.ToString(p_p1);
                    drawflag++;
                }
            }
            else
            {
                if (p_pp[x, y] !=0)
                {
                    listBox1.Items.Add("ここにはおけません");
                }
                else
                {
                    graph.FillEllipse(Brushes.Blue, u * (x - 1), u * (y - 1), 50, 50);
                    p_pp[x, y] = nowp;
                    p_p2 += p[x, y];
                    textBox2.Text = Convert.ToString(p_p2);
                    drawflag++;
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        void init()
        {
            turn= r.Next(10, 40);
            p_p1 = 0;
            p_p2 = 0;
            nowp = 1;
            textBox1.Text =Convert.ToString(p_p1);
            textBox2.Text = Convert.ToString(p_p2);
            for(int i = 1; i <= 10; i++)
            {
                for (int j = 1; j <= 10; j++)
                {
                    p[i, j] =r.Next(-10,30);
                    p_pp[i, j] = 0;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int px, py;
            if (turn <1)
            {
                listBox1.Items.Add("操作は無効です");
            }

            if(textBox3.Text != "" && textBox4.Text != "" && turn>0) {
                px = Convert.ToInt32(textBox3.Text);
                py = Convert.ToInt32(textBox4.Text);
                if (px > 10 || py > 10 || px < 1 || py < 1)
                {
                    listBox1.Items.Add("不正な数が入力されました。");
                }
                else
                {
                    drawmap(px, py);
                }
                if (drawflag != 0)
                {
                    if (turn > 0)
                    {
                        turn--;
                        chanp();
                        listBox1.Items.Add("残り" + turn + "ターンです");
                        listBox1.Items.Add("現在のプレイヤーはPlayer" + nowp + "です");
                        drawflag = 0;
                    }

                }
            }
      
            if (turn < 1 && jjf == 0)
            {
                if (p_p1 > p_p2)
                {
                    listBox1.Items.Add("Player1 is win!!");
                }
                else
                {
                    listBox1.Items.Add("Player2 is win!!");
                }
                jjf = 1;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Font fnt = new Font("MS UI Gothic", 20);
            for (int i = 1; i <= 10; i++)
            {
                for(int j = 1; j <= 10; j++)
                {
                    graph.DrawString(Convert.ToString(p[i,j]),fnt,Brushes.Black,u*(i-1),u*(j-1) );
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            graph.Clear(BackColor);
            init();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            graph = pictureBox1.CreateGraphics();
            for(int i = 0; i <= 10; i++)
            {
                graph.DrawLine(Pens.Black,i * u, 0, i * u,500);
                graph.DrawLine(Pens.Black, 0,i*u, 500,i*u);
            }
            init();
            
        }
    }
}