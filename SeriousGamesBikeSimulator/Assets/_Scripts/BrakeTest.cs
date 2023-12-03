using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrakeTest : MonoBehaviour
{

    public GameObject brakeOn;
    public GameObject brakeOff;
    Camera cam;
    [SerializeField]
    private float distance = 3f;
    [SerializeField]
    private LayerMask hitMask;

    void Start()
    {
        cam = Camera.main;
    }


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
                if (Input.GetMouseButton(0))
                {
                    brakeOff.SetActive(false);
                    brakeOn.SetActive(true);
                    BikePrepManager.instance.brakesChecked = true;
                }
                else
                {
                    brakeOn.SetActive(false);
                    brakeOff.SetActive(true);
                }
            }
        }
        else
        {
            brakeOn.SetActive(false);
            brakeOff.SetActive(true);
        }
    }
}
