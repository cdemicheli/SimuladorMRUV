using Microsoft.VisualBasic;
using SPlot;

namespace SimuladorMRUV
{
    public partial class Form1 : Form
    {
        Splot sp;
        PanelMruv pn;
        bool silRun = false;
        int period = 100; // ms
        float fPeriod = 0f;
        float cntt = 0f;
        float v0 = 0f;
        float vMax = 0f;
        enum Places { Terra, Marte, Lua };
        Dictionary<Places, double> places = new Dictionary<Places, double>();
        Places place= Places.Terra;
        double g = 0f;
        List<float> xx = new List<float>();
        List<float> yy = new List<float>();
        string[] placesStr = { "Terra", "Marte", "Lua" };
        public Form1()
        {
            InitializeComponent();
            fPeriod = (float)period / 1000f;
            places.Add(Places.Terra, 9.80665f);
            places.Add(Places.Marte, 3.72076f);
            places.Add(Places.Lua, 1.625f);
            g = places[Places.Terra];

            sp = new Splot(this, "Velocidade na Descida", textBox1.Left+(textBox1.Width-300)/2, 15 + menuStrip1.Height, 300, 225);
            pn = new PanelMruv(this, 25, ClientSize.Height - 700 - 25, 700, 700);
            simMsg();
            pn.angle = trackBar1.Value;
            pn.Invalidate();
            sp.yMin = 0f;
            sp.yMax = 50f;
            sp.xMax = 20f;
            initMsg();

            Regs vel = new Regs(100);


        }

        void simMsg()
        {
            pn.tit = string.Format("Simulador M.R.U.V - {0}", placesStr[(int)place]);
            pn.Invalidate(true);
        }
        void initMsg()
        {
            msg("\r\nPronto para simular");
            msg("Selecione a inclinação e a aceleração (g)");

        }
        void msg(string msg)
        {
            if (msg != null)
            {
                textBox1.AppendText(msg + "\r\n");
            }
        }
        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            pn.angle = trackBar1.Value;
            pn.Invalidate();
            textBox2.Text = string.Format(" {0} º", pn.angle);
        }

        private void terraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            terraToolStripMenuItem.Checked = true;
            marteToolStripMenuItem.Checked = false;
            luaToolStripMenuItem.Checked = false;
            place = Places.Terra;
            pn.g = (float)places[place];
            simMsg();
        }

        private void marteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            terraToolStripMenuItem.Checked = false;
            marteToolStripMenuItem.Checked = true;
            luaToolStripMenuItem.Checked = false;
            place = Places.Marte;
            pn.g = (float)places[place];
            simMsg();
        }

        private void luaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            terraToolStripMenuItem.Checked = false;
            marteToolStripMenuItem.Checked = false;
            luaToolStripMenuItem.Checked = true;
            place = Places.Lua;
            pn.g = (float)places[place];
            simMsg();
        }

        private void simulaçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void iniciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            silRun = true;
            iniciaToolStripMenuItem.Enabled = false;
            rearmaToolStripMenuItem.Enabled = true;
            textBox1.Clear();
            msg(string.Format("Usando aceleração (g): {0,5:0.####} {1}", places[place], placesStr[(int)place]));
            msg(string.Format("Usando inclinação de {0} º", pn.angle));
            msg("Aguarde o final da simulação...");
            Thread thr = new Thread(simThread);
           xx.Clear();
            yy.Clear();
            sp.bytes.Clear();
            thr.Start();
            thr.Join();
            msg("\r\nFinal de simulação");
            double a = pn.g * Math.Sin(pn.angle * Math.PI / 180.0);
            double ttot = Math.Sqrt(2.0*100.0/a);
            double log = (Math.Truncate(ttot / 10.0) + 1) * 10.0;
            sp.xMax = (float)log;
            log = (Math.Truncate(a*ttot / 10.0) + 1) * 10.0;
            sp.yMax = (float)log;
            sp.Invalidate();
            msg(string.Format("Tempo gasto para descer 100 m: {0,5:0.###}", ttot));
            msg(string.Format("Velocidade máxima:  {0,5:0.###} m/s", a * ttot));
            msg(string.Format("Velocidade média: {0,5:0.###} m/s", 100.0 / ttot));
            msg("\r\nClique em Simulação/Rearme se quiser repetir");
            initMsg();
            silRun = false;
 

        }

        private void rearmaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pn.x = 0f;
            cntt = 0f;
            pn.Invalidate();
            sp.bytes.Clear();
            sp.Invalidate();
            iniciaToolStripMenuItem.Enabled = true;
            rearmaToolStripMenuItem.Enabled = false;
        }

        void simThread()
        {
            bool done = false;
            xx.Add(0);
            yy.Add(0);
            float sin = (float)Math.Sin((double)pn.angle * Math.PI / 180.0);
            while (silRun)
            {
                 pn.x = pn.nextX(cntt, v0, pn.g * sin);

                cntt += fPeriod;
                pn.Invalidate();
                Application.DoEvents();
                if (pn.x>=pn.rampSize+25)
                    silRun= false;
                if (pn.x <= 100f)
                {
                    vMax = pn.nextV(cntt, v0, sin * pn.g);
                    xx.Add(cntt);
                    yy.Add(vMax);
                }
                else
                {
                    if (!done)
                    {
                        Regs reg = new Regs(xx.Count());
                        for (int i = 0; i < xx.Count(); i++)
                        {
                            reg.x[i] = xx[i];
                            reg.y[i] = yy[i];
                        }
                        sp.bytes.Add(reg);
                        done = true;
                    }
                }
                Application.DoEvents();
                Thread.Sleep(period);
            }
        }
    }
}
