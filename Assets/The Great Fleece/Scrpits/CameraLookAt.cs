using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CameraLookAt : MonoBehaviour
{
    public Transform player; // Oyuncunun Transform'u

    void Update()
    {
        // Kamera oyuncuya bakacak
        if (player != null)
        {
            transform.LookAt(player);
        }
    }
}
