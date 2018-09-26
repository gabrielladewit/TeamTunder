using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{

    public GameObject livesUpgradeObj, heavyBallObj, UI;
    private Button livesUpgradeButton, heavyBallButton;
    private Slider livesUpgradeSlider;

    // Use this for initialization
    void Start()
    {
        livesUpgradeButton = livesUpgradeObj.GetComponentInChildren<Button>();
        heavyBallButton = heavyBallObj.GetComponentInChildren<Button>();
        livesUpgradeSlider = livesUpgradeObj.GetComponentInChildren<Slider>();
        Destroy(GameObject.Find("UI"));
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void BuyLivesUpgrade()
    {
        int playerMoney = 1000;

        switch ((int)livesUpgradeSlider.value)
        {
            case 0:
                if (playerMoney >= 100)
                {
                    playerMoney -= 100;
                    livesUpgradeSlider.value++;
                }
                return;
            case 1:
                if (playerMoney >= 200)
                {
                    playerMoney -= 200;
                    livesUpgradeSlider.value++;
                }
                return;
            case 2:
                if (playerMoney >= 400)
                {
                    playerMoney -= 400;
                    livesUpgradeSlider.value++;
                    livesUpgradeButton.interactable = false;
                }
                return;
        }
    }

    public void BuyHeavyBall()
    {   // PlayerMoney >= Price
        if (100 >= 100)
        {
            heavyBallButton.interactable = false;
        }
    }

    public void SaveStats()
    {
        int lives = (int)livesUpgradeSlider.value;
        bool heavyBought = !heavyBallButton.interactable;
    }
}
