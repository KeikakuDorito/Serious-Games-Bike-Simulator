using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpBike : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject Wheel;
    public GameObject InflatedWheel;
    //public GameObject SelectedObject;
    Camera cam;
    [SerializeField]
    private float distance = 3f;
    [SerializeField]
    private LayerMask hitMask;


    void Start()
    {
        cam = Camera.main;
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        SelectedObject = gameObject;
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        SelectedObject = null;
    //    }
    //}

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, distance, hitMask))
        {
            if (hitInfo.collider.gameObject == gameObject)
            {
                Debug.Log("detected");
                if (Input.GetMouseButtonDown(0))
                {
                    Wheel.SetActive(false);
                    InflatedWheel.SetActive(true);
                    Debug.Log("inflated");
                }
            }
        }
    }
}
