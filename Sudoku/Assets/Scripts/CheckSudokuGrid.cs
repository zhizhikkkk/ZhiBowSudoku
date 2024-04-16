using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckSudokuGrid : MonoBehaviour
{
    public int[,] sudokuGrid = new int[9, 9]
    {
        {0,0,0,1,1,0,0,0,0 },
        {0,0,0,0,0,0,0,0,0 },
        {0,0,0,0,0,0,0,0,0 },
        {0,0,0,0,0,0,0,0,0 },
        {0,0,0,0,0,0,0,0,0 },
        {0,0,0,0,0,0,0,0,0 },
        {0,0,0,0,0,0,0,0,0 },
        {0,0,0,0,0,0,0,0,0 },
        {0,0,0,0,0,0,0,0,0 }
    };


    void Start()
    {
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
        return true;
    }

    bool CheckRow(int row)
    {
        HashSet<int> numbers = new HashSet<int>();
        for (int col = 0; col < 9; col++)
        {
            int number = sudokuGrid[row, col];
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
            int number = sudokuGrid[row, col];
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
