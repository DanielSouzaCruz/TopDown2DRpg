using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceController : MonoBehaviour
{
    [Header("Items")]
    [SerializeField] private Image waterUIBar;
    [SerializeField] private Image carrotUIBar;
    [SerializeField] private Image woodUIBar;
    [SerializeField] private Image fishUIBar;

    [Header("Tools")]
    public List<Image> toolsIcon = new List<Image>();
    [SerializeField] private Color chosenColor;
    [SerializeField] private Color alphaColor;

    private PlayerItems playerItems;
    private Player player;

    private void Awake()
    {
        playerItems = FindObjectOfType<PlayerItems>();
        player = playerItems.GetComponent<Player>();
    }

    // Start is called before the first frame update
    void Start()
    {
        waterUIBar.fillAmount = 0f;
        carrotUIBar.fillAmount = 0f;
        woodUIBar.fillAmount = 0f;
        fishUIBar.fillAmount = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        waterUIBar.fillAmount = playerItems.currentWater / playerItems.WaterLimit;
        woodUIBar.fillAmount = playerItems.Woods / playerItems.WoodLimit;
        carrotUIBar.fillAmount = playerItems.carrots / playerItems.CarrotsLimit;
        fishUIBar.fillAmount = playerItems.fishes / playerItems.FishesLimit;

        

        for (int i = 0; i < toolsIcon.Count; i++)
        {
            if (i == player.handlingObject)
            {
                toolsIcon[i].color = chosenColor;
            }
            else
            {
                toolsIcon[i].color = alphaColor;
            }
        }
    }
}
