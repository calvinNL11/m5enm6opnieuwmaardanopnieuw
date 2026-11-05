using UnityEngine;

public class Movement : MonoBehaviour
{
    public float rotationSpeed = 100f;
    public float moveSpeed;
    public bool useInput;

    // Update is called once per frame
    void Update()
    {
        float input = useInput ? Input.GetAxis("Vertical") : 1f; // movement
        transform.position += transform.forward * moveSpeed * input * Time.deltaTime;

        transform.Rotate(transform.up * rotationSpeed * Time.deltaTime * Input.GetAxis("Horizontal")); // rotation
    }
}
