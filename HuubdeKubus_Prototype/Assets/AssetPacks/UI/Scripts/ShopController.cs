using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{

    public GameObject livesUpgradeObj, heavyBallObj;
    private Text currentMoneyText;
    private Slider livesUpgradeSlider;
    public SaveInventory inventory;

    // Use this for initializatio
    void Start()
    {
        Destroy(GameObject.Find("UI"));
        inventory = this.gameObject.AddComponent<SaveInventory>();
        currentMoneyText = GameObject.Find("CurrentMoneyText").GetComponent<Text>();
        livesUpgradeSlider = livesUpgradeObj.GetComponentInChildren<Slider>();
        StartCoroutine(UpdateShopUI());
    }

    public void Update()
    {
        if (inventory.initialized)
        {
            LoadShopInventory();
        }
    }

    public void LoadShopInventory()
    {
        
    }

    public void BuyLivesUpgrade()
    {
        switch (inventory.currentLives)
        {
            case 0:
                if (inventory.currentMoney >= 100)
                {
                    inventory.SpendMoney(100);
                    inventory.AddLife();
                    livesUpgradeSlider.value++;
                }
                return;
            case 1:
                if (inventory.currentMoney >= 200)
                {
                    inventory.SpendMoney(200);
                    inventory.AddLife();
                    livesUpgradeSlider.value++;
                }
                return;
            case 2:
                if (inventory.currentMoney >= 400)
                {
                    inventory.SpendMoney(400);
                    inventory.AddLife();
                    livesUpgradeObj.GetComponentInChildren<Button>().interactable = false;
                }
                return;
        }
    }

    public void BuyHeavyBall()
    {   // PlayerMoney >= Price
        if (inventory.currentMoney >= 250)
        {
            inventory.SpendMoney(400);
            inventory.SetBoughtHeavy();
            heavyBallObj.GetComponentInChildren<Button>().interactable = false;
        }
    }

    IEnumerator UpdateShopUI()
    {
        while (true)
        {
            currentMoneyText.text = inventory.GetCurrentMoney().ToString();
            livesUpgradeSlider.value = inventory.GetCurrentLives();
            heavyBallObj.GetComponentInChildren<Button>().enabled = !inventory.GetCurrentBoughtHeavy();
            yield return new WaitForSeconds(1);
        }
    }
}
