using UnityEngine;

public class AttackSignalReceiver : MonoBehaviour
{
    public Animator animator;
    
    void Start()
    {
        if (animator == null)
            animator = GetComponent<Animator>();
    }
    
    public void TriggerAttack()
    {
        animator.SetTrigger("Attack");
        Debug.Log("Attack animation triggered via signal");
    }
}