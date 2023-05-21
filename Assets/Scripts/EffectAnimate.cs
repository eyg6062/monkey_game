using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectAnimate : MonoBehaviour
{
    private Animator animator;

    float effectTimer = 0;
    [SerializeField] float effectDuration;
    bool effectPlaying = false;

    private void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    public void Perfect()
    {
        animator.Play("perfect");
        effectPlaying = true;
        effectTimer = 0;
    }

    public void Good()
    {
        animator.Play("good");
        effectPlaying = true;
        effectTimer = 0;
    }

    public void Miss()
    {
        animator.Play("miss");
        effectPlaying = true;
        effectTimer = 0;
    }

    public void LilMokePlay()
    {
        animator.Play("lil moke play");
        effectPlaying = true;
        effectTimer = 0;
    }

    private void Update()
    {
        if (effectPlaying)
        {
            effectTimer += Time.deltaTime * 1000;

            if (effectTimer >= effectDuration)
            {
                animator.Play("empty");
                effectTimer = 0;
                effectPlaying = false;
            }
        }
        
    }
}
