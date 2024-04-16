using Bow;
using TMPro;
using UnityEngine;

public class TestGrid : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI m_Prefab;

    void Start()
    {
        SudokuGenerator sudoku = new SudokuGenerator();
        sudoku.complexity = Complexity.Easy;//Сложность игры
        sudoku.Create();//Создание сетки

        sudoku.GetOriginGrid();//Массив, всей заполненной таблицы
        sudoku.CheckCell((4, 4), new Cell());//сравнивание установленной цифры
        sudoku.CheckFinish( new Cell[9,9]);//проверка всей таблицы. Для проверки конца игры
        Cell[,] grid = sudoku.GetModifiedGrid();// Получение сетки с нулями
        
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
