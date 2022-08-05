using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Matrix : MonoBehaviour
{
    public const int size = 1000;
    public static Matrix solo;
    public List<Vector2Int> directions = new List<Vector2Int>() {new Vector2Int(0, 1), new Vector2Int(1, 0), new Vector2Int(0, -1), new Vector2Int(-1, 0) };
    public int[,] type = new int[size, size];
    public int[,] machine = new int[size,size];
    private void Awake()
    {
        for (int i = 0; i < size; i++){
            for (int j = 0; j < size; j++)
            {
                type[i, j] = -1;
                machine[i, j] = -1;
            }
        }
    }
    

}
