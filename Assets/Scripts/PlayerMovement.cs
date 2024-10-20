using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float rotateSpeed = 75f;

    private float verticalInput;
    private float horizontalInput;
    private Rigidbody rBody;
    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        verticalInput = Input.GetAxis("Vertical") * moveSpeed;
        horizontalInput = Input.GetAxis("Horizontal") * rotateSpeed;
    }

    private void FixedUpdate()
    {
        Vector3 rotation = Vector3.up * horizontalInput;

        Quaternion angleRototation = Quaternion.Euler(rotation * Time.fixedDeltaTime);
        rBody.MovePosition(this.transform.position + transform.forward * verticalInput * Time.fixedDeltaTime);
        rBody.MoveRotation(rBody.rotation * angleRototation);
    }
}
