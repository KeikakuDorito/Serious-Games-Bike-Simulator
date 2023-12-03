using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainCollide : MonoBehaviour
{
    public bool collided;
    public GameObject chain;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if(other.gameObject == chain)
        {
            collided = true;
        }
    }
}
