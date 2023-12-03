using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryObject : MonoBehaviour
{
    public GameObject rustedChain;
    public GameObject cleanChain;
    public GameObject chainIndicator;

    public GameObject hitbox;

    public Transform orientation;

    Camera cam;
    [SerializeField]
    private float distance = 3f;
    [SerializeField]
    private LayerMask hitMask;

    bool carryingRusted;
    bool rustedRemoved = false;
    bool carryingClean;
    bool completed = false;

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
            if (carryingRusted == false)
            {
                if (hitInfo.collider.gameObject == rustedChain)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        rustedChain.transform.position = cam.transform.position + (cam.transform.forward * 1.2f);
                        rustedChain.transform.parent = cam.transform;
                        rustedRemoved = true;
                        carryingRusted = true;

                    }
                }
            }

            if (completed == false || carryingClean == false)
            {
                if (hitInfo.collider.gameObject == cleanChain)
                {
                     if (Input.GetMouseButtonDown(0))
                       {
                        cleanChain.transform.position = cam.transform.position + (cam.transform.forward * 1.2f);
                        cleanChain.transform.parent = cam.transform;
                        if (rustedRemoved == true) chainIndicator.SetActive(true);
                        carryingClean = true;

                       }
                   }
               }
            
        }


        if(carryingRusted == true)
        {
            if (Input.GetMouseButtonUp(0)){
                rustedChain.transform.parent = null;
                carryingRusted = false;
            }
        }


        if (cleanChain == true) //handles the release of clean chain
        {

            if (Input.GetMouseButtonUp(0))
            {
                cleanChain.transform.parent = null;

                if (hitbox.GetComponent<ChainCollide>().collided == true && rustedRemoved == true)//you let go of the object and it's colliding, then 
                {
                    
                    cleanChain.transform.position = chainIndicator.transform.position;
                    cleanChain.transform.rotation = chainIndicator.transform.rotation;
                    completed = true;
                    BikePrepManager.instance.chainReplaced = true;
                }
                chainIndicator.SetActive(false);
                carryingClean = false;
            }
        }
    }
}
