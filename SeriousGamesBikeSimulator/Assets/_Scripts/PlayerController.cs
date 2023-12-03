using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float movementSpeed;

    public Transform orientation;

    float xInput;
    float yInput;

    Vector3 moveDirection;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        MovementInput();
        PlayerMovement();
    }

    private void MovementInput()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");
    }

    private void PlayerMovement()
    {
        transform.Translate(orientation.right * Time.deltaTime * xInput * movementSpeed, Space.Self);
        transform.Translate(orientation.forward * Time.deltaTime * yInput * movementSpeed, Space.Self);
    }
}
