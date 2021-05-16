using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Checkpoints : MonoBehaviour
{
    [HideInInspector]
    public int lap = 0;
    [HideInInspector]
    public int checkPoint = -1;
    int checkPointCount;
    int nextCheckpoint = 0;
    Dictionary<int, bool> visited = new Dictionary<int, bool>();
    public Text lapText;
    [HideInInspector]
    public bool missed = false;
    public GameObject PrevCheckpoint;

    public float timehit;

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] checkpoints = GameObject.FindGameObjectsWithTag("checkpoint");
        checkPointCount = checkpoints.Length;
        foreach(GameObject checkpoint in checkpoints)
        {
            if(checkpoint.name == "0")
            {
                PrevCheckpoint = checkpoint;
                break;
            }
        }
        foreach(GameObject cp in checkpoints)
        {
            visited.Add(Int32.Parse(cp.name), false);
        }
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider col)
    {
        Debug.Log("collision");
        if(col.gameObject.tag == "checkpoint")
        {
            int checkpointCurrent = int.Parse(col.gameObject.name);

            if(checkpointCurrent == nextCheckpoint)
            {
                timehit = Time.time;
                PrevCheckpoint = col.gameObject;
                visited[checkpointCurrent] = true;
                checkPoint = checkpointCurrent;
                if(checkPoint == 0)
                {
                    lap++;
                }
                if (checkpointCurrent == 0 && gameObject.tag == "Player")
                {
                   
                    lapText.text = "Lap: " + lap;
                }
                nextCheckpoint++;
                if(nextCheckpoint >= checkPointCount)
                {
                    var keys = new List<int>(visited.Keys);
                    foreach(int key in keys)
                    {
                        visited[key] = false;
                    }
                    nextCheckpoint = 0;
                }
            }
            else if (checkpointCurrent != nextCheckpoint && visited[checkpointCurrent]==false)
            {
                missed = true;
            }
            
        }
        
    }
}
