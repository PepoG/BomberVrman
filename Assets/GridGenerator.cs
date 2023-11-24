using System.Runtime.CompilerServices;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    public GameObject destructibleBlockPrefab;
    public GameObject indestructibleBlockPrefab;

    private float cellSize = 1.0f;
    [Multiline]
    public string levelString =
        ".0.0.\n" +
        "0.0.0\n" +
        ".0.0.\n";

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
                var position = new Vector3(x * cellSize, 0, -y * cellSize);

                if (cell != ' ')
                {
                    // empty
                }
                else if (cell == 'O')
                {
                    Instantiate(indestructibleBlockPrefab, position, Quaternion.identity);
                }
                else if (cell == '.')
                {
                    Instantiate(destructibleBlockPrefab, position, Quaternion.identity);
                }
                else {
                    Debug.Log("Unknown block");
                }
            }
        }
    }
}