using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpBike : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject Wheel;
    public GameObject InflatedWheel;
    public GameObject SelectedObject;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SelectedObject = gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SelectedObject = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && SelectedObject != null)
        {
            Wheel.SetActive(false);
            InflatedWheel.SetActive(true);
        }
    }
}
