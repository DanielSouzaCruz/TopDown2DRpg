using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotFarm : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite hole;
    [SerializeField] private Sprite carrot;

    [SerializeField] private int digLife;
    private int initialDigLife;

    private void Start()
    {
        initialDigLife = digLife;
    }


    public void OnHit()
    {
        digLife--;  

        if (digLife <= initialDigLife / 2)
        {
            spriteRenderer.sprite = hole;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Shovel"))
        {
            OnHit();
        }
    }
}
