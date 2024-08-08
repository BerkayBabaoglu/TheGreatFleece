using Cinemachine.Utility;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.Playables;



public class GameManager : MonoBehaviour
{

    public PlayableDirector introCutscene;
    public Camera mainCamera;
    public Vector3 cameraInitialPosition;
    public Quaternion cameraInitialRotation;

    public bool izin;

    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.Log("GameManager is null!!!");
            }

            return _instance;
        }
    }

    public bool HasCard { get; set; }


    private void Awake()
    {
        _instance = this;

        if (mainCamera != null)
        {
            cameraInitialPosition = mainCamera.transform.position;
            cameraInitialRotation = mainCamera.transform.rotation;
        }
    }

    private void Start()
    {
        if (introCutscene != null)
        {
            introCutscene.Play();
            StartCoroutine(WaitForCutSceneToEnd());
        }

    }

    private IEnumerator WaitForCutSceneToEnd()
    {
        //playableDirector'un suresini bekle
        yield return new WaitForSeconds((float)introCutscene.duration);

        if (mainCamera != null)
        {
            mainCamera.transform.position = cameraInitialPosition;
            mainCamera.transform.rotation = cameraInitialRotation;
        }

    }

    private void Update()
    {
        izin = true;
        check(izin);

        if (Input.GetKeyDown(KeyCode.S))
        {
            izin = false;
            check(izin);
            VoiceManager.Instance.PlayMusic();
        }
    }

    public void setCameraPosition(Vector3 newPosition, Quaternion newRotation)
    {
        if (mainCamera != null)
        {
            mainCamera.transform.position = newPosition;
            mainCamera.transform.rotation = newRotation;
        }
    }

    public void check(bool izin)
    {
        if (izin == true)
        {
            introCutscene.gameObject.SetActive(true);
        }
        else
        {
            introCutscene.time = 59.0f;
            //bu konumda
        }
    }

}

