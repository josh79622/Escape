using UnityEngine;

public class CharacterMover : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float walkSpeed = 2f;
    public float runSpeed = 2f;
    public Animator animator;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var state = animator.GetCurrentAnimatorStateInfo(0);

        if (state.IsName("Walk"))
            transform.Translate(Vector3.forward * walkSpeed * Time.deltaTime);
        else if (state.IsName("Run"))
            transform.Translate(Vector3.forward * runSpeed * Time.deltaTime);
    }
}
