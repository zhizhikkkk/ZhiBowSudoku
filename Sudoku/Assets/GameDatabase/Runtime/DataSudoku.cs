
using UnityEngine;

public class DataSudoku
{
    public DataSudoku()
    {
        m_Grid = new Cell[Row,Column];
    }

    public const int Row = 9;
    public const int Column = 9;

    private Cell[,] m_Grid;

    public Cell[,] Create()
    {
        for (int x = 0; x < Row; x++)
        {
            for (int y = 0; y < Column; y++)
            {
                m_Grid[x, y].number = Random.Range(8, 10);
                Debug.Log(m_Grid[x, y].number);
            }
        }
        return m_Grid;
    }
}


