using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyAnimate : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    public void ShiftCuica(bool closed)
    {
        animator.SetBool("closed", closed);

        animator.Play("shift cuica");
    }

    public void PlayCuica(bool closed)
    {
        animator.SetBool("closed", closed);

        animator.Play("play cuica");

        TogglePushed();

    }

    private void TogglePushed()
    {
        bool pushed = animator.GetBool("pushed");

        if (pushed)
        {
            animator.SetBool("pushed", false);
        }
        else
        {
            animator.SetBool("pushed", true);
        }

    }


}
