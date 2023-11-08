using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManeger : MonoBehaviour
{
    void Start()
    {
        coins = PlayerPrefs.GetInt("Coins", 0); 
        UpdateCoinsText();
        Debug.Log("Initial Coins: " + coins);
    }

        void OnEnable()
    {
        if (PlayerPrefs.HasKey("FishCount"))
        {
            int fishCount = PlayerPrefs.GetInt("FishCount");
            int coins = PlayerPrefs.GetInt("Coins");

            fishCountText.text = "Fish: " + fishCount;
            coinsText.text = "Coins: " + coins;
        }
    }


    public Text coinsText;
    public int coins = 0;
    public int fishCount;
    public Text upgradeStatusText;
    public Text fishCountText;

    public void BuyOxygenUpgrade()
    {
        BuyUpgrade("Oxygen", 20); 
    }

    public void BuyWeaponUpgrade()
    {
        BuyUpgrade("Weapon", 30); 
    }

    public void BuySpeedUpgrade()
    {
        BuyUpgrade("Speed", 15); 
    }

    public void BuyStrengthUpgrade()
    {
        BuyUpgrade("Strength", 25);
    }

    public void BuyNetUpgrade()
    {
        BuyUpgrade("Net", 10); 
    }


    void BuyUpgrade(string upgradeName, int cost)
    {
        Debug.Log("Coins before purchase: " + coins);  // Debug log to check initial coins

        if (coins >= cost)
        {
            coins -= cost;
            UpdateCoinsText();

            string message = ReturnUpgrade(upgradeName);
            upgradeStatusText.text = message;

            Debug.Log("Upgrade purchased. Coins after purchase: " + coins);  // Debug log after successful purchase
        }
        else
        {
            upgradeStatusText.text = "Not enough coins!";
            Debug.Log("Not enough coins to purchase the upgrade.");  // Debug log for insufficient coins
        }
    }


    public void SellFish()
    {
        int fishValue = GameManager.Instance.fishValues["deadfish1"];
        GameManager.Instance.coins += fishValue;

        GameManager.Instance.fishCount--;

        GameManager.Instance.SaveGameData();

        fishCountText.text = "Fish: " + GameManager.Instance.fishCount;

      
        UpdateCoinsText();
    }

    void UpdateCoinsText()
    {
        coinsText.text = "Coins: " + GameManager.Instance.coins;
    }



    string ReturnUpgrade(string upgradeName)
    {
     
        switch (upgradeName)
        {
            case "Oxygen":
                return "Oxygen upgraded!";
            case "Weapon":
                return "Weapon upgraded!";
            case "Speed":
                return "Speed upgraded!";
            case "Strength":
                return "Strength upgraded!";
            case "Net":
                return "Net upgraded!";
            default:
                return "Unknown upgrade";
        }
    }

}


