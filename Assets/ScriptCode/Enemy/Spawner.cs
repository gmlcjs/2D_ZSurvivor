using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    private void Update()
    {
        if (Input.GetButton("Jump")){ 
            GameManager.instance.poolManager.Get(0);
        }
    }

}