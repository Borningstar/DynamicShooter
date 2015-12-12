using UnityEngine;
using System.Collections;

public class ShipAnimator : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = this.GetComponent<Animator>();
    }

    void Update()
    {
        Debug.Log(animator.GetInteger("Direction"));

        var horizontal = Input.GetAxis("Horizontal");

        animator.SetInteger("Direction", 1);

        if (horizontal > 0)
        {
            animator.SetInteger("Direction", 2);
        }
        else if (horizontal < 0)
        {
            animator.SetInteger("Direction", 0);
        }
    }
}
