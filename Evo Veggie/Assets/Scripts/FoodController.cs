using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodController : MonoBehaviour
{
    private Color FedPlantEater = new Color(.1f, 1f, .1f, 1f);
    public AudioClip EatSound;
    public bool colliderActive = false;
    public Animator Anim;

    // Start is called before the first frame update
    void Start()
    {
        // add isTrigger
        var boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = true;
        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check to see if the PlantGrow animation is playing. If it is not, then the tigger should be active.
        if (Anim.GetCurrentAnimatorStateInfo(0).IsName("PlantIdle") && colliderActive == false)
        {
            Debug.Log("Trigger turned true");
            colliderActive = true;

        }
            
        

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("plantEater") && colliderActive)
        {

            colliderActive = false;
            AudioSource.PlayClipAtPoint(EatSound, transform.position);

            // Add plant's position back to food position list. 
            GameObject.Find("Game").GetComponent<GameMain>().foodPositions.Add(transform.localPosition);
            Debug.Log("Add Plant Pos.");
            GameObject.Find("Game").GetComponent<GameMain>().foodList.Remove(transform);
            GameObject.Find("Game").GetComponent<GameMain>().gamePoints += 1;
            GameObject.Find("Game").GetComponent<GameMain>().gamePointsText.text = GameObject.Find("Game").GetComponent<GameMain>().gamePoints.ToString();
            Destroy(transform.gameObject);
            other.GetComponent<PlantEaterContoller>().foodEaten += 1;
            other.transform.GetChild(0).GetChild(0).GetComponent<Renderer>().material.color = FedPlantEater;
        }
        else
        {
            Debug.Log("No Worries");
        }
        
     
       
    }
}
