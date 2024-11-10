using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    public GameObject floorPrefab;    // Prefab para el suelo
    public GameObject wallPrefab;     // Prefab para la pared
    public GameObject playerPrefab;   // Prefab para el jugador
    public GameObject boxPrefab;
    public GameObject smallRobot;     // Robot que atraviesa lásers
    public GameObject lasersPrefab;   // Prefab de lásers

    private int width;
    private int height;

    void Start()
    {
        GenerateGridFromTxt("MapLayout");  // Nombre del archivo sin la extensión
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            RegenerateGrid();
        }
    }

    void RegenerateGrid()
    {
        // Elimina todos los objetos hijos de este objeto (los objetos de la cuadrícula)
        foreach (Transform child in transform) //quenta la grid como hijos y obtiene el transform de estos
        {
            Destroy(child.gameObject);
            
        }

        // Vuelve a generar la cuadrícula
        GenerateGridFromTxt("MapLayout");

    }

    void GenerateGridFromTxt(string fileName)
    {
        TextAsset txtFile = Resources.Load<TextAsset>(fileName);
        if (txtFile == null)
        {
            Debug.LogError("Archivo de texto no encontrado en Resources");
            return;
        }

        string[] lines = txtFile.text.Split(new[] { "\n", "\r\n" }, System.StringSplitOptions.RemoveEmptyEntries);
        height = lines.Length;
        width = lines[0].Split(' ').Length;

        for (int y = 0; y < height; y++)
        {
            string[] row = lines[y].Trim().Split(' '); // Elimina espacios adicionales al principio y al final de cada línea
            for (int x = 0; x < width; x++)
            {
                Vector3 position = new Vector3(x, -y, 0); // Ajusta -y para invertir la cuadrícula
                CreateObject(row[x], position);
            }
        }
    }

    void CreateObject(string tileType, Vector3 position)
    {
        GameObject objToInstantiate = null;

        switch (tileType)
        {
            case "0":
                objToInstantiate = floorPrefab;
                break;
            case "1":
                objToInstantiate = wallPrefab;
                break;
            case "P":
                Instantiate(floorPrefab, position, Quaternion.identity, transform);
                objToInstantiate = playerPrefab;
                break;
            case "S":
                Instantiate(floorPrefab, position, Quaternion.identity, transform);
                objToInstantiate = smallRobot;
                break;
            case "B":
                Instantiate(floorPrefab, position, Quaternion.identity, transform);
                objToInstantiate = boxPrefab;
                break;
            case "L":
                Instantiate(floorPrefab, position, Quaternion.identity, transform);
                objToInstantiate = lasersPrefab;
                break;
            default:
                Debug.LogWarning("Tipo de celda no reconocido: " + tileType);
                return;
        }

        if (objToInstantiate != null)
        {
            Instantiate(objToInstantiate, position, Quaternion.identity, transform);
        }
    }
}
