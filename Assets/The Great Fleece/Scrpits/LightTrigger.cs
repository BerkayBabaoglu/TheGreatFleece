using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int playerLayer = LayerMask.NameToLayer("Player");
        int lightLayer = LayerMask.NameToLayer("Light");

        Physics.IgnoreLayerCollision(playerLayer, lightLayer);
    }

}
