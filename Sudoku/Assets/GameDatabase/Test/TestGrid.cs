using Bow;
using TMPro;
using UnityEngine;

public class TestGrid : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI m_Prefab;

    void Start()
    {
        SudokuGenerator sudoku = new SudokuGenerator();
        sudoku.complexity = Complexity.Easy;//��������� ����
        sudoku.Create();//�������� �����

        sudoku.GetOriginGrid();//������, ���� ����������� �������
        sudoku.CheckCell((4, 4), new Cell());//��������� ������������� �����
        sudoku.CheckFinish( new Cell[9,9]);//�������� ���� �������. ��� �������� ����� ����
        sudoku.GetModifiedGrid();// ��������� ����� � ������
        Cell[,] grid = sudoku.GetOriginGrid();


        for (int x = 0; x < grid.GetLength(0); x++)
        {
            for (int y = 0; y < grid.GetLength(0); y++)
            {
                TextMeshProUGUI textMesh = Instantiate(m_Prefab, new Vector2(x, y), Quaternion.identity, transform);
                textMesh.text = grid[x, y].number.ToString();
            }
        }
    }


}
