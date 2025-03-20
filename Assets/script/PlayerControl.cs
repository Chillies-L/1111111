using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    public CinemachineVirtualCamera FirstPersonCam;
    public CinemachineVirtualCamera ThirdPersonCam;
    // ... existing code ...
    private Animator ani;
    private Rigidbody2D rbody;
    private float walkSpeed = 0.8f;    // 行走速度
    private float runSpeed = 1.6f;     // 跑步速度
    private float currentSpeed;         // 当前速度

    void Start()
    {
        // ... existing code ...
        ani = GetComponent<Animator>();
        rbody = GetComponent<Rigidbody2D>();
        currentSpeed = walkSpeed;       // 初始化为行走速度
    }

    void Update()
    {
        if (FirstPersonCam.Priority < ThirdPersonCam.Priority)
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");

            // 检测Shift键状态
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                currentSpeed = runSpeed;
            }
            else
            {
                currentSpeed = walkSpeed;
            }

            // ... existing code ...
            if (horizontal != 0)
            {
                ani.SetFloat("Horizontal", horizontal);
                ani.SetFloat("Vertical", 0);
            }
            if (vertical != 0)
            {
                ani.SetFloat("Vertical", vertical);
                ani.SetFloat("Horizontal", 0);
            }
            Vector2 dir = new Vector2(horizontal, vertical);
            ani.SetFloat("Speed", dir.magnitude);

            rbody.velocity = dir * currentSpeed;    // 使用当前速度
        }
    }
}
