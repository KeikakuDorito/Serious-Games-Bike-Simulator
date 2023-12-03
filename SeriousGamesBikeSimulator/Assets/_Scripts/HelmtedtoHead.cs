using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelmtedtoHead : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform head;
    public GameObject selectedObject;
    Camera Cam;
    Vector3 myVector = new Vector3 (0f,0.27f,-0.81f);
    public LayerMask mask;



    private void OnTriggerEnter(Collider other)
    {
       if(other.CompareTag("Player"))
        {
            selectedObject = gameObject;
        }
        
      
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            selectedObject = null;
        }
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && selectedObject != null)
        {
        

                gameObject.transform.position = head.position + (head.up * 0.4f) + (head.forward * 0.6f);
                gameObject.transform.parent = head;

        }
    }


    // Update is called once per frame
    
}
