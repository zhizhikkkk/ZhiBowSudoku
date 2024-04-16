using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckSudokuGrid : MonoBehaviour
{
    Cell[,] grid ;

    void Start()
    {
        DataSudoku dataSudoku = new DataSudoku();  
        grid = dataSudoku.CustomGridForTest();  
        dataSudoku.PrintGrid();
        if (CheckGrid())
            Debug.Log("а ты хорош");
        else
            Debug.Log("ну ты бездарь");
    }

    bool CheckGrid()
    {
        for (int i = 0; i <9; i++)
        {
            if (!CheckRow(i) || !CheckColumn(i))
                return false;
        }

        for (int row = 0; row < 9; row += 3)
        {
            for (int col = 0; col < 9; col += 3)
            {
                if (!CheckBox(row, col))
                    return false;
            }
        }

        return true;
    }
    bool CheckBox(int startRow, int startCol)
    {
        HashSet<int> numbers = new HashSet<int>();
        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                int number = grid[startRow + row, startCol + col].number;
                if (number != 0 && numbers.Contains(number))
                {
                    Debug.Log($"Ошибка в блоке начинающемся в строке {startRow + 1}, столбце {startCol + 1}: число {number} в строке {startRow + row + 1}, столбце {startCol + col + 1} повторяется.");
                    return false;
                }
                numbers.Add(number);
            }
        }
        return true;
    }
    bool CheckRow(int row)
    {
        HashSet<int> numbers = new HashSet<int>();
        for (int col = 0; col < 9; col++)
        {
            int number = grid[row, col].number;
            if (number != 0)
            {
                if (number !=0 && numbers.Contains(number))
                {
                    Debug.Log($"Ошибка в строке {row + 1},столбце {col+1}:  число {number} повторяется.");
                    
                    return false;
                }
                numbers.Add(number);
            }
        }
        return true;
    }
    bool CheckColumn(int col)
    {
        HashSet<int> numbers = new HashSet<int>();
        for (int row = 0; row < 9; row++)
        {
            int number = grid[row, col].number;
            if (number != 0)
            {
                if (number != 0 &&  numbers.Contains(number))
                {
                    Debug.Log($"Ошибка в столбце {col + 1},в строке {row + 1}: число {number} повторяется.");
                    return false;
                }
                numbers.Add(number);
            }
        }
        return true;
    }
}
