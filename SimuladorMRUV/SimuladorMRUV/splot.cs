using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace SPlot
{
    public class Splot: Control
    {
        public Splot(Control parent, string text, int left, int top, int width, int height): base(parent, text, left, top, width, height)
        {
            Parent = parent;
            Top = top;
            Left= left;
            Height= height;
            Width= width;
            this._top = 0;
            this._left = 0;
            this._height = height-2;
            this._width = width - 2;
            _xr = width - _lMargin - _rMargin;
            _yr = height - _tMargin - _tMargin;
            _dx = _xr / (_xmax - _xmin);
            _dy= _yr / (_ymax-_ymin);
            _title = text;
            DoubleBuffered = true;
            gr=parent.CreateGraphics();
        }

        public float xMax
        {
            get { return _xmax; }
            set
            {
                if (value - _xmin > 0)
                    _xmax = value;
                _dx = _xr / (_xmax - _xmin);
            }
        }
        public float yMax
        {
            get { return _ymax; }
            set
            {
                if (value - _ymin > 0)
                    _ymax = value;
                _dy = _yr / (_ymax - _ymin);
            }
        }

        public float xMin
        {
            get { return _xmin; }
            set {
                if (_xmax-value>0)
                    _xmin = value; 
                    _dx = _xr / (_xmax - _xmin);
                }
        }
        public float yMin
        {
            get { return _ymin; }
            set
            {
                if (_ymax - value > 0)
                {
                    _ymin = value;
                    _dy = _yr / (_ymax - _ymin);
                }
            }
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            Pen blPen = new Pen(Color.Black);
            Pen blPen2 = new Pen(Color.Black, 2);
            Font lf = new Font("arial", 8);
            Font lfb = new Font("arial Bold", 12);
            Brush bub = Brushes.Blue;
//            pe.Graphics.SetClip(new Rectangle((int)_lMargin, (int)_tMargin, (int)(_width-_rMargin), (int)(_height-_tMargin)));
            pe.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            pe.Graphics.Clear(Color.White);
            pe.Graphics.DrawRectangle(new Pen(Color.Black, 2), 0, 0, _width, _height);

            // title
            SizeF bal = pe.Graphics.MeasureString(_title, lfb) / 2;
            pe.Graphics.DrawString(_title, lfb, bub, Width / 2 - bal.Width-25+_lMargin/2, 5);
            // x axis
            float xdel = (xMax - xMin) / 10f;
            float ydel = (yMax - yMin) / 10f;
            float ixdel = (_width - _rMargin - _lMargin) / 10f;
            float iydel = (_height - _tMargin - _tMargin) / 10f;
            // x ticks
            pe.Graphics.DrawLine(blPen2, _lMargin, _height - _tMargin, _width - _rMargin, _height - _tMargin);
            pe.Graphics.DrawString(_xlabel, lf, bub, _width - _lMargin + 10, _height - _tMargin - 3);
            for (int i = 1; i <= 10; i++)
                pe.Graphics.DrawLine(blPen2, _lMargin + ixdel * (float)i, _height - _tMargin - 4, _lMargin + ixdel * (float)i, _height - _tMargin + 4);
            //  y axis
            pe.Graphics.DrawLine(blPen2, _lMargin, _height - _tMargin, _lMargin, _tMargin);
            pe.Graphics.DrawString(_ylabel, lf, bub, _lMargin / 2 - 7, _tMargin - 20);

            // y ticks
            for (int i = 1; i <= 10; i++)
                pe.Graphics.DrawLine(blPen2, _lMargin -4, _height - _tMargin - iydel * (float)i, _lMargin + 4, _height - _tMargin - iydel* (float)i);

            // values
            for (int i = 0; i <= 10; i++)
            {
                pe.Graphics.DrawString(string.Format("{0,5:0.#}", xMin + xdel * (float)i), lf, bub, _lMargin + ixdel * (float)i - 32, _height - _tMargin + 4);
                pe.Graphics.DrawString(string.Format("{0,5:0.#}", yMin + ydel * (float)i), lf, bub, 5, _height - _tMargin - iydel * (float)i - 16);
            }

            // vectors
            Rectangle rect = new Rectangle((int)_lMargin, (int)_tMargin, (int)_xr, (int)_yr);
            GraphicsPath path= new GraphicsPath();
            path.AddRectangle(rect);
            path.CloseFigure();
            Region reg = new Region(path);
            pe.Graphics.SetClip(reg, CombineMode.Replace);
            for (int j=0; j< bytes.Count; j++)

            {
                Regs rg = bytes[j];
                _xa = rg.x[0];
                _ya = rg.y[0];
                for(int i=1; i<rg.x.Length; i++)
                {
                    drawSeg(rg.x[i], rg.y[i], pe.Graphics, _colors[j]);
                    _xa = rg.x[i];
                    _ya = rg.y[i];
                }
            }
 
        }

        void drawSeg(float x, float y, Graphics gr, Color clr)
        {
            Pen pe = new Pen(clr, 2);
            float ix = (_xa - _xmin) * _dx + _lMargin;
            float iy = _height - (_ya-_ymin)*_dy - _tMargin;
            float ex = _lMargin + (x - _xmin) * _dx;
            float ey = Height - _tMargin - (y - _ymin) * _dy;
            gr.DrawLine(pe, ix, iy, ex, ey);
        }

        float doY(float y)
        {
            return (_height - y);
        }

        Graphics gr;
        float _left;
        float _top;
        float _width;
        float _height;
        float _dx;
        float _dy;
        float _xr;
        float _yr;
        float _xmin = 0f;
        float _xmax = 100f;
        float _ymin = 0f;
        float _ymax = 200f;
        float _x, _y;
        float _xa=0;
        float _ya=0;
        float _lMargin = 50;
        float _rMargin = 30;
        float _tMargin = 50;
        string _xlabel = "x";
        string _ylabel = "y";
        string _title;
        public List<Regs> bytes = new List<Regs>();
        Color[] _colors = { Color.Black, Color.Red, Color.Green, Color.Blue, Color.Yellow, Color.Orange, Color.Violet, Color.Turquoise };

    }

    public class Regs
    {
        public Regs(int n)
        {
            x=new float[n];
            y=new float[n];
        }

        public float[] x;
        public float[] y;
    }

    public class PanelMruv: Panel
    {
        public PanelMruv(Control parent, int x, int y, int width, int height): base()
        {
            Parent= parent;
            Left = x;
            Top = y;
            Width = width;
            Height = height;
            _width = width-2;
            _height = height-2;
            _x = 0f;
            _range = _width-_lMargin-_rMargin;
            _dRamp = _range / (_rampSize + _rampHead);
            DoubleBuffered = true;

            _g = 9.81f;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            Pen blPen = new Pen(Color.Black);
            Pen blPen2 = new Pen(Color.Black, 2);
            Font lf = new Font("arial", 10);
            Font lfb = new Font("Arial", 12, FontStyle.Bold);
            
            SizeF bal=pe.Graphics.MeasureString(tit, lfb)/2;
            Brush bub = Brushes.Blue;
            pe.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            pe.Graphics.Clear(Color.White);
            pe.Graphics.DrawRectangle(new Pen(Color.Black, 2), 0, 0, _width, _height);
            pe.Graphics.DrawString(_tit, lfb, Brushes.Green, Width / 2 - bal.Width, 25);

            // draw ramp
            float rampX = -(_width - _lMargin - _rMargin);
            float rampY = doY(_tMargin);
            pe.Graphics.ResetTransform();
            pe.Graphics.TranslateTransform(_width - _rMargin, rampY);
            pe.Graphics.DrawLine(blPen2, 0, 0, rampX, 0);
            pe.Graphics.RotateTransform(_angle);
            pe.Graphics.DrawLine(blPen2, 150, 0, rampX, 0);
            // ticks
            float px = rampX + _rampHead * _dRamp;
            pe.Graphics.DrawLine(blPen2, px, 6f, px, 0f);
            px = rampX + (_rampHead+_rampSize) * _dRamp;
            pe.Graphics.DrawLine(blPen2, px, 6f, px, 0f);
            // bos
            pe.Graphics.FillRectangle(Brushes.Orange, rampX + (_x + _rampHead - 15f) * _dRamp, -10*_dRamp, 15f * _dRamp, 10f * _dRamp);
        }

        public float  nextX(float t, float v0, float g)
        {
            float res=(float)((double)v0*(double)t+0.5*Math.Pow((double)t, 2.0)*(double)g);
            return res;
        }

        public float nextV(float t, float v0, float g)
        {
            float res = v0 + g * t;
            return res;
        }
        float angToRad(float ang)
        {
            return (float)((double)ang*Math.PI/180.0);

        }
        float doY(float y)
        {
            return (_height - y);
        }

        public float angle
        {
            get { return _angle; }
            set { 
                    if (value>=5.0 && value<=85.0)
                    _angle = value;
                }
        }

        public float x
        {
            get { return _x; }
            set
            {
                _x = value;
            }
        }

        public float g
        {
            get { return _g; }
            set
            {
                _g = value;
            }
        }

        public float rampSize
        {
            get { return _rampSize; }
            set { _rampSize = value; }
        }

        public string tit
        {
            get { return _tit; }
            set { _tit = value; }
        }

        float _width;
        float _height;
        float _lMargin = 40;
        float _rMargin = 30;
        float _tMargin = 60;
        float _bMargon = 30;

        // real size of the line
        float _range;

        float _angle = 45f;
        float _rampSize = 100f;
        float _rampHead = 20f;
        float _dRamp;
        float _g;
        float _x;
        float _v;
        string _tit = "Simulador M.R.U.V";

    }
}
