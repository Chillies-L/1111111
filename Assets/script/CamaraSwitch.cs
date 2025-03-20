using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraSwitch : MonoBehaviour
{

    public CinemachineVirtualCamera FirstPersonCam;
    public CinemachineVirtualCamera ThirdPersonCam;

    void SwitchToThirdCam()
    {
        FirstPersonCam.Priority = 0;
        ThirdPersonCam.Priority = 10;
    }
    void SwitchToFirstCam()
    {
        FirstPersonCam.Priority = 10;
        ThirdPersonCam.Priority = 0;
    }
    // Start is called before the first frame update
    void Start()
    {
        FirstPersonCam.Priority = 0;
        ThirdPersonCam.Priority = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            if(FirstPersonCam.Priority > ThirdPersonCam.Priority)
            {
                SwitchToThirdCam();
            }
            else
            {
                SwitchToFirstCam();
            }
        }
    }
}
