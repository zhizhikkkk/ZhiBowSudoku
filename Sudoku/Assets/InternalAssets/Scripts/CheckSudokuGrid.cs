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
            Debug.Log("� �� �����");
        else
            Debug.Log("�� �� �������");
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
                    Debug.Log($"������ � ����� ������������ � ������ {startRow + 1}, ������� {startCol + 1}: ����� {number} � ������ {startRow + row + 1}, ������� {startCol + col + 1} �����������.");
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
                    Debug.Log($"������ � ������ {row + 1},������� {col+1}:  ����� {number} �����������.");
                    
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
                    Debug.Log($"������ � ������� {col + 1},� ������ {row + 1}: ����� {number} �����������.");
                    return false;
                }
                numbers.Add(number);
            }
        }
        return true;
    }
}
