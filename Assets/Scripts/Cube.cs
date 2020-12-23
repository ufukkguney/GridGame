using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject xObject;
    private GameManager gameManager;
    private GameObject grids;


    List<GameObject> xObjects;


    void Start()
    {
        xObject = transform.Find("XObject").gameObject;
        gameManager = FindObjectOfType<GameManager>();
        grids = gameManager.transform.Find("Grids").gameObject;

    }

    private void OnMouseDown()
    {
        if (!xObject.activeInHierarchy)
        {
            xObjects = new List<GameObject>();
            int counter = 0;
            string[] minmax = transform.gameObject.name.Split(',');
            int width = int.Parse(minmax[0]);
            int height = int.Parse(minmax[1]);

            int tempIncWidth = width + 1;
            int tempDecWidth = width - 1;

            int tempIncHeight = height + 1;
            int tempDecHeight = height - 1;

            AddToList(tempDecWidth + "," + tempDecHeight);
            AddToList(tempDecWidth + "," + height);
            AddToList(tempDecWidth + "," + tempIncHeight);
            AddToList(width + "," + tempDecHeight);
            AddToList(width + "," + height);
            AddToList(width + "," + tempIncHeight);
            AddToList(tempIncWidth + "," + tempDecHeight);
            AddToList(tempIncWidth + "," + height);
            AddToList(tempIncWidth + "," + tempIncHeight);


            for (int i = 0; i < xObjects.Count; i++) // just for count
            {
                if (xObjects[i].transform.Find("XObject").gameObject.activeInHierarchy)
                {
                    counter++;
                }
            }

            if (counter >= 3)
            {
                for (int i = 0; i < xObjects.Count; i++)
                {
                    if (xObjects[i].transform.Find("XObject").gameObject.activeInHierarchy)
                    {
                        xObjects[i].transform.Find("XObject").gameObject.SetActive(false);
                    }
                }
            }
            else
            {
                xObject.SetActive(true);
            }
        }
        
    }
    private void AddToList(string ObjectName)
    {
        for (int i = 0; i < grids.transform.childCount; i++)
        {
            if (grids.transform.GetChild(i).gameObject.name.Contains(ObjectName))
            {
                GameObject neighbor = grids.transform.Find(ObjectName).gameObject;
                xObjects.Add(neighbor);
            }

        }
    }
}
