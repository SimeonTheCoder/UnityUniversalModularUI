using UnityEngine;
using System.Collections;

public class ForceMeter : MonoBehaviour
{
    public GameObject bar;   // The 2D object that acts as the bar
    public GameObject limit; // The limit point where the bar stops stretching

    public float maxValue = 100f;  // The maximum value the bar can reach
    public float increaseRate = 10f;  // How fast the value increases per second
    public float stretchSpeed = 2f;  // Speed of stretching
    public float returnSpeed = 2f;   // Speed of returning to normal
    private float currentValue = 0f; // Current value of the bar
    private Vector3 originalScale;   // Original scale of the bar
    private Vector3 originalPosition; // Original position of the bar

    private LineRenderer lineRenderer;

    public float moveSpeed = 0.1f; // Speed at which the limit moves
    public float maxHeightAboveBar = 170f; // Maximum height the limit can go above the bar
    private float originalLimitY; // Y position of the limit at the start

    void Start()
    {
        // Get the LineRenderer component or add it if it doesn't exist
        lineRenderer = GetComponent<LineRenderer>();
        if (lineRenderer == null)
        {
            lineRenderer = gameObject.AddComponent<LineRenderer>();
        }

        // Set the LineRenderer properties (if not already set)
        lineRenderer.startWidth = 23f;  // Set start width of the line
        lineRenderer.endWidth = 23f;    // Set end width of the line
        lineRenderer.material = new Material(Shader.Find("Assets/Bar.mat"));  // Assign a material
        lineRenderer.positionCount = 2;  // We only have 2 points: start and end

        // Initialize the bar's original position and scale
        originalPosition = bar.transform.position;
        originalScale = bar.transform.localScale;

        // Save the original Y position of the limit
        originalLimitY = limit.transform.position.y;
    }

    void Update()
    {
        // Move the limit up or down based on key presses, with boundaries
        if (Input.GetKey(KeyCode.B)) // When 'B' is pressed
        {
            // Check if the limit is not above the max height above the bar
            if (limit.transform.position.y < bar.transform.position.y + maxHeightAboveBar)
            {
                limit.transform.position += Vector3.up * moveSpeed;
            }
        }

        if (Input.GetKey(KeyCode.N)) // When 'N' is pressed
        {
            // Check if the limit is not below its original position
            if (limit.transform.position.y > bar.transform.position.y)
            {
                limit.transform.position -= Vector3.up * moveSpeed;
            }
        }

        // Update the positions of the line's endpoints
        lineRenderer.SetPosition(0, bar.transform.position);  // Start point
        lineRenderer.SetPosition(1, limit.transform.position); // End point
    }
}
