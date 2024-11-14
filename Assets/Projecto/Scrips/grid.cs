using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    public GameObject floorPrefab;    // Prefab para el suelo
    public GameObject wallPrefab;     // Prefab para la pared
    public GameObject playerPrefab;   // Prefab para el jugador
    public GameObject boxPrefab;
    public GameObject boxRobot;
    public GameObject smallRobot;     // Robot que atraviesa lásers
    public GameObject explosiveRobot;
    public GameObject cloneRobot;
    public GameObject laserRobot;
    public GameObject lasersPrefab;   // Prefab de lásers
    public GameObject doorPrefab;
    public GameObject plasmaPrefab;
    public GameObject explosivePlaquePrefab;
    public GameObject panelPrefab;
    public GameObject wallPanelPrefab;

    //private Movement movement;

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
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        // Vuelve a generar la cuadrícula
        GenerateGridFromTxt("MapLayout");

        Hackeo.hasActiveObject = false;
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
            case "V":
                Instantiate(floorPrefab, position, Quaternion.identity, transform);
                objToInstantiate = boxRobot;
                break;
            case "S":
                Instantiate(floorPrefab, position, Quaternion.identity, transform);
                objToInstantiate = smallRobot;
                break;
            case "E":
                Instantiate(floorPrefab, position, Quaternion.identity, transform);
                objToInstantiate = explosiveRobot;
                break;
            case "C":
                Instantiate(floorPrefab, position, Quaternion.identity, transform);
                objToInstantiate = cloneRobot;
                break;
            case "R":
                Instantiate(floorPrefab, position, Quaternion.identity, transform);
                objToInstantiate = laserRobot;
                break;
            case "B":
                Instantiate(floorPrefab, position, Quaternion.identity, transform);
                objToInstantiate = boxPrefab;
                break;
            case "L":
                Instantiate(floorPrefab, position, Quaternion.identity, transform);
                objToInstantiate = lasersPrefab;
                break;
            case "D":
                Instantiate(floorPrefab, position, Quaternion.identity, transform);
                objToInstantiate = doorPrefab;
                break;
            case "T":
                Instantiate(floorPrefab, position, Quaternion.identity, transform);
                objToInstantiate = plasmaPrefab;
                break;
            case "X":
                Instantiate(floorPrefab, position, Quaternion.identity, transform);
                objToInstantiate = explosivePlaquePrefab;
                break;
            case "O":
                Instantiate(floorPrefab, position, Quaternion.identity, transform);
                objToInstantiate = panelPrefab;
                break;
            case "W":
                Instantiate(wallPrefab, position, Quaternion.identity, transform);
                objToInstantiate = wallPanelPrefab;
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

