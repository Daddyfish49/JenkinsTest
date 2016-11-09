using UnityEngine;
using System.Collections;

public class LookScript : MonoBehaviour {
    //sensitivity of the mouse
    public float mouseSensitivity = 2.0f;
    //min and max Y axis
    public float maximumY = 80f;
    public float minimumY = -80f;
    //yaw of the camera
    private float yaw = 0f;
    //pitch of the camera
    public float pitch = 0f;
    private GameObject mainCamera;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        //make cursor invisible
        Cursor.visible = false;
        Camera cam = GetComponentInChildren<Camera>();
        mainCamera = cam.gameObject;
    }

	// Update is called once per frame
	void Update () {
        FPSCamera();
        
    }

    void LateUpdate()
    {
        mainCamera.transform.localEulerAngles = new Vector3(-pitch, 0, 0);
    }
    void FPSCamera()
    {
        yaw = transform.eulerAngles.y + Input.GetAxis("Mouse X") * mouseSensitivity;

        pitch = pitch + Input.GetAxis("Mouse Y") * mouseSensitivity;

        if (pitch >= maximumY)
        {
            pitch = maximumY;
        }
        else if (pitch <= minimumY)
        {
            pitch = minimumY;
        }
        transform.eulerAngles = new Vector3(0, yaw, 0);
        
    }
  
}
