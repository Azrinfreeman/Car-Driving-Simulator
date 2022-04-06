using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] float mouseSensitivity = 100f;

    public Transform playerBody;

    float xRotation = 0f;
    float yRotation = 0f;

    [Header("Zoom Variable")]
    [SerializeField] Camera playerCam;
    [SerializeField] private float timeToZoom = 0.3f;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        playerCam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90f);
        yRotation = mouseX;
        yRotation = Mathf.Clamp(yRotation, -35, 35f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * yRotation);

        if (Input.GetMouseButtonDown(1))
        {
            playerCam.fieldOfView = Mathf.Lerp(60, -15, 0.5f);
        }

        if (Input.GetMouseButtonUp(1))
        {
            playerCam.fieldOfView = Mathf.Lerp(60, 60, 0.5f);

        }

    }
}
