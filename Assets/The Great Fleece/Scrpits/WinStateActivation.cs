using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinStateActivation : MonoBehaviour
{
    public GameObject winCutscene;

    private void OnTriggerEnter(Collider other)
    {
        if(GameManager.Instance.HasCard == true)
        {
            winCutscene.SetActive(true);
        }
        else
        {
            Debug.Log("You must grab the key card!");
        }
    }
}
