using UnityEngine;
using UnityEngine.UI;

public class Door_OpenByDefault : MonoBehaviour
{
    bool trig, open;
    bool ePressed = false;
    public float smooth = 2.0f;
    public float DoorOpenAngle = 90.0f;  // Full door open angle
    public float initialOpenAngle = 20.0f; // Default door open angle (20 degrees)
    public float rotationTolerance = 1.0f; // Tolerance for stopping rotation
    private Quaternion defaultRot;
    private Quaternion openRot;
    private Quaternion initialOpenRot;  // For the initial open angle (20 degrees)
    public Text txt;

    void Start()
    {
        defaultRot = transform.rotation;
        openRot = Quaternion.Euler(defaultRot.eulerAngles + Vector3.up * DoorOpenAngle);
        initialOpenRot = Quaternion.Euler(defaultRot.eulerAngles + Vector3.up * initialOpenAngle);

        // Set the door to open slightly by default (20 degrees)
        transform.rotation = initialOpenRot;
    }

    void Update()
    {
        if (ePressed && trig)
        {
            open = !open;
            ePressed = false;
        }

        // Smoothly rotate to the desired position (open or closed)
        if (open && Quaternion.Angle(transform.rotation, openRot) > rotationTolerance)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, openRot, Time.deltaTime * smooth);
        }
        else if (!open && Quaternion.Angle(transform.rotation, initialOpenRot) > rotationTolerance)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, initialOpenRot, Time.deltaTime * smooth);
        }

        // Update the text based on door state
        if (trig)
        {
            if (open)
            {
                txt.text = "Close E";
            }
            else
            {
                txt.text = "Open E";
            }
        }
    }

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("Player"))
        {
            if (!open)
            {
                txt.text = "Close E";
            }
            else
            {
                txt.text = "Open E";
            }
            trig = true;
        }
    }

    private void OnTriggerExit(Collider coll)
    {
        if (coll.CompareTag("Player"))
        {
            txt.text = " ";
            trig = false;
        }
    }

    private void OnTriggerStay(Collider coll)
    {
        if (coll.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            ePressed = true;
        }
    }
}
