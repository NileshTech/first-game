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
    public int checkpoint = -1;
    int checkPointCount;
    int nextCheckpoint = 0;
    Dictionary<int, bool> visited = new Dictionary<int, bool>();
    public Text lapText;
    [HideInInspector]
    public bool missed = false;


    // Start is called before the first frame update
    void Start()
    {
        GameObject[] checkpoints = GameObject.FindGameObjectsWithTag("checkpoint");
        checkPointCount = checkpoints.Length;

        foreach(GameObject cp in checkpoints)
        {
            visited.Add(Int32.Parse(cp.name), false);
        }
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "checkpoint")
        {
            int checkpointCurrent = int.Parse(col.gameObject.name);

            if(checkpointCurrent == nextCheckpoint)
            {
                visited[checkpointCurrent] = true;
                checkpoint = checkpointCurrent;
                if (checkpointCurrent == 0)
                {
                    lap++;
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
