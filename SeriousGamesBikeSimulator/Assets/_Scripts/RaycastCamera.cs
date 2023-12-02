using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastCamera : MonoBehaviour
{
    Camera cam;
    [SerializeField]
    private float distance = 3f;
    [SerializeField]
    private LayerMask hitMask;

    // Start is called before the first frame update
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
        }
    }
}
