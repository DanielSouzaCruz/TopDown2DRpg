using System.Collections;
using System.Collections.Generic;
using Unity.Profiling;
using UnityEngine;

public class Tree : MonoBehaviour
{
    [SerializeField] private float life;
    [SerializeField] private Animator anim;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnHit()
    {
        life--;
        anim.SetTrigger("isHit");
        if(life <= 0)
        {
            anim.SetTrigger("cut");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Axe"))
        {
            OnHit();
        }
    }
}
