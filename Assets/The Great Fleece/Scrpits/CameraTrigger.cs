using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraTrigger : MonoBehaviour
{

    //public Transform myCamera;
    public List<CinemachineVirtualCamera> cameras;
    private int currentCameraIndex = 0;



    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {

            foreach(var cam in cameras)
            {
                cam.Priority = 9;
            }

            cameras[currentCameraIndex].Priority = 11;

            currentCameraIndex++;


            //Camera.main.transform.position = myCamera.transform.position;
            //Camera.main.transform.rotation = myCamera.transform.rotation;
        }
    }
}
