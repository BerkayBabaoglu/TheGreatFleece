using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityCamDetected : MonoBehaviour
{
    public GameObject gameoverScene;
    public Animator animator;
    

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            MeshRenderer render = GetComponent<MeshRenderer>();
            Color color = new Color(0.6f, 0.11f, 0.11f, 0.03f);
            render.material.SetColor("_TintColor", color);
            animator.enabled = false;
            StartCoroutine(Busted());
            
        }
    }
    IEnumerator Busted()
    {
        yield return new WaitForSeconds(0.5f);
        gameoverScene.SetActive(true);
    }

}
