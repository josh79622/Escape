using UnityEngine;

public class TimelineCharacterMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public string runningAnimationName = "Run";
    
    private Animator animator;
    
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    
    void Update()
    {
        // Check which animation is currently playing
        AnimatorClipInfo[] clipInfo = animator.GetCurrentAnimatorClipInfo(0);
        
        if (clipInfo.Length > 0 && clipInfo[0].clip.name.Contains(runningAnimationName))
        {
            // Move character forward when running animation is playing
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
    }
}