using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdvancedUpgrades : MonoBehaviour
{
    // Buttons from panel.
    public Button S1;
    public Button S2;
    public Button S3;
    public Button S4;
    public Button S5;
    public Button M1;
    public Button M2;
    public Button M3;
    public Button M4;
    public Button M5;

    // Text from panel.
    public Text advacedUpgradeText;

    // Panel
    public GameObject advancedUpgradePanel;

    // Prefabs
    public Transform militaryOutpost;
    public Transform scienceOutpost;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && advancedUpgradePanel.activeInHierarchy == true)
        {
            advancedUpgradePanel.SetActive(false);
        }
    }

    public void ExitPanel()
    {
        advancedUpgradePanel.SetActive(false);
    }

    public void HoverS1()
    {
        advacedUpgradeText.text = "Cost: 100 - Get Research Facility \nRequires: World Size 10 or larger";
    }

    public void HoverS2()
    {
        advacedUpgradeText.text = "This feature is not ready.";
    }

    public void HoverM1()
    {
        advacedUpgradeText.text = "Cost: 200 - Get Military Outpost";
    }

    public void HoverM2()
    {
        advacedUpgradeText.text = "This feature is not ready.";
    }

    public void ClearText()
    {
        advacedUpgradeText.text = "";
    }

    public void ClickS1()
    {
        if (GameObject.Find("Game").GetComponent<GameMain>().gamePoints > 100 && GameObject.Find("Game").GetComponent<GameMain>().s1Unlocked == false)
        {
            if (GameObject.Find("Game").GetComponent<GameMain>().worldSize >= 10)
            {
                S1.GetComponent<Image>().color = Color.green;
                GameObject.Find("Game").GetComponent<GameMain>().gamePoints -= 100;
                GameObject.Find("Game").GetComponent<GameMain>().s1Unlocked = true;

                // Create the Science Outpost.
                Transform s = Instantiate(scienceOutpost);
                Vector3 outpostPosition = new Vector3(GameObject.Find("Game").GetComponent<GameMain>().worldSize + 1, 1.8f, GameObject.Find("Game").GetComponent<GameMain>().worldSize / 2);
                s.localPosition = outpostPosition;
            }

            else
            {
                advacedUpgradeText.text = "World Size not large enough. Need a minimum of 10.";
            }

        }

        

    }

    public void ClickM1()
    {
        if (GameObject.Find("Game").GetComponent<GameMain>().gamePoints > 200 && GameObject.Find("Game").GetComponent<GameMain>().m1Unlocked == false)
        {
            if (GameObject.Find("Game").GetComponent<GameMain>().worldSize >= 10)
            {
                M1.GetComponent<Image>().color = Color.green;
                GameObject.Find("Game").GetComponent<GameMain>().gamePoints -= 200;
                GameObject.Find("Game").GetComponent<GameMain>().m1Unlocked = true;

                // Create the Military Outpost.
                Transform m = Instantiate(militaryOutpost);
                Vector3 outpostPosition = new Vector3(-2f, 1.8f, GameObject.Find("Game").GetComponent<GameMain>().worldSize / 2);
                m.localPosition = outpostPosition;
            }

            else
            {
                advacedUpgradeText.text = "World Size not large enough. Need a minimum of 10.";
            }
            

        }
    }

 
}
