using UnityEngine;

public class SpiderMovement : MonoBehaviour
{
    public float moveSpeed = 0.4f;
    public float interval = 10f;
    public float turnAngle = 180.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("RotateEveryFewSeconds", interval, interval);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    void RotateEveryFewSeconds()
    {
        transform.Rotate(new Vector3(0, 180, 0));
    }
}
