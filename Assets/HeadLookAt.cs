using UnityEngine;

public class HeadLookAt : MonoBehaviour
{
    public Transform target;
    public float lookWeight = 1f;
    public float bodyWeight = 0.3f;
    public float headWeight = 0.7f;
    
    private Animator animator;
    
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    
    void OnAnimatorIK(int layerIndex)
    {
        if (target != null && animator != null)
        {
            animator.SetLookAtWeight(lookWeight, bodyWeight, headWeight);
            animator.SetLookAtPosition(target.position);
        }
    }
}