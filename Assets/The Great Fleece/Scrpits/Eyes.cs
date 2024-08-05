using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eyes : MonoBehaviour
{

    public GameObject gameoverCutscene;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            gameoverCutscene.SetActive(true);
        }
    }
}
