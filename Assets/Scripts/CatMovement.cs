using UnityEngine;

public class CatMovement : MonoBehaviour
{
    public string targetTag = "Player";
    public float moveSpeed = 0.5f;
    public float interval = 10f;
    public float turnAngle = 90.0f;
    private bool isTurning = false;
    private float totalTurn = 0;

    public float scareDistance = 3.0f;
    public float safeDistance = 6.0f;
    public float runningSpeed = 1.5f;
    private bool isScared = false;

    private Vector3 awayDirection;

    private Animator anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        InvokeRepeating("RotateEveryFewSeconds", interval, interval);
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag(targetTag);
        foreach (GameObject obj in targets)
        {
            float dist = Vector3.Distance(transform.position, obj.transform.position);
            Debug.Log("DIST: " + dist);

            if (dist <= scareDistance)
            {
                isScared = true;
                anim.SetInteger("Status", 2);
                awayDirection = transform.position - obj.transform.position;

                Quaternion rot = Quaternion.LookRotation(awayDirection);
                transform.rotation = rot;

            }
            else if (dist >= safeDistance)
            {
                isScared = false;
                anim.SetInteger("Status", 1);
            }
        }

        if (isScared)
        {
            isTurning = false;
            totalTurn = 0;

            transform.Translate(Vector3.forward * runningSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            if (isTurning)
            {
                totalTurn += 1;
                transform.Rotate(new Vector3(0, 1, 0));

                if (totalTurn == turnAngle)
                {
                    totalTurn = 0;
                    isTurning = false;
                }
            }
        }
    }

    void RotateEveryFewSeconds()
    {
        Debug.Log("????");
        isTurning = true;
    }
}
