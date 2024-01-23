namespace Projekt_PB
{
    partial class MainWindow
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.ButtonAdd = new System.Windows.Forms.ToolStripButton();
            this.ButtonRemove = new System.Windows.Forms.ToolStripButton();
            this.ButtonSelect = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.checkBox_Light = new System.Windows.Forms.CheckBox();
            this.groupBox_CellDNA = new System.Windows.Forms.GroupBox();
            this.textBox_Podzial = new System.Windows.Forms.TextBox();
            this.label_Podzial = new System.Windows.Forms.Label();
            this.comboBox_CellType = new System.Windows.Forms.ComboBox();
            this.label_CellType = new System.Windows.Forms.Label();
            this.groupBox_Offspring = new System.Windows.Forms.GroupBox();
            this.textBox_Offspring2_rot = new System.Windows.Forms.TextBox();
            this.label_Offspring2_rot = new System.Windows.Forms.Label();
            this.textBox_Offspring1_rot = new System.Windows.Forms.TextBox();
            this.label_Offspring1_rot = new System.Windows.Forms.Label();
            this.comboBox_Offspring2 = new System.Windows.Forms.ComboBox();
            this.comboBox_Offspring1 = new System.Windows.Forms.ComboBox();
            this.groupBox_Color = new System.Windows.Forms.GroupBox();
            this.textBox_Color_B = new System.Windows.Forms.TextBox();
            this.panel_Color = new System.Windows.Forms.Panel();
            this.label_Color_R = new System.Windows.Forms.Label();
            this.label_Color_G = new System.Windows.Forms.Label();
            this.textBox_Color_G = new System.Windows.Forms.TextBox();
            this.label_Color_B = new System.Windows.Forms.Label();
            this.textBox_Color_R = new System.Windows.Forms.TextBox();
            this.comboBox1_GenerationSelect = new System.Windows.Forms.ComboBox();
            this.button_Reset = new System.Windows.Forms.Button();
            this.checkBox_Connect = new System.Windows.Forms.CheckBox();
            this.label_Connect = new System.Windows.Forms.Label();
            this.MainScene = new Projekt_PB.SimScene();
            this.label_Offspring1_Conn = new System.Windows.Forms.Label();
            this.label_Offspring2_Conn = new System.Windows.Forms.Label();
            this.checkBox_Offspring1_Conn = new System.Windows.Forms.CheckBox();
            this.checkBox_Offspring2_Conn = new System.Windows.Forms.CheckBox();
            this.toolStrip1.SuspendLayout();
            this.groupBox_CellDNA.SuspendLayout();
            this.groupBox_Offspring.SuspendLayout();
            this.groupBox_Color.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainScene)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.GameTick);
            // 
            // ButtonAdd
            // 
            this.ButtonAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ButtonAdd.Image = global::Projekt_PB.Properties.Resources.Add_icon;
            this.ButtonAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonAdd.Name = "ButtonAdd";
            this.ButtonAdd.Size = new System.Drawing.Size(23, 22);
            this.ButtonAdd.Text = "Add cell";
            this.ButtonAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
            // 
            // ButtonRemove
            // 
            this.ButtonRemove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ButtonRemove.Image = global::Projekt_PB.Properties.Resources.Remove_icon;
            this.ButtonRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonRemove.Name = "ButtonRemove";
            this.ButtonRemove.Size = new System.Drawing.Size(23, 22);
            this.ButtonRemove.Text = "Remove cell";
            this.ButtonRemove.Click += new System.EventHandler(this.ButtonRemove_Click);
            // 
            // ButtonSelect
            // 
            this.ButtonSelect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ButtonSelect.Image = global::Projekt_PB.Properties.Resources.Select_icon;
            this.ButtonSelect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonSelect.Name = "ButtonSelect";
            this.ButtonSelect.Size = new System.Drawing.Size(23, 22);
            this.ButtonSelect.Text = "Select cell";
            this.ButtonSelect.Click += new System.EventHandler(this.ButtonSelect_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ButtonAdd,
            this.ButtonRemove,
            this.ButtonSelect});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // checkBox_Light
            // 
            this.checkBox_Light.AutoSize = true;
            this.checkBox_Light.Location = new System.Drawing.Point(535, 5);
            this.checkBox_Light.Name = "checkBox_Light";
            this.checkBox_Light.Size = new System.Drawing.Size(62, 17);
            this.checkBox_Light.TabIndex = 3;
            this.checkBox_Light.Text = "Światło";
            this.checkBox_Light.UseVisualStyleBackColor = true;
            this.checkBox_Light.CheckedChanged += new System.EventHandler(this.checkBox_Light_Change);
            // 
            // groupBox_CellDNA
            // 
            this.groupBox_CellDNA.Controls.Add(this.label_Connect);
            this.groupBox_CellDNA.Controls.Add(this.checkBox_Connect);
            this.groupBox_CellDNA.Controls.Add(this.textBox_Podzial);
            this.groupBox_CellDNA.Controls.Add(this.label_Podzial);
            this.groupBox_CellDNA.Controls.Add(this.comboBox_CellType);
            this.groupBox_CellDNA.Controls.Add(this.label_CellType);
            this.groupBox_CellDNA.Controls.Add(this.groupBox_Offspring);
            this.groupBox_CellDNA.Controls.Add(this.groupBox_Color);
            this.groupBox_CellDNA.Controls.Add(this.comboBox1_GenerationSelect);
            this.groupBox_CellDNA.Location = new System.Drawing.Point(600, 0);
            this.groupBox_CellDNA.Name = "groupBox_CellDNA";
            this.groupBox_CellDNA.Size = new System.Drawing.Size(200, 450);
            this.groupBox_CellDNA.TabIndex = 2;
            this.groupBox_CellDNA.TabStop = false;
            this.groupBox_CellDNA.Text = "Parametry komórek";
            // 
            // textBox_Podzial
            // 
            this.textBox_Podzial.Location = new System.Drawing.Point(61, 205);
            this.textBox_Podzial.Name = "textBox_Podzial";
            this.textBox_Podzial.Size = new System.Drawing.Size(133, 20);
            this.textBox_Podzial.TabIndex = 14;
            this.textBox_Podzial.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_Podzial_KeyDown);
            // 
            // label_Podzial
            // 
            this.label_Podzial.AutoSize = true;
            this.label_Podzial.Location = new System.Drawing.Point(7, 208);
            this.label_Podzial.Name = "label_Podzial";
            this.label_Podzial.Size = new System.Drawing.Size(46, 13);
            this.label_Podzial.TabIndex = 13;
            this.label_Podzial.Text = "Podział:";
            // 
            // comboBox_CellType
            // 
            this.comboBox_CellType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_CellType.FormattingEnabled = true;
            this.comboBox_CellType.Location = new System.Drawing.Point(61, 178);
            this.comboBox_CellType.Name = "comboBox_CellType";
            this.comboBox_CellType.Size = new System.Drawing.Size(133, 21);
            this.comboBox_CellType.TabIndex = 12;
            this.comboBox_CellType.SelectedIndexChanged += new System.EventHandler(this.comboBox_CType_Change);
            // 
            // label_CellType
            // 
            this.label_CellType.AutoSize = true;
            this.label_CellType.Location = new System.Drawing.Point(7, 181);
            this.label_CellType.Name = "label_CellType";
            this.label_CellType.Size = new System.Drawing.Size(28, 13);
            this.label_CellType.TabIndex = 11;
            this.label_CellType.Text = "Typ:";
            // 
            // groupBox_Offspring
            // 
            this.groupBox_Offspring.Controls.Add(this.checkBox_Offspring2_Conn);
            this.groupBox_Offspring.Controls.Add(this.checkBox_Offspring1_Conn);
            this.groupBox_Offspring.Controls.Add(this.label_Offspring2_Conn);
            this.groupBox_Offspring.Controls.Add(this.label_Offspring1_Conn);
            this.groupBox_Offspring.Controls.Add(this.textBox_Offspring2_rot);
            this.groupBox_Offspring.Controls.Add(this.label_Offspring2_rot);
            this.groupBox_Offspring.Controls.Add(this.textBox_Offspring1_rot);
            this.groupBox_Offspring.Controls.Add(this.label_Offspring1_rot);
            this.groupBox_Offspring.Controls.Add(this.comboBox_Offspring2);
            this.groupBox_Offspring.Controls.Add(this.comboBox_Offspring1);
            this.groupBox_Offspring.Location = new System.Drawing.Point(6, 251);
            this.groupBox_Offspring.Name = "groupBox_Offspring";
            this.groupBox_Offspring.Size = new System.Drawing.Size(188, 193);
            this.groupBox_Offspring.TabIndex = 10;
            this.groupBox_Offspring.TabStop = false;
            this.groupBox_Offspring.Text = "Potomstwo";
            // 
            // textBox_Offspring2_rot
            // 
            this.textBox_Offspring2_rot.Location = new System.Drawing.Point(65, 129);
            this.textBox_Offspring2_rot.Name = "textBox_Offspring2_rot";
            this.textBox_Offspring2_rot.Size = new System.Drawing.Size(117, 20);
            this.textBox_Offspring2_rot.TabIndex = 5;
            this.textBox_Offspring2_rot.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tB_Os2_rot_KeyDown);
            // 
            // label_Offspring2_rot
            // 
            this.label_Offspring2_rot.AutoSize = true;
            this.label_Offspring2_rot.Location = new System.Drawing.Point(7, 132);
            this.label_Offspring2_rot.Name = "label_Offspring2_rot";
            this.label_Offspring2_rot.Size = new System.Drawing.Size(52, 13);
            this.label_Offspring2_rot.TabIndex = 4;
            this.label_Offspring2_rot.Text = "Kierunek:";
            // 
            // textBox_Offspring1_rot
            // 
            this.textBox_Offspring1_rot.Location = new System.Drawing.Point(65, 45);
            this.textBox_Offspring1_rot.Name = "textBox_Offspring1_rot";
            this.textBox_Offspring1_rot.Size = new System.Drawing.Size(117, 20);
            this.textBox_Offspring1_rot.TabIndex = 3;
            this.textBox_Offspring1_rot.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tB_Of1_rot_KeyDown);
            // 
            // label_Offspring1_rot
            // 
            this.label_Offspring1_rot.AutoSize = true;
            this.label_Offspring1_rot.Location = new System.Drawing.Point(7, 48);
            this.label_Offspring1_rot.Name = "label_Offspring1_rot";
            this.label_Offspring1_rot.Size = new System.Drawing.Size(52, 13);
            this.label_Offspring1_rot.TabIndex = 2;
            this.label_Offspring1_rot.Text = "Kierunek:";
            // 
            // comboBox_Offspring2
            // 
            this.comboBox_Offspring2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Offspring2.FormattingEnabled = true;
            this.comboBox_Offspring2.Location = new System.Drawing.Point(7, 102);
            this.comboBox_Offspring2.Name = "comboBox_Offspring2";
            this.comboBox_Offspring2.Size = new System.Drawing.Size(177, 21);
            this.comboBox_Offspring2.TabIndex = 1;
            this.comboBox_Offspring2.SelectedIndexChanged += new System.EventHandler(this.comboBox_Os2_Changed);
            // 
            // comboBox_Offspring1
            // 
            this.comboBox_Offspring1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Offspring1.FormattingEnabled = true;
            this.comboBox_Offspring1.Location = new System.Drawing.Point(7, 20);
            this.comboBox_Offspring1.Name = "comboBox_Offspring1";
            this.comboBox_Offspring1.Size = new System.Drawing.Size(177, 21);
            this.comboBox_Offspring1.TabIndex = 0;
            this.comboBox_Offspring1.SelectedIndexChanged += new System.EventHandler(this.comboBox_Os1_Changed);
            // 
            // groupBox_Color
            // 
            this.groupBox_Color.Controls.Add(this.textBox_Color_B);
            this.groupBox_Color.Controls.Add(this.panel_Color);
            this.groupBox_Color.Controls.Add(this.label_Color_R);
            this.groupBox_Color.Controls.Add(this.label_Color_G);
            this.groupBox_Color.Controls.Add(this.textBox_Color_G);
            this.groupBox_Color.Controls.Add(this.label_Color_B);
            this.groupBox_Color.Controls.Add(this.textBox_Color_R);
            this.groupBox_Color.Location = new System.Drawing.Point(6, 71);
            this.groupBox_Color.Name = "groupBox_Color";
            this.groupBox_Color.Size = new System.Drawing.Size(188, 100);
            this.groupBox_Color.TabIndex = 9;
            this.groupBox_Color.TabStop = false;
            this.groupBox_Color.Text = "Kolor";
            // 
            // textBox_Color_B
            // 
            this.textBox_Color_B.Location = new System.Drawing.Point(27, 74);
            this.textBox_Color_B.Name = "textBox_Color_B";
            this.textBox_Color_B.Size = new System.Drawing.Size(100, 20);
            this.textBox_Color_B.TabIndex = 7;
            this.textBox_Color_B.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_Color_KeyDown);
            // 
            // panel_Color
            // 
            this.panel_Color.BackColor = System.Drawing.Color.LightGreen;
            this.panel_Color.Location = new System.Drawing.Point(132, 33);
            this.panel_Color.Name = "panel_Color";
            this.panel_Color.Size = new System.Drawing.Size(50, 50);
            this.panel_Color.TabIndex = 8;
            // 
            // label_Color_R
            // 
            this.label_Color_R.AutoSize = true;
            this.label_Color_R.Location = new System.Drawing.Point(3, 25);
            this.label_Color_R.Name = "label_Color_R";
            this.label_Color_R.Size = new System.Drawing.Size(18, 13);
            this.label_Color_R.TabIndex = 2;
            this.label_Color_R.Text = "R:";
            // 
            // label_Color_G
            // 
            this.label_Color_G.AutoSize = true;
            this.label_Color_G.Location = new System.Drawing.Point(4, 51);
            this.label_Color_G.Name = "label_Color_G";
            this.label_Color_G.Size = new System.Drawing.Size(18, 13);
            this.label_Color_G.TabIndex = 3;
            this.label_Color_G.Text = "G:";
            // 
            // textBox_Color_G
            // 
            this.textBox_Color_G.Location = new System.Drawing.Point(27, 48);
            this.textBox_Color_G.Name = "textBox_Color_G";
            this.textBox_Color_G.Size = new System.Drawing.Size(100, 20);
            this.textBox_Color_G.TabIndex = 6;
            this.textBox_Color_G.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_Color_KeyDown);
            // 
            // label_Color_B
            // 
            this.label_Color_B.AutoSize = true;
            this.label_Color_B.Location = new System.Drawing.Point(4, 77);
            this.label_Color_B.Name = "label_Color_B";
            this.label_Color_B.Size = new System.Drawing.Size(17, 13);
            this.label_Color_B.TabIndex = 4;
            this.label_Color_B.Text = "B:";
            // 
            // textBox_Color_R
            // 
            this.textBox_Color_R.Location = new System.Drawing.Point(27, 22);
            this.textBox_Color_R.Name = "textBox_Color_R";
            this.textBox_Color_R.Size = new System.Drawing.Size(100, 20);
            this.textBox_Color_R.TabIndex = 5;
            this.textBox_Color_R.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_Color_KeyDown);
            // 
            // comboBox1_GenerationSelect
            // 
            this.comboBox1_GenerationSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1_GenerationSelect.FormattingEnabled = true;
            this.comboBox1_GenerationSelect.Location = new System.Drawing.Point(6, 44);
            this.comboBox1_GenerationSelect.Name = "comboBox1_GenerationSelect";
            this.comboBox1_GenerationSelect.Size = new System.Drawing.Size(188, 21);
            this.comboBox1_GenerationSelect.TabIndex = 0;
            this.comboBox1_GenerationSelect.SelectedIndexChanged += new System.EventHandler(this.comboBox_GS_Changed);
            // 
            // button_Reset
            // 
            this.button_Reset.Location = new System.Drawing.Point(484, 1);
            this.button_Reset.Name = "button_Reset";
            this.button_Reset.Size = new System.Drawing.Size(45, 23);
            this.button_Reset.TabIndex = 4;
            this.button_Reset.Text = "Reset";
            this.button_Reset.UseVisualStyleBackColor = true;
            this.button_Reset.Click += new System.EventHandler(this.ButtonReset_Click);
            // 
            // checkBox_Connect
            // 
            this.checkBox_Connect.AutoSize = true;
            this.checkBox_Connect.Location = new System.Drawing.Point(108, 231);
            this.checkBox_Connect.Name = "checkBox_Connect";
            this.checkBox_Connect.Size = new System.Drawing.Size(15, 14);
            this.checkBox_Connect.TabIndex = 15;
            this.checkBox_Connect.UseVisualStyleBackColor = true;
            this.checkBox_Connect.CheckedChanged += new System.EventHandler(this.checkBox_Connect_Changed);
            // 
            // label_Connect
            // 
            this.label_Connect.AutoSize = true;
            this.label_Connect.Location = new System.Drawing.Point(7, 231);
            this.label_Connect.Name = "label_Connect";
            this.label_Connect.Size = new System.Drawing.Size(95, 13);
            this.label_Connect.TabIndex = 16;
            this.label_Connect.Text = "Twórz połaczenie:";
            // 
            // MainScene
            // 
            this.MainScene.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(255)))), ((int)(((byte)(230)))));
            this.MainScene.Image = ((System.Drawing.Image)(resources.GetObject("MainScene.Image")));
            this.MainScene.Location = new System.Drawing.Point(0, 25);
            this.MainScene.Name = "MainScene";
            this.MainScene.primiaryGeneration = 0;
            this.MainScene.Size = new System.Drawing.Size(600, 425);
            this.MainScene.TabIndex = 2;
            this.MainScene.TabStop = false;
            this.MainScene.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MainScene_Click);
            // 
            // label_Offspring1_Conn
            // 
            this.label_Offspring1_Conn.AutoSize = true;
            this.label_Offspring1_Conn.Location = new System.Drawing.Point(7, 74);
            this.label_Offspring1_Conn.Name = "label_Offspring1_Conn";
            this.label_Offspring1_Conn.Size = new System.Drawing.Size(113, 13);
            this.label_Offspring1_Conn.TabIndex = 6;
            this.label_Offspring1_Conn.Text = "Zachowaj połączenie:";
            // 
            // label_Offspring2_Conn
            // 
            this.label_Offspring2_Conn.AutoSize = true;
            this.label_Offspring2_Conn.Location = new System.Drawing.Point(7, 158);
            this.label_Offspring2_Conn.Name = "label_Offspring2_Conn";
            this.label_Offspring2_Conn.Size = new System.Drawing.Size(113, 13);
            this.label_Offspring2_Conn.TabIndex = 7;
            this.label_Offspring2_Conn.Text = "Zachowaj połączenie:";
            // 
            // checkBox_Offspring1_Conn
            // 
            this.checkBox_Offspring1_Conn.AutoSize = true;
            this.checkBox_Offspring1_Conn.Location = new System.Drawing.Point(126, 74);
            this.checkBox_Offspring1_Conn.Name = "checkBox_Offspring1_Conn";
            this.checkBox_Offspring1_Conn.Size = new System.Drawing.Size(15, 14);
            this.checkBox_Offspring1_Conn.TabIndex = 8;
            this.checkBox_Offspring1_Conn.UseVisualStyleBackColor = true;
            this.checkBox_Offspring1_Conn.CheckedChanged += new System.EventHandler(this.checkBox_OS1_Change);
            // 
            // checkBox_Offspring2_Conn
            // 
            this.checkBox_Offspring2_Conn.AutoSize = true;
            this.checkBox_Offspring2_Conn.Location = new System.Drawing.Point(126, 157);
            this.checkBox_Offspring2_Conn.Name = "checkBox_Offspring2_Conn";
            this.checkBox_Offspring2_Conn.Size = new System.Drawing.Size(15, 14);
            this.checkBox_Offspring2_Conn.TabIndex = 9;
            this.checkBox_Offspring2_Conn.UseVisualStyleBackColor = true;
            this.checkBox_Offspring2_Conn.CheckedChanged += new System.EventHandler(this.checkBox_OS2_Change);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button_Reset);
            this.Controls.Add(this.checkBox_Light);
            this.Controls.Add(this.groupBox_CellDNA);
            this.Controls.Add(this.MainScene);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainWindow";
            this.Text = "CellSim";
            this.SizeChanged += new System.EventHandler(this.SizeChanged_MainWindow);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox_CellDNA.ResumeLayout(false);
            this.groupBox_CellDNA.PerformLayout();
            this.groupBox_Offspring.ResumeLayout(false);
            this.groupBox_Offspring.PerformLayout();
            this.groupBox_Color.ResumeLayout(false);
            this.groupBox_Color.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainScene)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private SimScene MainScene;
        private System.Windows.Forms.ToolStripButton ButtonAdd;
        private System.Windows.Forms.ToolStripButton ButtonRemove;
        private System.Windows.Forms.ToolStripButton ButtonSelect;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.CheckBox checkBox_Light;
        private System.Windows.Forms.GroupBox groupBox_CellDNA;
        private System.Windows.Forms.ComboBox comboBox1_GenerationSelect;
        private System.Windows.Forms.Label label_Color_B;
        private System.Windows.Forms.Label label_Color_G;
        private System.Windows.Forms.Label label_Color_R;
        private System.Windows.Forms.TextBox textBox_Color_B;
        private System.Windows.Forms.TextBox textBox_Color_G;
        private System.Windows.Forms.TextBox textBox_Color_R;
        private System.Windows.Forms.Panel panel_Color;
        private System.Windows.Forms.GroupBox groupBox_Color;
        private System.Windows.Forms.GroupBox groupBox_Offspring;
        private System.Windows.Forms.ComboBox comboBox_Offspring2;
        private System.Windows.Forms.ComboBox comboBox_Offspring1;
        private System.Windows.Forms.Label label_Offspring1_rot;
        private System.Windows.Forms.TextBox textBox_Offspring1_rot;
        private System.Windows.Forms.TextBox textBox_Offspring2_rot;
        private System.Windows.Forms.Label label_Offspring2_rot;
        private System.Windows.Forms.Button button_Reset;
        private System.Windows.Forms.ComboBox comboBox_CellType;
        private System.Windows.Forms.Label label_CellType;
        private System.Windows.Forms.Label label_Podzial;
        private System.Windows.Forms.TextBox textBox_Podzial;
        private System.Windows.Forms.Label label_Connect;
        private System.Windows.Forms.CheckBox checkBox_Connect;
        private System.Windows.Forms.Label label_Offspring1_Conn;
        private System.Windows.Forms.CheckBox checkBox_Offspring2_Conn;
        private System.Windows.Forms.CheckBox checkBox_Offspring1_Conn;
        private System.Windows.Forms.Label label_Offspring2_Conn;
    }
}

