using System.Runtime.CompilerServices;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    public GameObject destructibleBlockPrefab;
    public GameObject indestructibleBlockPrefab;
    public GameObject playerPrefab;

    private float cellSize = 1.0f;
    [Multiline]
    public string levelString =
        "OOOOOOO\n" +
        "O.O.O.O\n" +
        "OO.O.OO\n" +
        "O.O.O.O\n" +
        "OOOOOOO";

    void Start()
    {
        GenerateLevel();
    }

    void GenerateLevel()
    {
        string[] rows = levelString.Split('\n');
        for (int y = 0; y < rows.Length; y++)
        {
            string row = rows[y];
            for (int x = 0; x < row.Length; x++)
            {
                char cell = row[x];
                var position = transform.position + new Vector3(x * cellSize, 0, -y * cellSize);

                if (cell == 'P') {
                    Instantiate(playerPrefab, position, Quaternion.identity, transform);
                }
                else  if (cell == ' ')
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
                else {
                    Debug.Log("Unknown block" + cell);
                }
            }
        }
    }
}