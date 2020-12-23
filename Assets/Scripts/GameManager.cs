using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    public int gridAmount;

    private int gridTotalSize = 10;

    private float cubeScale;

    public GameObject gridCube;



    void Start()
    {
        GridInstatiate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GridInstatiate()
    {
        cubeScale = (float)gridTotalSize / gridAmount;

        for (float i = 0; i < gridAmount; i++)
        {
            for (float j = 0; j < gridAmount; j++)
            {
                GameObject cube =  Instantiate(gridCube, new Vector3(j * cubeScale, i * cubeScale, 0), Quaternion.identity, transform.Find("Grids"));
                cube.transform.localScale = new Vector3(cubeScale, cubeScale, cubeScale);
                cube.transform.gameObject.name = "" + j + "," + i + "";
            }
        }
    }
}
