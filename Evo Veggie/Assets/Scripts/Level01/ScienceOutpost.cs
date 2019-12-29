using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScienceOutpost : MonoBehaviour
{
    private float timer = 0f;
    public int researchPoints = 0;
    public Transform plus1;
    public Transform p;
    public Vector3 targetPOS;
    public bool plus1IsActive = false;
    public int plus1Speed = 3;
    public Vector3 hidePOS;
    public int researchPointsSpeed = 10;
    public AudioClip pointsGained;

    // Start is called before the first frame update
    void Start()
    {
        targetPOS = new Vector3(GameObject.Find("Game").GetComponent<GameMain>().worldSize + 1, 10f, GameObject.Find("Game").GetComponent<GameMain>().worldSize / 2);

        // Hide the plus1 transform.
        p = Instantiate(plus1);
        hidePOS = new Vector3(100f, 100f, 100f);
        p.position = hidePOS;
        
    }

    // Update is called once per frame
    void Update()
    {
        // Start the timer that keeps track of firing.
        timer += Time.deltaTime;

        if (timer >= researchPointsSpeed)
        {
            AudioSource.PlayClipAtPoint(pointsGained, transform.position);
            researchPoints += 1;
            GameObject.Find("Game").GetComponent<GameMain>().UpdateResearchPoints();
            timer = 0;
            Vector3 aboveOutpostPosition = new Vector3(GameObject.Find("Game").GetComponent<GameMain>().worldSize + 1, 3f, GameObject.Find("Game").GetComponent<GameMain>().worldSize / 2);
            p.position = aboveOutpostPosition;
            plus1IsActive = true;
        }

        if (plus1IsActive)
        {
            // Move our position a step closer to the target.
            targetPOS = new Vector3(GameObject.Find("Game").GetComponent<GameMain>().worldSize + 1, 10f, GameObject.Find("Game").GetComponent<GameMain>().worldSize / 2);
            float step = plus1Speed * Time.deltaTime; // calculate distance to move
            p.position = Vector3.MoveTowards(p.position, targetPOS, step);

            if (Vector3.Distance(p.position, targetPOS) < 1) plus1IsActive = false;
        }

        else if (plus1IsActive == false && Vector3.Distance(p.position, hidePOS) > 1)
        {
            p.position = hidePOS;
        }
    }

    public void UpdateOutpostPosition()
    {
        Vector3 outpostPosition = new Vector3(GameObject.Find("Game").GetComponent<GameMain>().worldSize + 1, 1.8f, GameObject.Find("Game").GetComponent<GameMain>().worldSize / 2);
        transform.localPosition = outpostPosition;
    }
}
