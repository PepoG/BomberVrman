using System;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

/*



OOOOOOO
O.O.O.O
OP.O.OO
O B.O.O
OOOOOOO



*/

public class LevelGenerator : MonoBehaviour
{
    public GameObject destructibleBlockPrefab;
    public GameObject indestructibleBlockPrefab;
    public GameObject playerPrefab;
    public GameObject player2Prefab;
    public GameObject bombPrefab;
    public GameObject tablePrefab;

    private float cellSize = 1.0f;
    [TextArea(10, 15)]
    public string levelString = @"
OOOOOOOOOOOOOOOOOOOOOOO
O.....................O
O.O.O.O.O.O.O.O.O.O.O.O
O.....................O
O.O.O.O.O.O.O.O.O.O.O.O
O.....................O
O.O.O.O.O.O.O.O.O.O.O.O
O.....................O
O.O.O.O.O.O.O.O.O.O.O.O
O.....................O
OBO.O.O.O.O.O.O.O.O.O.O
O P...................O
OOOOOOOOOOOOOOOOOOOOOOO
";

    void Start()
    {
        GenerateLevel();
    }

    void GenerateLevel()
    {
        var rows = levelString.Split(Environment.NewLine).Where(p => p.Length > 0).ToArray();

        var height = rows.Length;
        var width = rows[0].Length;

        for (int y = 0; y < height; y++)
        {
            string row = rows[y];
            for (int x = 0; x < width; x++)
            {
                if (row.Length > width) {
                    Debug.LogWarning("Row " + row + " has wrong column count.");
                }
                char cell = row[x];
                var position = transform.position + new Vector3(x * cellSize, 0, -y * cellSize);

                if (cell == 'P')
                {
                    Instantiate(playerPrefab, position, Quaternion.identity, transform);
                }
                else if (cell == 'Q')
                {
                    Instantiate(player2Prefab, position, Quaternion.identity, transform);
                }
                else if (cell == ' ')
                {
                    // empty
                }
                else if (cell == 'O')
                {
                    Instantiate(indestructibleBlockPrefab, position, Quaternion.identity, transform);
                }
                else if (cell == '.')
                {
                    Instantiate(destructibleBlockPrefab, position, Quaternion.identity, transform);
                }
                else if (cell == 'B')
                {
                    Instantiate(bombPrefab, position, Quaternion.identity, transform);
                }
                else
                {
                    Debug.Log("Unknown block '" + cell + "'");
                }
            }
        }

        var tableGo = Instantiate(tablePrefab, Vector3.zero, Quaternion.identity, transform);
        tableGo.transform.localScale = new Vector3(width, 0.1f, height);
        tableGo.transform.localPosition = new Vector3((width - 1) / 2, -0.5f, (height - 1) / -2);
    }
}