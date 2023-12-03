using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainCollide : MonoBehaviour
{
    public bool collided;


    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Normal Chain")
        {
            collided = true;
        }
    }
}
