using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 5;
    public Rigidbody rb;
    float horizontalInput;

    private void FixedUpdate()
    {
        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * 2 * speed * Time.fixedDeltaTime; 
        rb.MovePosition(rb.position + forwardMove + horizontalMove);
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
    }
}
