using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimandShoot : MonoBehaviour
{
    public Transform player;
    public float mouseSensitivity = 1.5f;
    float cameraVerticalRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        AimCam();

    }
    void AimCam()
    {
        float xTurn = Input.GetAxis("Mouse X") * mouseSensitivity;
        float yTurn = Input.GetAxis("Mouse Y") * mouseSensitivity;
        cameraVerticalRotation -= yTurn;
        cameraVerticalRotation = Mathf.Clamp(cameraVerticalRotation, -90, 90);
        transform.localEulerAngles = Vector3.right * cameraVerticalRotation;

        player.Rotate(Vector3.up * xTurn);
    }
}
