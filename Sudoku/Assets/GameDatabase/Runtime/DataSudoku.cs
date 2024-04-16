
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
                m_Grid[x, y].number = Random.Range(0, 10);
            }
        }
        return m_Grid;
    }

    public Cell[,] CustomGridForTest() {
        
        int[,] myNumbersBitch = {
            {0,1,0,0,0,0,0,0,0 },
            {0,0,1,0,0,0,0,0,0 },
            {0,0,0,0,0,0,0,0,0 },
            {0,0,0,0,0,0,0,0,0 },
            {0,0,0,0,0,0,0,0,0 },
            {0,0,0,0,0,0,0,0,0 },
            {0,0,0,0,0,0,0,0,0 },
            {0,0,0,0,0,0,0,0,0 },
            {0,0,0,0,0,0,0,0,0 }
        };

        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                m_Grid[i, j] = new Cell {
                    number = myNumbersBitch[i, j] 
                };
            }
        }

        return m_Grid;
    }


    public void PrintGrid()
    {
        string ans = "";
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {

                ans += m_Grid[i, j].number.ToString() + " ";
            }
            ans += "\n";
        }
        Debug.Log(ans);
    }
}


