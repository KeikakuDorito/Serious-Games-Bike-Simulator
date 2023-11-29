using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelmtedtoHead : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform head;
    Vector3 myVector = new Vector3 (0f,0.27f,-0.81f);

    void Start()
    {
       
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            gameObject.transform.position = head.position + (head.up * 0.4f) + (head.forward * 0.6f);
            gameObject.transform.parent = head;

        }
    }
}
