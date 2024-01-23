using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_PB
{
    enum CellTypes { fagocyt, fotocyt };

    internal class CellDNA_Basic
    {
        float digestRate; //szybkość trawienia pokarmu przez komórkę
        float divideLevel; //pozion najedzenia komórki potrzebny do podziału
        public Color CellColor { get; set; } //kolor komórki
        double rotDivide1; //obrót potomka 1 po podziale
        double rotDivide2; //obrót potomka 2 po podziale
        public int cellType { get; set; } //rodzaj pokarmu
        public int Offspring1 { get; set; } //indeks generacji potomka 1
        public int Offspring2 { get; set; } //indeks generacji potomka 2
        public bool MakeConnection { get; set; } //czy ma tworzyć połączenie pomiędzy potomkami
        public bool MakeConnection1 { get; set; } //czy potomek 1 ma utrzymywać stare połączenia
        public bool MakeConnection2 { get; set; } //czy potomek 2 ma utrzymywać stare połączenia

        //konstruktory
        public CellDNA_Basic(float digestRate, float divideLevel, Color cellColor, double rotDivide1, double rotDivide2, int cellType, int offspring1, int offspring2, bool makeConnection, bool makeConnection1, bool makeConnection2)
        {
            setDigestRate(digestRate);
            setDivideLevel(divideLevel);
            this.CellColor = cellColor;
            setRot1(rotDivide1);
            setRot2(rotDivide2);

            this.cellType = cellType;
            Offspring1 = offspring1;
            Offspring2 = offspring2;
            MakeConnection = makeConnection;
            MakeConnection1 = makeConnection1;
            MakeConnection2 = makeConnection2;
        }


        //metody
        public CellDNA_Basic getCopy()
        {
            return new CellDNA_Basic(DigestRate, DivideLevel, CellColor, rotDivide1, rotDivide2, cellType, Offspring1, Offspring2, MakeConnection, MakeConnection1, MakeConnection2);
        }


        //metody prywatne
        private void setDigestRate(float value)
        {
            if (value < 0.0f)
                this.digestRate = 0.0f;
            else
                this.digestRate = value;
        }

        private void setDivideLevel(float value)
        {
            if (value < 0.0f)
                this.divideLevel = 0.0f;
            else
                this.divideLevel = value;
        }

        private void setRot1(double value)
        {
            rotDivide1 = value;

            while (rotDivide1 < 0)
                rotDivide1 += Math.PI * 2;

            while (rotDivide1 > Math.PI * 2)
                this.rotDivide1 -= Math.PI * 2;
        }

        private void setRot2(double value)
        {
            rotDivide2 = value;

            while (rotDivide2 < 0)
                rotDivide2 += Math.PI * 2;

            while (rotDivide2 > Math.PI * 2)
                this.rotDivide2 -= Math.PI * 2;
        }

        //getery i setery
        public float DigestRate
        {
            get
            {
                return digestRate;
            }
            set
            {
                setDigestRate(value);
            }
        }

        public float DivideLevel
        {
            get
            {
                return divideLevel;
            }
            set
            {
                setDivideLevel(value);
            }
        }

        public double RotDivide1
        {
            get
            {
                return rotDivide1;
            }
            set
            {
                setRot1(value);
            }
        }

        public double RotDivide2
        {
            get
            {
                return rotDivide2;
            }
            set
            {
                setRot2(value);
            }
        }
    }

    internal class ConnectedCellsList
    {
        private List<Cell> cells; //lista przyłączonych komórek
        private List<double> pos; //lista pozycji (wyrażonych w kątach) przyłączonych komórek

        public ConnectedCellsList()
        {
            cells = new List<Cell>();
            pos = new List<double>();
        }

        public void Add(Cell cell, double posRot)
        {
            cells.Add(cell);
            pos.Add(setRot(posRot));
        }

        public void Add(Tuple<Cell, double> cell)
        {
            cells.Add(cell.Item1);
            pos.Add(setRot(cell.Item2));
        }

        public void Remove(Cell cell)
        {
            pos.RemoveAt(cells.IndexOf(cell));
            cells.Remove(cell);
        }

        public void RemoveAt(int index)
        {
            cells.RemoveAt(index);
            pos.RemoveAt(index);
        }

        public void Clear()
        {
            cells.Clear();
            pos.Clear();
        }

        public Tuple<Cell, double> GetCell(int index)
        {
            return new Tuple<Cell, double>(cells[index], pos[index]);
        }

        public int GetCount()
        {
            return cells.Count;
        }


        private double setRot(double value)
        {
            while (value < 0)
                value += Math.PI * 2;

            while (value > Math.PI * 2)
                value -= Math.PI * 2;

            return value;
        }
    }

    internal class Cell
    {
        static private uint globalID = 0;

        public uint id { get; } //indeks komórki
        public Point2D position { get; set; } //pozycja komórki
        public Point2D velocity { get; set; } //wektor prędkości komórki
        double rot; //obrót komórki (UWAGA! nie zależy od wektora prędkości)
        double rotOmega { get; set; } //predkość kątowa komórki
        public float foodLevel { get; set; } //poziom najedzenia komórki
        public ConnectedCellsList connectedCells { get; } //komórki połączone z tą komórką

        public CellDNA_Basic[] DNA { get; } //DNA komórki
        public int gen { get; } //indeks generacji do której należy komórka (UWAGA! wyższa generacja nie oznacza młodszej komórki.)


        //konstuktory
        public Cell()
        {
            position = new Point2D();
            velocity = new Point2D();
            Rot = 0;
            foodLevel = 50;
            connectedCells = new ConnectedCellsList();

            DNA = new CellDNA_Basic[1];
            DNA[0] = new CellDNA_Basic(0.1f, 80f, Color.LightGreen, -10f, 20f, (int)CellTypes.fagocyt, 0, 0, false, false, false);
            gen = 0;

            id = globalID;
            globalID++;
        }

        public Cell(float posx, float posy)
        {
            position = new Point2D(posx, posy);
            velocity = new Point2D();
            Rot = 0;
            foodLevel = 50;
            connectedCells = new ConnectedCellsList();

            DNA = new CellDNA_Basic[1];
            DNA[0] = new CellDNA_Basic(0.1f, 80f, Color.LightGreen, -15f, 45f, (int)CellTypes.fagocyt, 0, 0, false, false, false);
            gen = 0;

            id = globalID;
            globalID++;
        }
        public Cell(float posx, float posy, CellDNA_Basic[] cellDNA, int generation)
        {
            position = new Point2D(posx, posy);
            velocity = new Point2D();
            Rot = 0;
            foodLevel = 50;
            connectedCells = new ConnectedCellsList();

            DNA = new CellDNA_Basic[cellDNA.Length];
            for (int i = 0; i < DNA.Length; i++)
                DNA[i] = cellDNA[i].getCopy();
            gen = generation;

            id = globalID;
            globalID++;
        }
        public Cell(Point2D pos, CellDNA_Basic[] cellDNA, int generation)
        {
            position = new Point2D(pos);
            velocity = new Point2D();
            Rot = 0;
            foodLevel = 50;
            connectedCells = new ConnectedCellsList();

            DNA = new CellDNA_Basic[cellDNA.Length];
            for (int i = 0; i < DNA.Length; i++)
                DNA[i] = cellDNA[i].getCopy();
            gen = generation;

            id = globalID;
            globalID++;
        }
        public Cell(float posx, float posy, float vx, float vy, double rot, float food_stored, CellDNA_Basic[] cellDNA, int generation)
        {
            position = new Point2D(posx, posy);
            velocity = new Point2D(vx, vy);
            Rot = rot;
            foodLevel = food_stored;
            connectedCells = new ConnectedCellsList();

            DNA = new CellDNA_Basic[cellDNA.Length];
            for (int i = 0; i < DNA.Length; i++)
                DNA[i] = cellDNA[i].getCopy();
            gen = generation;

            id = globalID;
            globalID++;
        }
        public Cell(Point2D pos, Point2D vel, double rot, float food_stored, CellDNA_Basic[] cellDNA, int generation)
        {
            position = new Point2D(pos);
            velocity = new Point2D(vel);
            Rot = rot;
            foodLevel = food_stored;
            connectedCells = new ConnectedCellsList();

            DNA = new CellDNA_Basic[cellDNA.Length];
            for (int i = 0; i < DNA.Length; i++)
                DNA[i] = cellDNA[i].getCopy();
            gen = generation;

            id = globalID;
            globalID++;
        }
        public Cell(float posx, float posy, float vx, float vy, double rot, float food_stored, ConnectedCellsList connectedCellsList, CellDNA_Basic[] cellDNA, int generation)
        {
            position = new Point2D(posx, posy);
            velocity = new Point2D(vx, vy);
            Rot = rot;
            foodLevel = food_stored;
            connectedCells = new ConnectedCellsList();

            for (int i = 0; i < connectedCellsList.GetCount(); i++)
                connectedCells.Add(connectedCellsList.GetCell(i));

            DNA = new CellDNA_Basic[cellDNA.Length];
            for (int i = 0; i < DNA.Length; i++)
                DNA[i] = cellDNA[i].getCopy();
            gen = generation;

            id = globalID;
            globalID++;
        }
        public Cell(Point2D pos, Point2D vel, double rot, float food_stored, ConnectedCellsList connectedCellsList, CellDNA_Basic[] cellDNA, int generation)
        {
            position = new Point2D(pos);
            velocity = new Point2D(vel);
            Rot = rot;
            foodLevel = food_stored;
            connectedCells = new ConnectedCellsList();

            for (int i = 0; i < connectedCellsList.GetCount(); i++)
                connectedCells.Add(connectedCellsList.GetCell(i));

            DNA = new CellDNA_Basic[cellDNA.Length];
            for (int i = 0; i < DNA.Length; i++)
                DNA[i] = cellDNA[i].getCopy();
            gen = generation;

            id = globalID;
            globalID++;
        }


        //metody
        public bool CellPos(float x, float y) //zwraca true, gdy punkt znajduje sie w obrębie komórki
        {
            if (position.VectorLength2(x, y) < Radius*Radius)
                return true;
            else
                return false;
        }

        public float AddFood(float ammount) //dodaje jedzenie do komorki, gdy komórka osiągnie najedzenie na poziomie 100, nie przyjmie więcej jedzenia. Funkcja zwraca (lol) ilość nadmiarowego pożywienia zjedzonego przez przez komórkę
        {
            foodLevel += ammount;

            if (foodLevel > 100)
            {
                float addiotional_food = foodLevel - 100;
                foodLevel = 100;
                return addiotional_food;
            }
            else
                return 0;
        }

        public void UpdatePosition() //uaktualnia pozycję w zależności od wektora prędkości
        {
            position.x += velocity.x;
            position.y += velocity.y;
        }

        public void UpdateRot() //uaktualnia kierunek obrotu komórki
        {
            Rot += rotOmega;
            rotOmega /= 20;
        }

        public void AddForce(float x, float y) //działa na komórkę wektorem siły
        {
            velocity.x += x / (foodLevel+10);
            velocity.y += y / (foodLevel+10);
        }

        public void AddForce(Point2D p) //działa na komórkę wektorem siły
        {
            velocity.x += p.x / (foodLevel+10);
            velocity.y += p.y / (foodLevel+10);
        }

        public void Digest() //trawi pokarm w komórce
        {
            foodLevel -= DNA[gen].DigestRate;
        }

        public Tuple<Cell, Cell> CreateNewCell() //dzieli komórkę
        {
            float food_tmp = foodLevel / 2;

            Point2D posShift = new Point2D(1, 0);
            posShift.RotateVector(Rot);

            ConnectedCellsList ccl1 = new ConnectedCellsList();
            ConnectedCellsList ccl2 = new ConnectedCellsList();

            for (int i = 0; i < connectedCells.GetCount(); i++)
            {
                Tuple<Cell, double> conCell = connectedCells.GetCell(i);

                if (DNA[gen].MakeConnection1)
                    if (!(conCell.Item2 > Math.PI * 5 / 3 || conCell.Item2 < Math.PI / 3)) //jeżeli połączona komórka nie znajduje się po stronie +/- 60 st. komórki macierzystej zachowuj połączenia dla potomka 1 (w teori powinno być dla potomka 2, ale coś pomieszłem z kolejnoscią, który jest 1, a który 2)
                        ccl1.Add(conCell.Item1, conCell.Item2 - DNA[gen].RotDivide1);

                if (DNA[gen].MakeConnection2)
                    if (!(conCell.Item2 > Math.PI * 2 / 3 && conCell.Item2 < Math.PI * 4 / 3)) //jeżeli połączona komórka nie znajduje się po stronie +/- 120 st. komórki macierzystej zachowuj połączenia dla potomka 2
                        ccl2.Add(conCell.Item1, conCell.Item2 - DNA[gen].RotDivide2);

                conCell.Item1.connectedCells.Remove(this);
            }


            Cell newCell1 = new Cell(position.x + posShift.x, position.y + posShift.y, this.velocity.x, this.velocity.y, Rot + DNA[gen].RotDivide1, foodLevel - food_tmp, ccl1, DNA, DNA[gen].Offspring1);
            Cell newCell2 = new Cell(position.x - posShift.x, position.y - posShift.y, this.velocity.x, this.velocity.y, Rot + DNA[gen].RotDivide2, food_tmp, ccl2, DNA, DNA[gen].Offspring2);


            for (int i = 0; i < newCell1.connectedCells.GetCount(); i++)
            {
                Tuple<Cell, double> conCell = newCell1.connectedCells.GetCell(i);
                conCell.Item1.connectedCells.Add(newCell1, conCell.Item2 + Math.PI);
            }

            for (int i = 0; i < newCell2.connectedCells.GetCount(); i++)
            {
                Tuple<Cell, double> conCell = newCell2.connectedCells.GetCell(i);
                conCell.Item1.connectedCells.Add(newCell2, conCell.Item2 + Math.PI);
            }

            if (CellDNA.MakeConnection)
            {
                newCell1.connectedCells.Add(newCell2, 0 - DNA[gen].RotDivide1);
                newCell2.connectedCells.Add(newCell1, Math.PI - DNA[gen].RotDivide2);
            }

            return new Tuple<Cell, Cell>(newCell1, newCell2);
        }

        public void UpdateStatus() //uaktualnia stan komórki (pozycję i poziom najedzenia)
        {
            UpdatePosition();
            UpdateRot();
            Digest();
        }

        public void ConnectedCellsInteraction()
        {
            for (int i = 0; i < connectedCells.GetCount(); i++)
            {
                Tuple<Cell, double> conCell = connectedCells.GetCell(i);

                //przyciąganie się komórek
                float distance = (float)this.position.VectorLength2(conCell.Item1.position);
                float cellsRadius = (this.Radius + conCell.Item1.Radius) * (this.Radius + conCell.Item1.Radius);

                if (distance > cellsRadius)
                {
                    float Fx = 0.01f * (this.position.x - conCell.Item1.position.x);
                    float Fy = 0.01f * (this.position.y - conCell.Item1.position.y);

                    Fx *= distance - cellsRadius;
                    Fy *= distance - cellsRadius;

                    if (Fx > 100)
                        Fx = 100;
                    if (Fy > 100)
                        Fy = 100;

                    if (Fx < -100)
                        Fx = -100;
                    if (Fy < -100)
                        Fy = -100;

                    this.AddForce(-Fx, -Fy);
                }

                //przesunięcie komórek jak nie leżą w odpowiedniej pozycji
                //Point2D conCellPos = conCell.Item1.position;
                //Point2D conCellPosTarget = new Point2D(1, 0);
                //conCellPosTarget.RotateVector(Rot + conCell.Item2);
                //Point2D forceVector = new Point2D(conCellPosTarget.x + position.x - conCellPos.x, conCellPosTarget.y + position.y - conCellPos.y);
                ////forceVector /= 2;

                //this.AddForce(forceVector);

                //obrót komórek
                //double roDebug = Point2D.Angle(conCellPos - position, conCellPosTarget);
                ////Console.WriteLine("id: {0}\tidCon: {1}\t roDebug: {2}", id, conCell.Item1.id, roDebug);
                //rotOmega += roDebug;
                float foodDiff = conCell.Item1.foodLevel - this.foodLevel;
                conCell.Item1.AddFood(this.AddFood(conCell.Item1.AddFood(-foodDiff/50) + foodDiff/50));
            }
        }


        //getery i setery
        public double Rot
        {
            get
            {
                return rot;
            }
            set
            {
                rot = value;

                while (rot < 0)
                    rot += Math.PI * 2;

                while (rot > Math.PI * 2)
                    rot -= Math.PI * 2;
            }
        }

        public float Radius //zwraca promien komorki
        {
            get
            {
                return (10 + foodLevel / 10)/2;
            }
        }

        public float DivideLevel
        {
            get
            {
                return DNA[gen].DivideLevel;
            }
        }

        public CellDNA_Basic CellDNA
        {
            get
            {
                return DNA[gen];
            }
        }
    }
}
