﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    public GameObject TemplePrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    GameObject FindBuilding(int x, int y)
    {
        float targetX = 2.5f * (float)x + 1.25f;
        float targetY = 2.5f * (float)y + 1.25f;

        GameObject[] buildings = GameObject.FindGameObjectsWithTag("Building");

        for (int i = 0; i < buildings.Length; i++)
        {
            GameObject currBuilding = buildings[i];

            Vector3 currPosition = currBuilding.transform.position;

            if ((targetX - currPosition[0]) > -0.0625f && (targetX - currPosition[0]) < 0.0625f
                && (targetY - currPosition[1]) > -0.0625f && (targetY - currPosition[1]) < 0.0625f)
                return currBuilding;
        }

        return null;
    }

    public void CreateBuilding(string input)
    {
        //Debug.Log("CreateBuilding : " + input);
        string[] inputs = input.Split(',');
        int gridX = System.Convert.ToInt32(inputs[0]);
        int gridY = System.Convert.ToInt32(inputs[1]);
        string buildingType = inputs[2];

        float targetX = 2.5f * (float)gridX + 1.25f;
        float targetY = 2.5f * (float)gridY + 1.25f;

        switch(buildingType)
        {
            case "Temple":
            Instantiate(TemplePrefab, new Vector3(targetX, targetY, -0.5f), Quaternion.identity);
            break;
        }
    }

    public void DestroyBuilding(string input)
    {
        //Debug.Log("DestroyBuilding : " + input);
        string[] inputs = input.Split(',');
        int currGridX = System.Convert.ToInt32(inputs[0]);
        int currGridY = System.Convert.ToInt32(inputs[1]);

        GameObject currObject = FindBuilding(currGridX, currGridY);
        if (currObject == null)
        {
            Debug.Log("DestroyBuilding: " + "Cannot find object");
            return;
        }
        
        Destroy(currObject, 0.0f);
    }
}
