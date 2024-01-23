using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_PB
{
    internal class SimCore
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public List<Cell> cellList { get; } //lista wszystkich komórek
        public HashSet<Food> foodList { get; } //lista cząsteczek pożywienia

        public float Viscosity { get; set; } //lepokość otoczenia
        public bool Light { get; set; } //światło on/off

        
        private Random random = new Random();
        private HashSet<Cell>[,] proximityCells; //lsita komórek w danym fragmencie symulacji (optymalizacja)
        private int chunkSize = 20;

        //konstruktor
        public SimCore(int width, int height)
        {
            Width = width;
            Height = height;

            cellList = new List<Cell>();
            foodList = new HashSet<Food>();

            makeProximityCellMap();

            Viscosity = 10;
        }

        //główna funkcja
        public void update() //krok symualcji
        {
            for (int i = 0; i < ((1 + Width / 200) * (1 + Height / 200)); i++)
                foodList.Add(new Food(random.Next(Width + 1), random.Next(Height + 1), (float)((random.NextDouble() * 10.0) + 5.0)));

            //spożycie pokarmu przez komórki
            HashSet<Food> foodToRemove = new HashSet<Food>();

            foreach (Food food in foodList)
            {
                food.Decay();

                if (food.ammount <= 0)
                {
                    foodToRemove.Add(food);
                    continue;
                }

                Food emptyFood = FoodCellInteractionMakro(food);
                if (emptyFood != null)
                    foodToRemove.Add(emptyFood);
            }

            foreach (Food food in foodToRemove)
                foodList.Remove(food);

            foreach (Cell cell in cellList)
            {
                CellCellInteractionMakro(cell);
                cell.ConnectedCellsInteraction();
            }

            //ruch komórek i inne
            for (int i =0; i < cellList.Count; i++)
            {
                Cell cell = cellList[i];

                //Dodoaje jedzenie do komórek żywiących się światłem
                if (Light && cell.CellDNA.cellType == (int)CellTypes.fotocyt && cell.position.y < 200)
                    cell.AddFood(5f / cell.position.y);

                //siła tarcia o otoczenie działająca na komórki
                cell.AddForce(-cellList[i].velocity.x * Viscosity, -cell.velocity.y * Viscosity);

                //aktualizacja statusu komóki (położenia i poziomu najedzenia (foodLevel))
                cell.UpdateStatus();

                //śmierć komórki, gdy zabraknie pożywienia
                if (cell.foodLevel <= 0)
                {
                    for (int  j = 0; j < cell.connectedCells.GetCount(); j++)
                        cell.connectedCells.GetCell(j).Item1.connectedCells.Remove(cell);

                    cellList.RemoveAt(i);
                    i--;
                    continue;
                }

                checkIfCellIsInside(cell);


                //podział komórki po osiągnięciu odpowiedniego stopnia najedzenia
                if (cell.foodLevel > cell.DivideLevel)
                {
                    Tuple<Cell, Cell> newCells = cell.CreateNewCell();
                    cellList.RemoveAt(i);
                    i--;
                    cellList.Add(newCells.Item1);
                    cellList.Add(newCells.Item2);
                }
            }

            makeProximityCellMap();
        }


        //inne funkcje
        public void changeSize(int width, int height) //Zmienia rozmiar symulacji
        {
            Width = width;
            Height = height;

            HashSet<Food> foodToRemove = new HashSet<Food>();

            foreach (Food food in foodList)
            {
                if (food.x > Width || food.y > Height)
                    foodToRemove.Add(food);
            }

            foreach (Food food in foodToRemove)
                foodList.Remove(food);


            foreach (Cell cell in cellList)
                checkIfCellIsInside(cell);

            makeProximityCellMap();
        }

        public void reset() //Resetuje symulację
        {
            cellList.Clear();
            foodList.Clear();
        }

        private void makeProximityCellMap() //Przydziela komórki do odpowiedniej części mapy (optymalizacja)
        {
            proximityCells = new HashSet<Cell>[Width / chunkSize + 1, Height / chunkSize + 1];

            for (int i = 0; i < Width / chunkSize + 1; i++)
                for (int j = 0; j < Height / chunkSize + 1; j++)
                    proximityCells[i, j] = new HashSet<Cell>();

            foreach (Cell cell in cellList)
            {
                int chunkX = (int)cell.position.x / chunkSize;
                int chunkY = (int)cell.position.y / chunkSize;

                if (chunkX < 0)
                    chunkX = 0;
                else if (chunkX > Width / chunkSize)
                    chunkX = Width / chunkSize;

                if (chunkY < 0)
                    chunkY = 0;
                else if (chunkY > Height / chunkSize)
                    chunkY = Height / chunkSize;

                proximityCells[chunkX, chunkY].Add(cell);
            }
        }

        private void checkIfCellIsInside(Cell cell) //Sprawdza, czy komórka nie wyszła poza obszar symulacji
        {
            if (cell.position.x < cell.Radius)
            {
                cell.position.x = cell.Radius;
                cell.velocity.x *= -1;
            }

            if (cell.position.y < cell.Radius)
            {
                cell.position.y = cell.Radius;
                cell.velocity.y *= -1;
            }

            if (cell.position.x > Width - cell.Radius)
            {
                cell.position.x = Width - cell.Radius;
                cell.velocity.x *= -1;
            }

            if (cell.position.y > Height - cell.Radius)
            {
                cell.position.y = Height - cell.Radius;
                cell.velocity.y *= -1;
            }
        }

        private Food FoodCellInteractionMikro(Food food, Cell cell) //Powoduje, że komórka zjada jedzenie
        {
            if (cell.CellDNA.cellType == (int)CellTypes.fagocyt && cell.CellPos(food.x, food.y))
            {
                food.ammount = cell.AddFood(food.ammount);

                if (food.ammount <= 0)
                {
                    return food;
                }
            }

            return null;
        }
        private Food FoodCellInteractionMakro(Food food) //Sprawdza pobliskie komórki, które mogą jeść jedzenie
        {
            int[] proximityMapPos = { food.x / chunkSize, food.y / chunkSize };
            Food emptyFood;

            foreach (Cell cell in proximityCells[proximityMapPos[0], proximityMapPos[1]])
            {
                emptyFood = FoodCellInteractionMikro(food, cell);
                if (emptyFood != null)
                    return emptyFood;
            }

            if (proximityMapPos[0] > 0)
            {
                foreach (Cell cell in proximityCells[proximityMapPos[0] - 1, proximityMapPos[1]])
                {
                    emptyFood = FoodCellInteractionMikro(food, cell);
                    if (emptyFood != null)
                        return emptyFood;
                }

                if (proximityMapPos[1] > 0)
                {
                    foreach (Cell cell in proximityCells[proximityMapPos[0] - 1, proximityMapPos[1] - 1])
                    {
                        emptyFood = FoodCellInteractionMikro(food, cell);
                        if (emptyFood != null)
                            return emptyFood;
                    }
                }

                if (proximityMapPos[1] < Height / chunkSize)
                {
                    foreach (Cell cell in proximityCells[proximityMapPos[0] - 1, proximityMapPos[1] + 1])
                    {
                        emptyFood = FoodCellInteractionMikro(food, cell);
                        if (emptyFood != null)
                            return emptyFood;
                    }
                }
            }

            if (proximityMapPos[0] < Width / chunkSize)
            {
                foreach (Cell cell in proximityCells[proximityMapPos[0] + 1, proximityMapPos[1]])
                {
                    emptyFood = FoodCellInteractionMikro(food, cell);
                    if (emptyFood != null)
                        return emptyFood;
                }

                if (proximityMapPos[1] > 0)
                {
                    foreach (Cell cell in proximityCells[proximityMapPos[0] + 1, proximityMapPos[1] - 1])
                    {
                        emptyFood = FoodCellInteractionMikro(food, cell);
                        if (emptyFood != null)
                            return emptyFood;
                    }
                }

                if (proximityMapPos[1] < Height / chunkSize)
                {
                    foreach (Cell cell in proximityCells[proximityMapPos[0] + 1, proximityMapPos[1] + 1])
                    {
                        emptyFood = FoodCellInteractionMikro(food, cell);
                        if (emptyFood != null)
                            return emptyFood;
                    }
                }
            }

            if (proximityMapPos[1] > 0)
            {
                foreach (Cell cell in proximityCells[proximityMapPos[0], proximityMapPos[1] - 1])
                {
                    emptyFood = FoodCellInteractionMikro(food, cell);
                    if (emptyFood != null)
                        return emptyFood;
                }
            }

            if (proximityMapPos[1] < Height / chunkSize)
            {
                foreach (Cell cell in proximityCells[proximityMapPos[0], proximityMapPos[1] + 1])
                {
                    emptyFood = FoodCellInteractionMikro(food, cell);
                    if (emptyFood != null)
                        return emptyFood;
                }
            }

            return null;
        }

        private void CellCellInteractionMikro(Cell cell1, Cell cell2) //Odpychanie dwóch komórek od siebie, jeżeli są zbyt blisko
        {
            float distance = (float)cell1.position.VectorLength2(cell2.position);

            if (distance < (cell1.Radius + cell2.Radius) * (cell1.Radius + cell2.Radius))
            {
                float Fx = 100 * (cell1.position.x - cell2.position.x);
                float Fy = 100 * (cell1.position.y - cell2.position.y);

                if (distance != 0)
                {
                    Fx /= distance;
                    Fy /= distance;
                }
                else
                {
                    Fx += 1;
                    Fy += 1;
                }

                if (Fx > 100)
                    Fx = 100;
                if (Fy > 100)
                    Fy = 100;

                if (Fx < -100)
                    Fx = -100;
                if (Fy < -100)
                    Fy = -100;

                cell1.AddForce(Fx, Fy);
                cell2.AddForce(-Fx, -Fy);

            }
        }
        private void CellCellInteractionMakro(Cell cell) //Sprawdza, czy pobliskie komórki nie są zbyt blisko
        {
            int[] proximityMapPos = { (int)cell.position.x / chunkSize, (int)cell.position.y / chunkSize };

            if (proximityMapPos[0] < 0)
                proximityMapPos[0] = 0;
            else if (proximityMapPos[0] > Width / chunkSize)
                proximityMapPos[0] = Width / chunkSize;

            if (proximityMapPos[1] < 0)
                proximityMapPos[1] = 0;
            else if (proximityMapPos[1] > Height / chunkSize)
                proximityMapPos[1] = Height / chunkSize;

            foreach (Cell proxiCell in proximityCells[proximityMapPos[0], proximityMapPos[1]])
            {
                if(proxiCell.Equals(cell))
                    continue;

                CellCellInteractionMikro(cell, proxiCell);
            }

            if (proximityMapPos[0] > 0)
            {
                foreach (Cell proxiCell in proximityCells[proximityMapPos[0] - 1, proximityMapPos[1]])
                {
                    if (proxiCell.Equals(cell))
                        continue;

                    CellCellInteractionMikro(cell, proxiCell);
                }

                if (proximityMapPos[1] > 0)
                {
                    foreach (Cell proxiCell in proximityCells[proximityMapPos[0] - 1, proximityMapPos[1] - 1])
                    {
                        if (proxiCell.Equals(cell))
                            continue;

                        CellCellInteractionMikro(cell, proxiCell);
                    }
                }

                if (proximityMapPos[1] < Height / chunkSize)
                {
                    foreach (Cell proxiCell in proximityCells[proximityMapPos[0] - 1, proximityMapPos[1] + 1])
                    {
                        if (proxiCell.Equals(cell))
                            continue;

                        CellCellInteractionMikro(cell, proxiCell);
                    }
                }
            }

            if (proximityMapPos[0] < Width / chunkSize)
            {
                foreach (Cell proxiCell in proximityCells[proximityMapPos[0] + 1, proximityMapPos[1]])
                {
                    if (proxiCell.Equals(cell))
                        continue;

                    CellCellInteractionMikro(cell, proxiCell);
                }

                if (proximityMapPos[1] > 0)
                {
                    foreach (Cell proxiCell in proximityCells[proximityMapPos[0] + 1, proximityMapPos[1] - 1])
                    {
                        if (proxiCell.Equals(cell))
                            continue;

                        CellCellInteractionMikro(cell, proxiCell);
                    }
                }

                if (proximityMapPos[1] < Height / chunkSize)
                {
                    foreach (Cell proxiCell in proximityCells[proximityMapPos[0] + 1, proximityMapPos[1] + 1])
                    {
                        if (proxiCell.Equals(cell))
                            continue;

                        CellCellInteractionMikro(cell, proxiCell);
                    }
                }
            }

            if (proximityMapPos[1] > 0)
            {
                foreach (Cell proxiCell in proximityCells[proximityMapPos[0], proximityMapPos[1] - 1])
                {
                    if (proxiCell.Equals(cell))
                        continue;

                    CellCellInteractionMikro(cell, proxiCell);
                }
            }

            if (proximityMapPos[1] < Height / chunkSize)
            {
                foreach (Cell proxiCell in proximityCells[proximityMapPos[0], proximityMapPos[1] + 1])
                {
                    if (proxiCell.Equals(cell))
                        continue;

                    CellCellInteractionMikro(cell, proxiCell);
                }
            }
        }

    }

}
