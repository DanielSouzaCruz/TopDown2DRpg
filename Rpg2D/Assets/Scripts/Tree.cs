using System.Collections;
using System.Collections.Generic;
using Unity.Profiling;
using UnityEngine;

public class Tree : MonoBehaviour
{
    [SerializeField] private float life;
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject woodPrefab;
    [SerializeField] private int woodAmount;
    [SerializeField] private ParticleSystem leafs;

    private bool isCut;

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
        leafs.Play();
        if(life <= 0)
        {
            for(int i = 0; i < woodAmount; i++) 
            {
                Instantiate(woodPrefab, transform.position + new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f), 0f), transform.rotation);
            }
            anim.SetTrigger("cut");
            isCut = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Axe") && !isCut)
        {
            OnHit();
        }
    }
}
