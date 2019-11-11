using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public int worldSize;
    public int foodSpawned;
    public int plantEaters;
    public int gamePoints;

    private int minWorldSize = 5;
    private int minFoodSpawned = 5;
    private int minPlantEaters = 1;

    public Text worldSizeText;
    public Text foodSpawnedText;
    public Text plantEatersText;
    public Text gamePointsText;
    public Text achievementInformationText;

    // Start is called before the first frame update
    void Start()
    {
        worldSize = GlobalControl.Instance.worldSize;
        foodSpawned = GlobalControl.Instance.foodSpawned;
        plantEaters = GlobalControl.Instance.plantEaters;
        gamePoints = GlobalControl.Instance.gamePoints;

    }

    // Update is called once per frame
    void Update()
    {
        worldSizeText.text = worldSize.ToString();
        foodSpawnedText.text = foodSpawned.ToString();
        plantEatersText.text = plantEaters.ToString();
        gamePointsText.text = gamePoints.ToString();
    }

    // Save data to Global Control
    public void SaveData()
    {
        GlobalControl.Instance.worldSize = worldSize;
        GlobalControl.Instance.foodSpawned = foodSpawned;
        GlobalControl.Instance.plantEaters = plantEaters;
        GlobalControl.Instance.gamePoints = gamePoints;
    }

    // Deals with the Start Button.
    public void ClickStart()
    {
        SaveData();
        SceneManager.LoadScene(sceneName: "Level01");
    }

    // Deals with the world size buttons.
    public void ClickSizePlus()
    {
        if (gamePoints > 0)
        {
            worldSize += 1;
            gamePoints -= 1;
        }
    }

    public void ClickSizeMinus()
    {
        if (worldSize > minWorldSize)
        {
            worldSize -= 1;
            gamePoints += 1;
        }
    }

    // Deals with the food spawned buttons.
    public void ClickFoodPlus()
    {
        if (gamePoints > 0)
        {
            foodSpawned += 1;
            gamePoints -= 1;
        }
    }

    public void ClickFoodMinus()
    {
        if (foodSpawned > minFoodSpawned)
        {
            foodSpawned -= 1;
            gamePoints += 1;
        }
    }

    // Deals with the plant eater buttons.
    public void ClickEaterPlus()
    {
        if (gamePoints > 0)
        {
            plantEaters += 1;
            gamePoints -= 1;
        }
    }

    public void ClickEaterMinus()
    {
        if (plantEaters > minPlantEaters)
        {
            plantEaters -= 1;
            gamePoints += 1;
        }
    }

    public void ClickPlantEaterGloss()
    {
        SceneManager.LoadScene("GlossaryPlantEater");
    }

    public void ClickMeatEaterGloss()
    {
        SceneManager.LoadScene("GlossaryMeatEater");
    }

    public void ClickNinjaAchievement()
    {
        achievementInformationText.text = "Ninja: No plant eaters killed in a 10 days span";
    }

    public void ClickLandOwnerAchievement()
    {
        achievementInformationText.text = "Land Owner: World size is larger than 100";
    }

    public void ClickGenocideAchievement()
    {
        achievementInformationText.text = "Geonocide: 5 or more meat eaters killed in 1 day";
    }
}
