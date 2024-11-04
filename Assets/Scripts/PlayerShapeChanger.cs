using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class PlayerShapeChanger : MonoBehaviour
{
    public Mesh cubeMesh;       // Assign the cube mesh in the Inspector
    public Mesh sphereMesh;     // Assign the sphere mesh in the Inspector

    private MeshFilter meshFilter;
    private PlayerScoreManager scoreManager;

    void Start()
    {
        // Get the MeshFilter component
        meshFilter = GetComponent<MeshFilter>();

        // Find and reference the PlayerScoreManager component
        scoreManager = GetComponent<PlayerScoreManager>();

        if (scoreManager == null)
        {
            Debug.LogError("PlayerScoreManager component not found on the GameObject.");
        }
    }

    void Update()
    {
        // Only allow shape change if score is 10 or higher
        if (scoreManager != null && scoreManager.score >= 10)
        {
            // Transform into a cube when pressing Q
            if (Input.GetKeyDown(KeyCode.Q))
            {
                ChangeToCube();
            }

            // Transform into a sphere when pressing E
            if (Input.GetKeyDown(KeyCode.E))
            {
                ChangeToSphere();
            }
        }
    }

    private void ChangeToCube()
    {
        // Adjust y-coordinate and move to current position
        MoveToCurrentPosition(2f);

        // Set the mesh to the cube mesh
        meshFilter.mesh = cubeMesh;
        ResetScale();

        // Remove any existing collider
        RemoveExistingCollider();

        // Add BoxCollider for cube shape
        BoxCollider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.size = Vector3.one; // Adjust as needed for your mesh size
    }

    private void ChangeToSphere()
    {
        // Adjust y-coordinate and move to current position
        MoveToCurrentPosition(2f);

        // Set the mesh to the sphere mesh
        meshFilter.mesh = sphereMesh;
        ResetScale();

        // Remove any existing collider
        RemoveExistingCollider();

        // Add SphereCollider for sphere shape
        SphereCollider sphereCollider = gameObject.AddComponent<SphereCollider>();
        sphereCollider.radius = 0.5f; // Adjust as needed for your mesh size
    }

    private void MoveToCurrentPosition(float heightOffset)
    {
        // Set the player position to the current position with the y-coordinate offset
        transform.position = new Vector3(transform.position.x, heightOffset, transform.position.z);
    }

    private void RemoveExistingCollider()
    {
        // Remove any existing Collider component
        Collider existingCollider = GetComponent<Collider>();
        if (existingCollider != null)
        {
            Destroy(existingCollider);
        }
    }

    private void ResetScale()
    {
        transform.localScale = Vector3.one; // Reset scale to default
    }
}
