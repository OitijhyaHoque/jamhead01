using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationScript : MonoBehaviour
{
    public LogicScript logic;
    public string destColor= "blue";
    public bool laserHit = false;
    public int timer = 0; //laser hit for a duration
    public bool hitThisLevel =false; //destination will trigger only once in a level

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
            
    }
    public void FixedUpdate()
    {
        if (laserHit == true)
        {
            if (timer >150)
            {
                logic.levelComplete();
                timer = 0;
                laserHit = false;
            }
            else
            {
                timer++;
            }

        }
    }

    public void LaserHit(string color)
    {
        if(color == destColor && hitThisLevel ==false)
        {

            laserHit = true;
            hitThisLevel = true; //must be made false from the next level button script
        }
    }
    public void laserMiss() //hit once but missed immediately
    {
        Debug.Log("miss func called");
        laserHit = false;
        hitThisLevel = false;
        timer = 0;
    }
    
}
