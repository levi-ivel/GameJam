using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    private List<GameObject> inventory = new List<GameObject>();

    public static GameManager Instance;

    public int fishCount;
    public int coins;

    public Dictionary<string, int> fishValues;

    public Text fishCountText;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        fishValues = new Dictionary<string, int>();
        fishValues["deadfish1"] = 10; 
        fishValues["deadfish2"] = 15;
        fishValues["deadfish3"] = 10;
    }

    public void SaveGameData()
    {
        PlayerPrefs.SetInt("FishCount", fishCount);
        PlayerPrefs.SetInt("Coins", coins);
    }

    public void AddToInventory(GameObject item)
    {
        inventory.Add(item);
        Debug.Log(item.name + " added to inventory.");
    }

    public void UpdateFishCountText()
    {
        PlayerPrefs.SetInt("FishCount", fishCount);
        PlayerPrefs.Save();
        fishCountText.text = "Fish: " + fishCount;
    }

    public List<GameObject> GetInventory()
    {
        return inventory;
    }
}

