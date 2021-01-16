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


namespace sg_Pathfinder
{
    public partial class Form1 : Form
    {
        PictureBox[,] picArr = new PictureBox[6,6];

        int[] x, y;
        int endX, endY;
        bool endPass = false;

        bool[,] avail = new bool[6, 6];
        Label mess, mess2, routesMess;
        Button shortestBtn;


        //path storage
        int[] storeLength = { };
        string[] routeStoreX = { };
        string[] routeStoreY = { };
        public Form1()
        {
            InitializeComponent();
            this.mess = message;
            this.mess2 = storelbl;
            this.routesMess = routlbl;
            this.shortestBtn = shortBtn;
            avail[0, 0] = false;
            avail[0, 1] = false;
            avail[0, 2] = false;
            avail[0, 3] = false;
            avail[0, 4] = false;
            avail[0, 5] = false;
            avail[1, 0] = false;
            avail[1, 1] = false;
            avail[1, 2] = false;
            avail[1, 3] = false;
            avail[1, 4] = false;
            avail[1, 5] = false;
            avail[2, 0] = false;
            avail[2, 1] = false;
            avail[2, 2] = false;
            avail[2, 3] = false;
            avail[2, 4] = false;
            avail[2, 5] = false;
            avail[3, 0] = false;
            avail[3, 1] = false;
            avail[3, 2] = false;
            avail[3, 3] = false;
            avail[3, 4] = false;
            avail[3, 5] = false;
            avail[4, 0] = false;
            avail[4, 1] = false;
            avail[4, 2] = false;
            avail[4, 3] = false;
            avail[4, 4] = false;
            avail[4, 5] = false;
            avail[5, 0] = false;
            avail[5, 1] = false;
            avail[5, 2] = false;
            avail[5, 3] = false;
            avail[5, 4] = false;
            avail[5, 5] = false;

            picArr[0,0] = pic1;
            picArr[0,1] = pic2;
            picArr[0,2] = pic3;
            picArr[0,3] = pic4;
            picArr[0,4] = pic5;
            picArr[0,5] = pic6;
            picArr[1,0] = pic7;
            picArr[1,1] = pic8;
            picArr[1,2] = pic9;
            picArr[1,3] = pic10;
            picArr[1,4] = pic11;
            picArr[1,5] = pic12;
            picArr[2,0] = pic13;
            picArr[2,1] = pic14;
            picArr[2, 2] = pic15;
            picArr[2, 3] = pic16;
            picArr[2, 4] = pic17;
            picArr[2, 5] = pic18;
            picArr[3,0] = pic19;
            picArr[3,1] = pic20;
            picArr[3,2] = pic21;
            picArr[3,3] = pic22;
            picArr[3,4] = pic23;
            picArr[3,5] = pic24;
            picArr[4,0] = pic25;
            picArr[4,1] = pic26;
            picArr[4,2] = pic27;
            picArr[4,3] = pic28;
            picArr[4,4] = pic29;
            picArr[4,5] = pic30;
            picArr[5, 0] = pic31;
            picArr[5, 1] = pic32;
            picArr[5, 2] = pic33;
            picArr[5,3] = pic34;
            picArr[5,4] = pic35;
            picArr[5,5] = pic36;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            for (int i = 0; i < 6; i++)
            {
                for (int k = 0; k < 6; k++)
                {
                    picArr[i,k].BackColor = Color.LightBlue;
                }
            }

            randomize();
        }

        public int[] randPos()
        {
            bool pass = false;
            int[] result1 = null, result2 = null;
            int[] draw = { };

            while (pass == false)
            {
                if (x[x.Length - 1] < endX)
                {
                    if (!avail[x[x.Length - 1] + 1, y[y.Length - 1]])
                    {

                        x[x.Length - 1]++;
                        result1 = x.Append(x[x.Length - 1]);
                        result2 = y.Append(y[y.Length - 1]);
                        int[] tempx = { x[x.Length - 1], y[y.Length - 1] };
                        draw = tempx;
                        pass = true;

                    }
                } else if (x[x.Length - 1] > endX) {
                    if (!avail[x[x.Length - 1] - 1, y[y.Length - 1]])
                    {
                        x[x.Length - 1]--;
                        result1 = x.Append(x[x.Length - 1]);
                        result2 = y.Append(y[y.Length - 1]);
                        int[] tempx = { x[x.Length - 1], y[y.Length - 1] };
                        draw = tempx;
                        pass = true;
                    }
                }else
                {
                    if (y[y.Length - 1] < endY)
                    {
                        if (!avail[y[y.Length - 1] + 1, x[x.Length - 1]])
                        {
                            y[y.Length - 1]++;
                            result1 = x.Append(x[x.Length - 1]);
                            result2 = y.Append(y[y.Length - 1]);
                            int[] tempx = { x[x.Length - 1], y[y.Length - 1] };
                            draw = tempx;
                            pass = true;
                        }
                    } else if (y[y.Length - 1] > endY)
                    {
                        if (!avail[y[y.Length - 1] - 1, x[x.Length - 1]])
                        {
                            y[y.Length - 1]--;
                            result1 = x.Append(x[x.Length - 1]);
                            result2 = y.Append(y[y.Length - 1]);
                            int[] tempx = { x[x.Length - 1], y[y.Length - 1] };
                            draw = tempx;
                            pass = true;
                        }
                    }
                }
            }
            mess.Text = "X: " + x.Length.ToString() + ", Y: " + y.Length.ToString();
            mess.Text += " R: " + result1.Length.ToString() + " RR: " + result2.Length.ToString();

            x = result1;
            y = result2;

            
            return draw;
        }

        public void startBTN_Click(object sender, EventArgs e)
        {
            start(true);
        }

        public bool lostPath()
        {
            int xAxis = x[x.Length - 1];
            int yAxis = y[y.Length - 1];

            try
            {
                if (!avail[xAxis + 1, yAxis])
                {
                    return false;
                }
            }
            catch { }

            try
            {
                if (!avail[xAxis - 1, yAxis])
                {
                    return false;
                }
            }
            catch { }

            try
            {
                if (!avail[xAxis, yAxis + 1])
                {
                    return false;
                }
            }
            catch { }

            try
            {
                if (!avail[xAxis, yAxis - 1])
                {
                    return false;
                }
            }
            catch { }

            return true;
        }

        public bool check()
        {
            int curX = x[x.Length - 1];
            int curY = y[y.Length - 1];
            if (curX + 1 == endX && curY == endY) { return true; }
            else if (curX - 1 == endX && curY == endY) { return true; }
            else if (curX == endX && curY + 1 == endY) { return true; }
            else if (curX == endX && curY - 1 == endY) { return true; }
            return false;
        }

        private void randomBtn_Click(object sender, EventArgs e)
        {
            randomize();
        }
        public void randomize()
        {
            Random r = new Random();
            int newX = r.Next(0, 6);
            int newY = r.Next(0, 6);
            int endXX = r.Next(0, 6);
            int endYY = r.Next(0, 6);

            int[] tempX = { newX },
                  tempY = { newY };
            x = tempX;
            y = tempY;

            endX = endXX;
            endY = endYY;

            reset();
            resetEverything();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            reset();
        }

        async void start(bool wait)
        {
            reset();
            while (endPass == false)
            {
                if (wait) { await Task.Delay(200); }
                else { await Task.Delay(0); }

                int[] res = randPos();
                picArr[res[0], res[1]].BackColor = Color.Red;

                if (check())
                {
                    storePaths();
                    endPass = true;
                }

                if (lostPath())
                {
                    mess.Text = "Lost Path";
                    endPass = true;
                    start(true);
                }
            }
        }

        async void shortBtn_Click(object sender, EventArgs e)
        {
            resetEverything();
            for (int i = 0; i < 10; i++)
            {
                start(false);
                await Task.Delay(200);
            }
            mess.Text = shortestPath().ToString() + " blocks";
        }

        public void storePaths() {
            int[] tempStore = storeLength.Append(x.Length - 1);
            storeLength = tempStore;
            mess2.Text = "Storage LEN: " + string.Join(",", storeLength);


            string[] tempRoutesX = routeStoreX.Append(string.Join(",", x));
            routeStoreX = tempRoutesX;
            string[] tempRoutesY = routeStoreY.Append(string.Join(",", y));
            routeStoreY = tempRoutesY;

            routesMess.Text = "Routes: \n";
            for (int i = 0; i < routeStoreX.Length; i++)
            {
                routesMess.Text += "{ x: " + routeStoreX[i] + " |\n Y: " + routeStoreY[i] + " }\n\n";
            }
        }

        public void drawOptimal(string xx, string yy) {

            reset();

            string[] holdX = xx.Split(',');
            string[] holdY = yy.Split(',');

            for (int i = 0; i < holdX.Length; i++)
            {
                picArr[int.Parse(holdX[i]), int.Parse(holdY[i])].BackColor = Color.Red;
            }
            picArr[int.Parse(holdX[0]), int.Parse(holdY[0])].BackColor = Color.Green;
        }
        public int shortestPath()
        {
            int holdTemp = 100;
            int place = 0;
            for (int i = 0; i < storeLength.Length; i++)
            {
                try
                {
                    if (storeLength[i] < holdTemp) { holdTemp = storeLength[i]; place = i; }
                }
                catch { }
            }

            drawOptimal(routeStoreX[place], routeStoreY[place]);
            return storeLength[place];
        }

        public void reset()
        {
            for (int i = 0; i < 6; i++)
            {
                for (int k = 0; k < 6; k++)
                {
                    picArr[i, k].BackColor = Color.LightBlue;
                    avail[i, k] = false;
                }
            }

            int[] tempX = {x[0]};
            int[] tempY = {y[0]};
            x = tempX;
            y = tempY;
            picArr[x[0], y[0]].BackColor = Color.Green;
            picArr[endX, endY].BackColor = Color.Black;
            avail[x[0], y[0]] = true;
            avail[endX, endY] = true;
            shortBtn.Text = "find shortest";
            endPass = false;
        }

        public void resetEverything()
        {
            int[] erase = { };
            string[] erase2 = { };

            storeLength = erase;
            routeStoreX = erase2;
            routeStoreY = erase2;

            mess2.Text = "";
            routesMess.Text = "";
        }
    }

    public static class Extensions
    {
        public static T[] Append<T>(this T[] array, T item)
        {
            List<T> list = new List<T>(array);
            list.Add(item);

            return list.ToArray();
        }
    }

}
