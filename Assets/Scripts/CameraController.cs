using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera playerCamera;
    public float lookSpeed = 3f;
    public float lookXLimit = 45f;
    private float rotationX = 0;
    private CharacterController characterController;
    public Camera firstPersonCamera;
    public Camera thirdPersonCamera;



    void Start()
    {
        firstPersonCamera.enabled = true;
        thirdPersonCamera.enabled = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = (isRunning ? GetComponent<PlayerMovement>().runSpeed : GetComponent<PlayerMovement>().walkSpeed) * Input.GetAxis("Vertical");
        float curSpeedY = (isRunning ? GetComponent<PlayerMovement>().runSpeed : GetComponent<PlayerMovement>().walkSpeed) * Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.C)) 
        {
            firstPersonCamera.enabled = !firstPersonCamera.enabled;
            thirdPersonCamera.enabled = !thirdPersonCamera.enabled;

            if(firstPersonCamera.enabled) {
                playerCamera = firstPersonCamera;
            }
            else {
                playerCamera = thirdPersonCamera;
            }
        }

            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
    }
}
 
