using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekt_PB
{
    internal class SimScene : PictureBox //Klasa pośrednicząca pomiędzy użytkownikiem, a właściwą symulacją
    {
        private Bitmap buffer;
        private SimCore simuation;
        public CellDNA_Basic[] DNA_Array { get; } = new CellDNA_Basic[64];
        public int primiaryGeneration { get; set; }

        public SimScene()
        {
            buffer = new Bitmap(this.Width, this.Height);
            this.Image = buffer;

            simuation = new SimCore(Width, Height);

            for(int i = 0; i < DNA_Array.Length; i++)
                DNA_Array[i] = new CellDNA_Basic(0.1f, 80, Color.LightGreen, 0, 0, (int)CellTypes.fagocyt, i, i, false, true, true);

            primiaryGeneration = 0;
        }

        public void Redraw() //Rysowanie wyświetlanego obrazu
        {
            Graphics g = Graphics.FromImage(buffer);
            g.Clear(Color.FromArgb(200, 255, 230));

            foreach (Food food in simuation.foodList) //Rysowanie Pożywienia
            {
                Brush brush = new SolidBrush(Color.Brown);

                g.FillEllipse(brush, food.x - food.ammount / 5, food.y - food.ammount / 5, food.ammount * 2 / 5, food.ammount * 2 / 5);

                brush.Dispose();
            }

            for (int i = 0; i < simuation.cellList.Count; i++) //Rysowanie Komórek
            {
                Cell cell = simuation.cellList[i];
                Color cellColor = cell.CellDNA.CellColor;
                Pen pen = new Pen(Color.FromArgb(cellColor.R / 2, cellColor.G / 2, cellColor.B / 2), 2);
                Brush brush = new SolidBrush(cellColor);

                Point2D cellPos = cell.position;
                float cellRadius = cell.Radius;

                g.FillEllipse(brush, cellPos.x - cellRadius, cellPos.y - cellRadius, cellRadius*2, cellRadius*2);
                g.DrawEllipse(pen, cellPos.x - cellRadius, cellPos.y - cellRadius, cellRadius*2, cellRadius*2);
                brush.Dispose();
                brush = new SolidBrush(Color.FromArgb(cellColor.R / 2, cellColor.G / 2, cellColor.B / 2));
                g.FillEllipse(brush, cellPos.x - 2, cellPos.y - 2, 4, 4);

                pen.Dispose();
                pen = new Pen(Color.Black);

                for (int j = 0; j < cell.connectedCells.GetCount(); j++)
                {
                    g.DrawLine(pen, cell.position.x, cell.position.y, cell.connectedCells.GetCell(j).Item1.position.x, cell.connectedCells.GetCell(j).Item1.position.y);
                }

                //pen.Dispose();
                //pen = new Pen(Color.Red);

                //Point2D rotVec = new Point2D(10, 0);
                //rotVec.RotateVector(cell.Rot);

                //g.DrawLine(pen, cell.position.x, cell.position.y, rotVec.x + cell.position.x, rotVec.y + cell.position.y);

                pen.Dispose();
                brush.Dispose();
            }

            if (simuation.Light) //Rysowanie światła
            {
                for (int i = 0; i < 200; i++)
                {
                    if (i >= this.Height)
                        break;

                    Pen pen = new Pen(Color.FromArgb(200 - i, 255, 255, 100));
                    g.DrawLine(pen, 0, i, this.Width, i);
                    pen.Dispose();
                }
            }

            g.Dispose();
            this.Image = buffer;
        }

        public void UpdateSize(int width, int height) //Zmiana rozmiaru symualcji
        {
            if (width > 0 && height > 0)
            {
                this.Width = width;
                this.Height = height;
                buffer.Dispose();
                try
                {
                    buffer = new Bitmap(width, height);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Redraw();

                simuation.changeSize(width, height);
            }
        }

        public void AddCell(int x, int y) //Dodanie nowej komórki
        {
            simuation.cellList.Add(new Cell(x, y, DNA_Array, primiaryGeneration));
        }

        public void RemoveCell(int x, int y) //Usunięcie komórki
        {
            for (int i = 0; i < simuation.cellList.Count; i++)
            {
                if(simuation.cellList[i].CellPos(x, y))
                {
                    simuation.cellList.RemoveAt(i);
                    break;
                }
            }
        }

        public int SelectCell(int x, int y) //Wybranie komórki
        {
            Console.Write("xy: {0}, {1}\t", x, y);

            int gen = -1;

            for (int i = 0; i < simuation.cellList.Count; i++)
            {
                if (simuation.cellList[i].CellPos(x, y))
                {
                    Console.Write("Selected cell ID: {0}", simuation.cellList[i].id);
                    gen = simuation.cellList[i].gen;
                    break;
                }
            }

            Console.WriteLine();

            return gen;
        }

        public void UpdateSimulation() //Przejście do kolejnego kroku czasowego symulacji
        {
            simuation.update();
        }

        public void ResetSimulation()
        {
            simuation.reset();
        }

        public void SetLight(bool light)
        {
            simuation.Light = light;
        }
    }
}
