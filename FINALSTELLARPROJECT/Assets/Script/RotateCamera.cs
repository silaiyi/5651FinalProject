using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateCamer : MonoBehaviour
{
    public int yRotationMinLimit = -20;
    public int yRotationMaxLimit = 80;
    public float xRotationSpeed = 250.0f;
    public float yRotationSpeed = 120.0f;
    private float xRotation = 0.0f;
    private float yRotation = 0.0f;
    private MouseState mMouseState = MouseState.None;
    private Camera mCamera;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if(InGameUpdate.inUpdating == false&&Pause.GameIsPaused == false){
            CameraRotate();
        }
        //CameraRotate();
    }
    public enum MouseState
    {
        None,
        MidMouseBtn,
        LeftMouseBtn

    }
    void CameraRotate()
    {
        if (mMouseState == MouseState.None)
        {
            xRotation -= Input.GetAxis("Mouse X") * xRotationSpeed * 0.02f;
            yRotation += Input.GetAxis("Mouse Y") * yRotationSpeed * 0.02f;

            yRotation = ClampValue(yRotation, yRotationMinLimit, yRotationMaxLimit);
            Quaternion rotation = Quaternion.Euler(-yRotation, -xRotation, 0);
            transform.rotation = rotation;

        }
    }
    float ClampValue(float value, float min, float max)
   {
       if (value < -360)
           value += 360;
       if (value > 360)
           value -= 360;
       return Mathf.Clamp(value, min, max);
   }
}
