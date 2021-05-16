using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    GameObject Player;
    public GameObject missedcheckpointText;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");      
    }

    void Update()
    {
        if (Player.GetComponent<Checkpoints>().missed == true)
        {
            StartCoroutine(showmissedCheckpointText());
            Player.GetComponent<Checkpoints>().missed = false;
        }    
    }

    IEnumerator showmissedCheckpointText()
    {
        missedcheckpointText.SetActive(true);
        yield return new WaitForSeconds(2);
        missedcheckpointText.SetActive(false);

    }
}
