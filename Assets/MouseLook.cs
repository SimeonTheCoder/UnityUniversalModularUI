using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public Transform playerBody; // Reference to the player's body to rotate it
    public float mouseSensitivity = 100f; // Sensitivity of mouse movement

    private float xRotation = 0f; // Vertical rotation of the camera

    void Start()
    {
        // Lock the cursor to the center of the screen
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Get mouse movement input
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Rotate the camera vertically (clamping to avoid flipping)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Limit up/down look
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Rotate the player's body horizontally
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
