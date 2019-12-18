using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    //panels and buttons for tutorial level.
    public GameObject upgradePanel;
    public GameObject controlPanel;
    public GameObject gameSpeedPanel;
    public GameObject achievementPanel;
    public GameObject dayCountPanel;
    public Button backToMenu;


    public RectTransform tutorialPanel;
    //public RectTransform gameSpeedPanel;
    public Text tutorialText;
    private Vector3 panelPos;
    public bool task1 = false; // Press Mouse 2 button.
    public bool task2 = false; // Press the Play button.
    public bool task3 = false; // Add 3 plant Eaters to the game.
    public bool task4 = false; // Wait for plant Eaters to die.
    public bool task5 = false; // Add 10 plants to the game.
    public bool task6 = false;
    public bool task7 = false;
    public bool task8 = false;

    // Start is called before the first frame update
    void Start()
    {
        // Set panels and buttons invisible.
        upgradePanel.SetActive(false);
        controlPanel.SetActive(false);
        gameSpeedPanel.SetActive(false);
        achievementPanel.SetActive(false);
        dayCountPanel.SetActive(false);
        backToMenu.gameObject.SetActive(false);

        // Set settings in Game Main script to start tutorial.
        GetComponent<TutGameMain>().gamePaused = true;

        // Delete all food on start;
        for (int i = GetComponent<TutGameMain>().foodList.Count - 1; i >= 0; i--)
        {
            Destroy(GetComponent<TutGameMain>().foodList[i].gameObject);
        }
        GetComponent<TutGameMain>().foodList.Clear();
        GetComponent<TutGameMain>().foodSpawned = 0;

        // Destroy all plant eaters.
        for (int i = GetComponent<TutGameMain>().plantEaterList.Count - 1; i >= 0; i--)
        {
            Destroy(GetComponent<TutGameMain>().plantEaterList[i].gameObject);
        }
        GetComponent<TutGameMain>().plantEaterList.Clear();
        GetComponent<TutGameMain>().plantEaters = 0;

        GetComponent<TutGameMain>().movePlanetOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (task1 == false)
        {
            if (Input.GetMouseButton(2))
            {
                task1 = true;
                Task2();
            }
        }

        else if(task2 && task3 == false)
        {
            if (GetComponent<TutGameMain>().plantEaters >= 3 && GetComponent<TutGameMain>().creaturesAwake)
            {
                task3 = true;
                Task4();
            }
        }

        else if(task4 && task5 == false)
        {

            if (GetComponent<TutGameMain>().plantEaters == 0) task5 = true;
          
        }

        else if(task5 && task6 == false)
        {
            if (GetComponent<TutGameMain>().plantEaters == 0) Task5();
        }


        else if (task6 && task7 == false)
        {
            if (GetComponent<TutGameMain>().worldSize >= 10)
            {
                task7 = true;
                Task7();
            }
        }

        else if (task7 && task8== false)
        {
            if (GetComponent<TutGameMain>().worldSize >= 30)
            {
                task7 = true;
                Task8();
            }
        }

    }

    public void Task2()
    {
        gameSpeedPanel.SetActive(true);
        tutorialPanel.sizeDelta = new Vector2(200, 60);
        panelPos = gameSpeedPanel.transform.localPosition;
        panelPos.y -= 60f;
        tutorialPanel.localPosition = panelPos;
        tutorialText.rectTransform.sizeDelta = new Vector2(180, 55);
        tutorialText.text= "This is the Speed Panel. \n Try pressing PLAY.";
    }

    public void Task3()
    {
        if (task1 == true && task2 == false)
        {
            task2 = true;
            controlPanel.SetActive(true);
            // Place the next set of instructions.
            tutorialPanel.sizeDelta = new Vector2(300, 200);
            panelPos = new Vector2(0f, 0f);
            tutorialPanel.localPosition = panelPos;
            tutorialText.rectTransform.sizeDelta = new Vector2(280, 195);
            tutorialText.text = "The inhabitants of FlatWorld are called Plant-Eaters. \n\n You can add Plant-Eaters by pressing the ‘Plant Eaters’ " +
                "button found on the Control Panel \n \n Please add three plant eaters now. \n\n NOTICE: Plant-Eaters can only be added in the day time.";
        }
    }

    public void Task4()
    {
        if (task1 && task2 && task3 && task4 ==false)
        {
            task4 = true;

            // Place the next set of instructions.
            tutorialPanel.sizeDelta = new Vector2(450, 140);
            panelPos = new Vector2(0f, -200f);
            tutorialPanel.localPosition = panelPos;
            tutorialText.rectTransform.sizeDelta = new Vector2(435, 135);
            tutorialText.text = "During the day Plant-Eaters move randomly in search of food. \n\n At night they stop moving to sleep. \n \n " +
                "Warning: Plant-Eaters need to eat everyday to survive. \n \n Wait for these Plant-Eaters to die.";
        }
    }

    public void Task5()
    {

        // Place the next set of instructions.
        tutorialPanel.sizeDelta = new Vector2(300, 60);
        panelPos = new Vector2(0f, 0f);
        tutorialPanel.localPosition = panelPos;
        tutorialText.rectTransform.sizeDelta = new Vector2(280, 55);
        tutorialText.text = "Try adding 10 plants to FlatWorld now. \n \n NOTICE: Plants only grow at sunrise.";

    }

    public void Task6()
    {
        task6 = true;

        // Place the next set of instructions.
        tutorialPanel.sizeDelta = new Vector2(400, 150);
        panelPos = new Vector2(0f, 0f);
        tutorialPanel.localPosition = panelPos;
        tutorialText.rectTransform.sizeDelta = new Vector2(395, 145);
        tutorialText.text = "Available game points can be seen on the Control Panel. \n\n Making changes to FlatWorld costs game points. \n\n " +
            "FlatWorld is feeling a little cramped now. \n\n Let's increase the world size.";

    }

    public void Task7()
    {
        achievementPanel.SetActive(true);
        dayCountPanel.SetActive(true);
        // Place the next set of instructions.
        tutorialPanel.sizeDelta = new Vector2(350, 120);
        panelPos = new Vector2(0f, -100f);
        tutorialPanel.localPosition = panelPos;
        tutorialText.rectTransform.sizeDelta = new Vector2(345, 115);
        tutorialText.text = "The Achievment and Day Count Panel can be seen at the bottom of the screen. \n\n Increase the world size to 30 to unlock an achievment.";
    }

    public void Task8()
    {
        upgradePanel.SetActive(true);
        backToMenu.gameObject.SetActive(true);
        
        
        // Place the next set of instructions.
        tutorialPanel.sizeDelta = new Vector2(350, 180);
        panelPos = new Vector2(0f, 0f);
        tutorialPanel.localPosition = panelPos;
        tutorialText.rectTransform.sizeDelta = new Vector2(345, 175);
        tutorialText.text = "Now that you know the basics, will you help the Plant-Eaters to survive? \n \n Be careful in your quest; the game is over if all the Plant-Eaters die!" +
            "\n \n Use the Upgrade Panel to increase your chances of survival.";

    }


}
