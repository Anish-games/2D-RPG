using UnityEngine;

public class LaserGuidedEnemy : MonoBehaviour
{
    public float rotationSpeed = 100f;
    public float rayDistance = 5f;
    public LineRenderer lineRenderer;
    public Material defaultShader;
    public Material hitShader;

    public Player player;
    void Start()
    {
        lineRenderer.positionCount = 2; // Ensure two points exist
        lineRenderer.material = defaultShader; // Set default shader
    }

    void Update()
    {
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime); // Rotate the circle

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.right, rayDistance);

        if (hitInfo.collider != null)
        {
            lineRenderer.SetPosition(1, hitInfo.point); // Stop at collision

            if (hitInfo.collider.CompareTag("Player"))
            {
                lineRenderer.material = hitShader; // Switch shader on player hit
                player.DamagePlayer();
            }
            else
            {
                lineRenderer.material = defaultShader; // Reset shader for other objects
            }
        }
        else
        {
            lineRenderer.SetPosition(1, transform.position + transform.right * rayDistance); // Extend fully
            lineRenderer.material = defaultShader; // Ensure default shader when no hit
        }

        lineRenderer.SetPosition(0, transform.position); // Start at the object
    }
}