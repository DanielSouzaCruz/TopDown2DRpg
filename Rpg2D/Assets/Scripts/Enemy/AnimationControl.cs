using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControl : MonoBehaviour
{
    private Animator anim;


    [SerializeField] private Transform pointAttack;
    [SerializeField] private float radius;
    [SerializeField] private LayerMask playerLayer;


    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void PlayAnim(int value)
    {
        anim.SetInteger("transition", value);
    }

    public void Attack()
    {
        Collider2D hit = Physics2D.OverlapCircle(pointAttack.position, radius, playerLayer);

        if (hit != null)
        {
            Debug.Log("bateu");
        } 
        else
        {
            Debug.Log("n bateu");
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(pointAttack.position, radius);
    }

}
