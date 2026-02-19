using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControl : MonoBehaviour
{
    private Animator anim;


    [SerializeField] private Transform pointAttack;
    [SerializeField] private float radius;
    [SerializeField] private LayerMask playerLayer;

    private PlayerAnim playerAnim;
    private Skeleton skeleton;


    void Start()
    {
        anim = GetComponent<Animator>();
        playerAnim = FindObjectOfType<PlayerAnim>();
        skeleton = GetComponentInParent<Skeleton>();
    }

    public void PlayAnim(int value)
    {
        anim.SetInteger("transition", value);
    }

    public void Attack()
    {

        if (!skeleton.isDead)
        {
            Collider2D hit = Physics2D.OverlapCircle(pointAttack.position, radius, playerLayer);

            if (hit != null)
            {
                playerAnim.OnHit();
            }
        }
        
        
    }

    public void OnHit()
    {
        

        if(skeleton.currentHealth <= 0)
        {
            skeleton.isDead = true;
            anim.SetTrigger("death");
            Destroy(skeleton.gameObject, 1f);
        }
        else
        {
            anim.SetTrigger("hurt");
            skeleton.currentHealth--;

            skeleton.healthBar.fillAmount = skeleton.currentHealth / skeleton.totalHealth;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(pointAttack.position, radius);
    }

}
