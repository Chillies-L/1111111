using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl3D : MonoBehaviour
{
    private CharacterController cc;
    public float moveSpeed;
    public float jumpSpeed;
    public float runSpeed;
    private float horizontalMove, verticalMove;
    private Vector3 dir;

    public float checkRadius;
    public Transform groundCheck;
    public LayerMask groundLayer;
    private bool isGround;

    public float gravity;
    private Vector3 velocity;

    public CinemachineVirtualCamera FirstPersonCam;
    public CinemachineVirtualCamera ThirdPersonCam;
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (FirstPersonCam.Priority > ThirdPersonCam.Priority)
        {
            isGround = Physics.CheckSphere(groundCheck.position, checkRadius, groundLayer);

            if (isGround && velocity.y < 0)
            {
                velocity.y = 0.5f;
            }

            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                horizontalMove = Input.GetAxis("Horizontal") * runSpeed;
                verticalMove = Input.GetAxis("Vertical") * runSpeed;
            }
            else
            {
                horizontalMove = Input.GetAxis("Horizontal") * moveSpeed;
                verticalMove = Input.GetAxis("Vertical") * moveSpeed;
            }

            dir = transform.forward * verticalMove + transform.right * horizontalMove;
            cc.Move(dir * Time.deltaTime);

            velocity.y -= gravity * Time.deltaTime;
            cc.Move(velocity * Time.deltaTime);//gravity system

            if(Input.GetButtonDown ("Jump")&& isGround)
            {
                velocity.y = jumpSpeed;
            }
        }
    }
}
