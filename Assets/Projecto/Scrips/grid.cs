using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public int width = 5;  // Ancho de la cuadrícula
    public int height = 5; // Altura de la cuadrícula
    public GameObject cellPrefab; // Prefab de celda (puedes usar un simple cuadrado)

    private GameObject[,] grid; // Matriz para almacenar las celdas

    void Start()
    {
        CreateGrid();
    }
    
    void CreateGrid()
    {
        grid = new GameObject[width, height];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Vector3 position = new Vector3(x, y, 0); // Calcula la posición de cada celda
                GameObject cell = Instantiate(cellPrefab, position, Quaternion.identity);
                cell.transform.parent = this.transform; // Haz que las celdas sean hijas del GridManager
                grid[x, y] = cell; // Guarda la referencia a la celda
            }
        }
    }
   

    // Método opcional para obtener una celda en función de su posición
    public GameObject GetCell(int x, int y)
    {
        if (x >= 0 && x < width && y >= 0 && y < height)
        {
            return grid[x, y];
        }
        return null;
    }
}