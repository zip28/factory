using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Matrix : MonoBehaviour
{
    public const int size = 1000;
    public static Matrix solo;
    public static List<Vector2Int> directions = new List<Vector2Int>() {new Vector2Int(0, 1), new Vector2Int(1, 0), new Vector2Int(0, -1), new Vector2Int(-1, 0) };
    public static int[,] type = new int[size, size];
    public static int[,] machine = new int[size,size];


}
