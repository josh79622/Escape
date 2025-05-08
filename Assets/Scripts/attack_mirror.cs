using UnityEngine;

public class attack_mirror : MonoBehaviour
{
    public Animator animator;
    public float attackTime = 20.0f; // Time in seconds when attack should occur
    
    private float timer = 0f;
    private bool attackTriggered = false;

    void Start()
    {
        // Get animator component if not assigned
        if (animator == null)
            animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Increment timer
        timer += Time.deltaTime;
        
        // Check if it's time to attack and we haven't triggered it yet
        if (timer >= attackTime && !attackTriggered)
        {
            // Trigger attack animation
            animator.SetTrigger("Attack");
            attackTriggered = true;
            Debug.Log("Attack animation triggered at " + timer + " seconds");
        }
    }
    
    // Use this to reset the timer if needed
    public void ResetTimer()
    {
        timer = 0f;
        attackTriggered = false;
    }
}