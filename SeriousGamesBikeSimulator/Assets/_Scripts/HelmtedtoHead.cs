using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelmtedtoHead : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform head;
    public GameObject selectedObject;
    Camera cam;
    [SerializeField]
    private float distance = 3f;
    [SerializeField]
    private LayerMask hitMask;
    private Collider sphereCollider;

    void Start()
    {
        cam = Camera.main;
        sphereCollider = GetComponent<SphereCollider>();
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //   if(other.CompareTag("Player"))
    //    {
    //        selectedObject = gameObject;
    //    }


    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        selectedObject = null;
    //    }
    //}

    public void Update()
    {
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, distance, hitMask))
        {
            if (hitInfo.collider.gameObject == gameObject)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    gameObject.transform.position = head.position + (head.up * 0.4f) + (head.forward * 0.6f);
                    gameObject.transform.parent = head;
                    sphereCollider.enabled = false;
                    BikePrepManager.instance.helmetWorn = true;
                }
            }
        }
    }


    // Update is called once per frame
    
}
