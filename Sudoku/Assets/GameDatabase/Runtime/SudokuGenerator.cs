

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
                    m_Grid[x, y].number = number;
                    number++;
                }
                int div = x > 0 && (x + 1) % 3 == 0 ? 1 : 0;
                number += 3 + div;
            }
            for (int i = 0; i < Row * Column; i++)
            {
                SwapRows();
                SwapColumn();
            }
            CreateInitialGrid();
        }

        public Cell[,] GetModifiedGrid() => m_ModifiedGrid;

        public Cell[,] GetOriginGrid() => m_Grid;

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
                    if (m_Grid[x,y].number != cell[x,y].number) return false;
                }
            }
            return true;
        }

        private void SwapRows()
        {
            int[] columns = new int[2];
            columns[0] = Random.Range(0, Column);
            columns[1] = Random.Range(0, Column);

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
            rows[0] = Random.Range(0, Row);
            rows[1] = Random.Range(0, Row);

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





