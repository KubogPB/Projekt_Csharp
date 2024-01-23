using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekt_PB
{
    public partial class MainWindow : Form
    {
        private enum ClickMode { add,  remove, select };
        private int mode = (int) ClickMode.add;
        CellDNA_Basic selectedDNA;

        public MainWindow()
        {
            InitializeComponent();
            ReloadButtonsIcons();
            MainScene.UpdateSize(this.Width - 216 - MainScene.Left, this.Height - 39 - MainScene.Top);
            comboBox_init();
            textBox_Podzial.Text = selectedDNA.DivideLevel.ToString();
        }

        private void GameTick(object sender, EventArgs e)
        {
            MainScene.UpdateSimulation();
            MainScene.Redraw();
        }

        private void SizeChanged_MainWindow(object sender, EventArgs e)
        {
            checkBox_Light.Left = this.Width - 281;
            if(checkBox_Light.Left < 150)
                checkBox_Light.Left = 150;

            button_Reset.Left = this.Width - 332;
            if (button_Reset.Left < 99)
                button_Reset.Left = 99;

            groupBox_CellDNA.Left = this.Width - 216;
            groupBox_CellDNA.Height = this.Height - 39;

            MainScene.UpdateSize(this.Width - 216 - MainScene.Left, this.Height - 39 - MainScene.Top);
            //Console.WriteLine("Width: {0}\tHeight: {1}", this.Width - 216 - MainScene.Left, this.Height - 39 - MainScene.Top);
        }

        private void ReloadButtonsIcons()
        {
            if (mode == (int)ClickMode.add)
                ButtonAdd.Image = global::Projekt_PB.Properties.Resources.Add_icon;
            else
                ButtonAdd.Image = global::Projekt_PB.Properties.Resources.Add_icon_notselect;

            if (mode == (int)ClickMode.remove)
                ButtonRemove.Image = global::Projekt_PB.Properties.Resources.Remove_icon;
            else
                ButtonRemove.Image = global::Projekt_PB.Properties.Resources.Remove_icon_notselect;

            if (mode == (int)ClickMode.select)
                ButtonSelect.Image = global::Projekt_PB.Properties.Resources.Select_icon;
            else
                ButtonSelect.Image = global::Projekt_PB.Properties.Resources.Select_icon_notselect;
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            mode = (int) ClickMode.add;
            ReloadButtonsIcons();
        }

        private void ButtonRemove_Click(object sender, EventArgs e)
        {
            mode = (int) ClickMode.remove;
            ReloadButtonsIcons();
        }

        private void ButtonSelect_Click(object sender, EventArgs e)
        {
            mode = (int) ClickMode.select;
            ReloadButtonsIcons();
        }

        private void MainScene_Click(object sender, MouseEventArgs e)
        {
            switch(mode)
            {
                case (int)ClickMode.add:
                    MainScene.AddCell(e.X, e.Y);
                    break;

                case (int)ClickMode.remove:
                    MainScene.RemoveCell(e.X, e.Y);
                    break;

                case (int)ClickMode.select:
                    int gen = MainScene.SelectCell(e.X, e.Y);

                    if(gen >= 0)
                        comboBox1_GenerationSelect.SelectedIndex = gen;

                    break;
            }
        }

        private void checkBox_Light_Change(object sender, EventArgs e)
        {
            MainScene.SetLight(checkBox_Light.Checked);
        }

        private void comboBox_init()
        {
            for (int i = 0; i < MainScene.DNA_Array.Length; i++)
            {
                string item = String.Format("Generation {0}", i+1);
                comboBox1_GenerationSelect.Items.Add(item);
                comboBox_Offspring1.Items.Add(item);
                comboBox_Offspring2.Items.Add(item);
            }

            comboBox1_GenerationSelect.SelectedIndex = 0;
            comboBox_Offspring1.SelectedIndex = 0;
            comboBox_Offspring2.SelectedIndex = 0;

            comboBox_CellType.Items.Add("Fagocyt");
            comboBox_CellType.Items.Add("Fotocyt");
            comboBox_CellType.SelectedIndex = 0;
        }

        private void comboBox_GS_Changed(object sender, EventArgs e)
        {
            selectedDNA = MainScene.DNA_Array[comboBox1_GenerationSelect.SelectedIndex];

            textBox_Color_R.Text = selectedDNA.CellColor.R.ToString();
            textBox_Color_G.Text = selectedDNA.CellColor.G.ToString();
            textBox_Color_B.Text = selectedDNA.CellColor.B.ToString();

            panel_Color.BackColor = selectedDNA.CellColor;

            comboBox_Offspring1.SelectedIndex = selectedDNA.Offspring1;
            comboBox_Offspring2.SelectedIndex = selectedDNA.Offspring2;

            textBox_Offspring1_rot.Text = selectedDNA.RotDivide1.ToString();
            textBox_Offspring2_rot.Text = selectedDNA.RotDivide2.ToString();

            textBox_Podzial.Text = selectedDNA.DivideLevel.ToString();

            checkBox_Connect.Checked = selectedDNA.MakeConnection;
            checkBox_Offspring1_Conn.Checked = selectedDNA.MakeConnection1;
            checkBox_Offspring2_Conn.Checked = selectedDNA.MakeConnection2;
        }

        private void textBox_Color_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    int r = int.Parse(textBox_Color_R.Text);
                    int g = int.Parse(textBox_Color_G.Text);
                    int b = int.Parse(textBox_Color_B.Text);

                    selectedDNA.CellColor = Color.FromArgb(r, g, b);
                    panel_Color.BackColor = selectedDNA.CellColor;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                textBox_Color_R.Text = selectedDNA.CellColor.R.ToString();
                textBox_Color_G.Text = selectedDNA.CellColor.G.ToString();
                textBox_Color_B.Text = selectedDNA.CellColor.B.ToString();
            }
        }

        private void tB_Of1_rot_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    selectedDNA.RotDivide1 = float.Parse(textBox_Offspring1_rot.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
                textBox_Offspring1_rot.Text = selectedDNA.RotDivide1.ToString();
            }
        }

        private void tB_Os2_rot_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    selectedDNA.RotDivide2 = float.Parse(textBox_Offspring2_rot.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
                textBox_Offspring2_rot.Text = selectedDNA.RotDivide2.ToString();
            }
        }

        private void comboBox_Os1_Changed(object sender, EventArgs e)
        {
            selectedDNA.Offspring1 = comboBox_Offspring1.SelectedIndex;
        }

        private void comboBox_Os2_Changed(object sender, EventArgs e)
        {
            selectedDNA.Offspring2 = comboBox_Offspring2.SelectedIndex;
        }

        private void ButtonReset_Click(object sender, EventArgs e)
        {
            MainScene.ResetSimulation();
        }

        private void comboBox_CType_Change(object sender, EventArgs e)
        {
            selectedDNA.cellType = comboBox_CellType.SelectedIndex;
        }

        private void textBox_Podzial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    selectedDNA.DivideLevel = float.Parse(textBox_Podzial.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                textBox_Podzial.Text = selectedDNA.DivideLevel.ToString();
            }
        }

        private void checkBox_Connect_Changed(object sender, EventArgs e)
        {
            selectedDNA.MakeConnection = checkBox_Connect.Checked;
        }

        private void checkBox_OS1_Change(object sender, EventArgs e)
        {
            selectedDNA.MakeConnection1 = checkBox_Offspring1_Conn.Checked;
        }

        private void checkBox_OS2_Change(object sender, EventArgs e)
        {
            selectedDNA.MakeConnection2 = checkBox_Offspring2_Conn.Checked;
        }
    }
}
