namespace SimuladorMRUV
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            arquivoToolStripMenuItem = new ToolStripMenuItem();
            sairToolStripMenuItem = new ToolStripMenuItem();
            simulaçãoToolStripMenuItem = new ToolStripMenuItem();
            iniciaToolStripMenuItem = new ToolStripMenuItem();
            rearmaToolStripMenuItem = new ToolStripMenuItem();
            gravidadeToolStripMenuItem = new ToolStripMenuItem();
            terraToolStripMenuItem = new ToolStripMenuItem();
            marteToolStripMenuItem = new ToolStripMenuItem();
            luaToolStripMenuItem = new ToolStripMenuItem();
            trackBar1 = new TrackBar();
            label1 = new Label();
            textBox1 = new TextBox();
            label2 = new Label();
            textBox2 = new TextBox();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { arquivoToolStripMenuItem, simulaçãoToolStripMenuItem, gravidadeToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1258, 33);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // arquivoToolStripMenuItem
            // 
            arquivoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { sairToolStripMenuItem });
            arquivoToolStripMenuItem.Name = "arquivoToolStripMenuItem";
            arquivoToolStripMenuItem.Size = new Size(91, 29);
            arquivoToolStripMenuItem.Text = "&Arquivo";
            // 
            // sairToolStripMenuItem
            // 
            sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            sairToolStripMenuItem.Size = new Size(143, 34);
            sairToolStripMenuItem.Text = "&Sair";
            sairToolStripMenuItem.Click += sairToolStripMenuItem_Click;
            // 
            // simulaçãoToolStripMenuItem
            // 
            simulaçãoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { iniciaToolStripMenuItem, rearmaToolStripMenuItem });
            simulaçãoToolStripMenuItem.Name = "simulaçãoToolStripMenuItem";
            simulaçãoToolStripMenuItem.Size = new Size(109, 29);
            simulaçãoToolStripMenuItem.Text = "&Simulação";
            simulaçãoToolStripMenuItem.Click += simulaçãoToolStripMenuItem_Click;
            // 
            // iniciaToolStripMenuItem
            // 
            iniciaToolStripMenuItem.Name = "iniciaToolStripMenuItem";
            iniciaToolStripMenuItem.Size = new Size(173, 34);
            iniciaToolStripMenuItem.Text = "&Inicia";
            iniciaToolStripMenuItem.Click += iniciaToolStripMenuItem_Click;
            // 
            // rearmaToolStripMenuItem
            // 
            rearmaToolStripMenuItem.Enabled = false;
            rearmaToolStripMenuItem.Name = "rearmaToolStripMenuItem";
            rearmaToolStripMenuItem.Size = new Size(173, 34);
            rearmaToolStripMenuItem.Text = "&Rearma";
            rearmaToolStripMenuItem.Click += rearmaToolStripMenuItem_Click;
            // 
            // gravidadeToolStripMenuItem
            // 
            gravidadeToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { terraToolStripMenuItem, marteToolStripMenuItem, luaToolStripMenuItem });
            gravidadeToolStripMenuItem.Name = "gravidadeToolStripMenuItem";
            gravidadeToolStripMenuItem.Size = new Size(108, 29);
            gravidadeToolStripMenuItem.Text = "&Gravidade";
            // 
            // terraToolStripMenuItem
            // 
            terraToolStripMenuItem.Checked = true;
            terraToolStripMenuItem.CheckState = CheckState.Checked;
            terraToolStripMenuItem.Name = "terraToolStripMenuItem";
            terraToolStripMenuItem.Size = new Size(160, 34);
            terraToolStripMenuItem.Text = "&Terra";
            terraToolStripMenuItem.Click += terraToolStripMenuItem_Click;
            // 
            // marteToolStripMenuItem
            // 
            marteToolStripMenuItem.Name = "marteToolStripMenuItem";
            marteToolStripMenuItem.Size = new Size(160, 34);
            marteToolStripMenuItem.Text = "&Marte";
            marteToolStripMenuItem.Click += marteToolStripMenuItem_Click;
            // 
            // luaToolStripMenuItem
            // 
            luaToolStripMenuItem.Name = "luaToolStripMenuItem";
            luaToolStripMenuItem.Size = new Size(160, 34);
            luaToolStripMenuItem.Text = "&Lua";
            luaToolStripMenuItem.Click += luaToolStripMenuItem_Click;
            // 
            // trackBar1
            // 
            trackBar1.LargeChange = 10;
            trackBar1.Location = new Point(12, 71);
            trackBar1.Maximum = 85;
            trackBar1.Minimum = 5;
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(298, 69);
            trackBar1.SmallChange = 5;
            trackBar1.TabIndex = 1;
            trackBar1.TickFrequency = 5;
            trackBar1.Value = 5;
            trackBar1.ValueChanged += trackBar1_ValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 43);
            label1.Name = "label1";
            label1.Size = new Size(177, 25);
            label1.TabIndex = 2;
            label1.Text = "Ângulo de inclinação";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(787, 313);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ScrollBars = ScrollBars.Vertical;
            textBox1.Size = new Size(441, 628);
            textBox1.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(787, 285);
            label2.Name = "label2";
            label2.Size = new Size(74, 25);
            label2.TabIndex = 4;
            label2.Text = "Eventos";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(334, 73);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(109, 31);
            textBox2.TabIndex = 5;
            textBox2.Text = " 5 º";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1258, 968);
            Controls.Add(textBox2);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(trackBar1);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem arquivoToolStripMenuItem;
        private ToolStripMenuItem sairToolStripMenuItem;
        private ToolStripMenuItem simulaçãoToolStripMenuItem;
        private ToolStripMenuItem iniciaToolStripMenuItem;
        private ToolStripMenuItem rearmaToolStripMenuItem;
        private ToolStripMenuItem gravidadeToolStripMenuItem;
        private ToolStripMenuItem terraToolStripMenuItem;
        private ToolStripMenuItem marteToolStripMenuItem;
        private ToolStripMenuItem luaToolStripMenuItem;
        private TrackBar trackBar1;
        private Label label1;
        private TextBox textBox1;
        private Label label2;
        private TextBox textBox2;
    }
}
