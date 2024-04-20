

using System.Collections.Generic;

using UnityEngine;

namespace Bow
{

    public class SudokuGenerator
    {
        public SudokuGenerator()
        {
            m_Grid = new Cell[Row, Column];
            m_ModifiedGrid = new Cell[Row, Column];
            m_Zero = new Cell();
        }

        public Complexity complexity { get; set; } = Complexity.Easy;

        private const int Row = 9;
        private const int Column = 9;
        private readonly (int x, int y) m_Box = (3, 3);

        private Cell[,] m_Grid;
        private Cell[,] m_ModifiedGrid;
        private Cell m_Zero;
        private int[,] m_BaseGrid =
            {
            {2,3,8,1,5,9,4,6,7},
            {4,1,5,6,7,8,9,3,2},
            {9,7,6,3,2,4,8,5,1},
            {8,5,7,9,6,3,1,2,4},
            {3,2,9,7,4,1,6,8,5},
            {1,6,4,5,8,2,7,9,3},
            {5,9,3,8,1,7,2,4,6},
            {7,8,2,4,3,6,5,1,9},
            {6,4,1,2,9,5,3,7,8},
        };

        private int m_Number = 1;

        private int number
        {
            get => m_Number;
            set => m_Number = (value <= m_Box.x * m_Box.y) ? value : value - m_Box.x * m_Box.y;
        }

        public void Create()
        {
            for (int x = 0; x < Row; x++)
            {
                for (int y = 0; y < Column; y++)
                {
                    m_Grid[x, y].number = m_BaseGrid[x, y];
                }
            }
            for (int i = 0; i < Row * Column; i++)
            {
                SwapRows();
                SwapColumn();
                Randomize();
            }
            CreateInitialGrid();
        }

        private void GenerateDefault()
        {
            for (int x = 0; x < Row; x++)
            {
                for (int y = 0; y < Column; y++)
                {
                    m_Grid[x, y].number = number;
                    number++;
                }
                int div = x > 0 && (x + 1) % 3 == 0 ? 1 : 0;
                number += 3 + div;
            }
        }

        private void Randomize()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int[] select = new int[3];

            for (int i = 0; i < select.Length; i++)
            {
                int random = Random.Range(0, numbers.Count);
                select[i] = numbers[random];
                numbers.RemoveAt(random);
            }

            for (int x = 0; x < Row; x++)
            {
                for (int y = 0; y < Column; y++)
                {
                    int gridNumber = m_Grid[x, y].number;

                    if (gridNumber == select[0])
                    {
                        m_Grid[x, y].number = select[1];
                    }
                    else if (gridNumber == select[1])
                    {
                        m_Grid[x, y].number = select[2];
                    }
                    else if (gridNumber == select[2])
                    {
                        m_Grid[x, y].number = select[0];
                    }
                }
            }
        }

        public Cell[,] GetModifiedGrid() => (Cell[,])m_ModifiedGrid.Clone();

        public Cell[,] GetOriginGrid() => (Cell[,])m_Grid.Clone();

        public bool CheckCell((int x, int y) p, Cell cell)
        {
            return m_Grid[p.x, p.y].number == cell.number;
        }

        public bool CheckFinish(Cell[,] cell)
        {
            if (cell.GetLength(0) != Row) return false;
            if (cell.GetLength(1) != Column) return false;

            for (int x = 0; x < Row; x++)
            {
                for (int y = 0; y < Column; y++)
                {
                    if (m_Grid[x, y].number != cell[x, y].number) return false;
                }
            }
            return true;
        }

        private void SwapRows()
        {
            int[] columns = new int[2];
            int boxColumn = Random.Range(0, m_Box.y) * m_Box.y;
            columns[0] = boxColumn + Random.Range(0, m_Box.y);
            columns[1] = boxColumn + Random.Range(0, m_Box.y);

            for (int x = 0; x < m_Grid.GetLength(0); x++)
            {
                Cell cellSave = m_Grid[x, columns[0]];
                m_Grid[x, columns[0]] = m_Grid[x, columns[1]];
                m_Grid[x, columns[1]] = cellSave;
            }
        }

        private void SwapColumn()
        {
            int[] rows = new int[2];
            int boxRows = Random.Range(0, m_Box.x) * m_Box.x;
            rows[0] = boxRows + Random.Range(0, m_Box.x);
            rows[1] = boxRows + Random.Range(0, m_Box.x);

            for (int y = 0; y < m_Grid.GetLength(0); y++)
            {
                Cell cellSave = m_Grid[rows[0], y];
                m_Grid[rows[0], y] = m_Grid[rows[1], y];
                m_Grid[rows[1], y] = cellSave;
            }
        }

        private void CreateInitialGrid()
        {
            for (int x = 0; x < Row; x++)
            {
                for (int y = 0; y < Column; y++)
                {
                    m_ModifiedGrid[x, y] = randomModified ? m_Grid[x, y] : m_Zero;
                }
            }
        }

        private bool randomModified => Random.Range(0, (int)complexity + 1) == 0;
    }
}





