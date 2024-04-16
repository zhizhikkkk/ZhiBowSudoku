using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGrid : MonoBehaviour
{
    void Start()
    {
        Cell[,] grid = new DataSudoku().Create();
    }


}
