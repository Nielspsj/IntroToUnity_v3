using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float rotateSpeed = 75f;
    public float jumpVelocity = 5f;
    public float distanceToGround = 0.1f;
    public LayerMask groundLayer;
    public Transform groundCheckOrigin;

    private float verticalInput;
    private float horizontalInput;
    private Rigidbody rBody;
    private CapsuleCollider capsuleCollider;
    private bool isGrounded;
    private bool hitJump;
    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody>();
        capsuleCollider = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        verticalInput = Input.GetAxis("Vertical") * moveSpeed;
        horizontalInput = Input.GetAxis("Horizontal") * rotateSpeed;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            hitJump = true;
        }
        
    }

    private void FixedUpdate()
    {
        Jump();
       
        Movement();
    }

    private void Movement()
    {
        Vector3 rotation = Vector3.up * horizontalInput;
        Quaternion angleRototation = Quaternion.Euler(rotation * Time.fixedDeltaTime);

        rBody.MovePosition(this.transform.position + transform.forward * verticalInput * Time.fixedDeltaTime);
        rBody.MoveRotation(rBody.rotation * angleRototation);
    }

    private void Jump()
    {
        isGrounded = Physics.CheckSphere(groundCheckOrigin.position, distanceToGround, groundLayer);
        if (isGrounded == true && hitJump == true)
        {
            hitJump = false;
            rBody.AddForce(Vector3.up * jumpVelocity, ForceMode.Impulse);
        }
        /*
        Vector3 capsuleBottom = new Vector3 (capsuleCollider.bounds.center.x, capsuleCollider.bounds.min.y, capsuleCollider.bounds.center.z);
        isGrounded = Physics.CheckCapsule(capsuleCollider.bounds.center, capsuleBottom, distanceToGround, groundLayer, QueryTriggerInteraction.Ignore);
        */       
    }
}
