using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotFarm : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite hole;
    [SerializeField] private Sprite carrot;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip holeSfx;
    [SerializeField] private AudioClip collectCarrotSfx;

    [Header("Settings")]
    [SerializeField] private int digLife;
    [SerializeField] private float waterAmount;
    [SerializeField] private bool detecting;

    private float currentWater;
    private int initialDigLife;
    private bool existHole;
    private bool carrotPlant;

    PlayerItems playterItems;

    private void Start()
    {
        playterItems = FindObjectOfType<PlayerItems>();
        initialDigLife = digLife;
    }

    private void Update()
    {

        if (existHole)
        {
            if (detecting)
            {
                currentWater += 0.01f;
            }

            if (currentWater >= waterAmount && !carrotPlant)
            {
                audioSource.PlayOneShot(holeSfx);
                spriteRenderer.sprite = carrot;
                carrotPlant = true;

                
            }

            if (Input.GetKeyDown(KeyCode.E) && carrotPlant)
            {
                audioSource.PlayOneShot(collectCarrotSfx);
                spriteRenderer.sprite = hole;
                playterItems.carrots++;
                currentWater = 0f;
            }
        }
        
    }


    public void OnHit()
    {
        digLife--;  

        if (digLife <= initialDigLife / 2)
        {
            spriteRenderer.sprite = hole;
            existHole = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Shovel"))
        {
            OnHit();
        }

        if (collision.CompareTag("Water"))
        {
            detecting = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Water"))
        {
            detecting = false;
        }
    }
}
