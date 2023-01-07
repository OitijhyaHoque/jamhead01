using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    // Start is called before the first frame update

    public LineRenderer laserSight;

    public int reflection; //how many reflections we want
    public float maxRayDistance;
    public LayerMask layerDetection;
    public DestinationScript dest;
    public string color = "blue";

    bool hitDest = false;
    void Start()
    {
        Physics2D.queriesStartInColliders = false;
        dest = GameObject.FindGameObjectWithTag("destination").GetComponent<DestinationScript>();
    }

    // Update is called once per frame
    void Update()
    {
        laserSight.positionCount = 1;
        laserSight.SetPosition(0, transform.position);

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.right, maxRayDistance, layerDetection);

        bool isMirror = false;
        Vector2 mirrorHitPoint = Vector2.zero;
        Vector2 mirrorHitNormal = Vector2.zero;

        

        

        for(int i  = 0; i<reflection; i++)
        {
            laserSight.positionCount += 1;

            if(hitInfo.collider != null)
            {
                laserSight.SetPosition(laserSight.positionCount - 1, hitInfo.point);
                isMirror = false;

                //Debug.Log("laser hit");

                if (hitInfo.collider.CompareTag("Mirror"))
                {
                    mirrorHitPoint = (Vector2)hitInfo.point;
                    mirrorHitNormal = (Vector2)hitInfo.normal;
                    hitInfo = Physics2D.Raycast((Vector2)hitInfo.point, Vector2.Reflect(hitInfo.point, hitInfo.normal), maxRayDistance, layerDetection);
                    isMirror = true;
                    


                }
                else if(hitInfo.collider.CompareTag("destination"))
                {
                    dest.LaserHit(color);
                    if (hitDest == false)
                    {
                        hitDest = true;
                        Debug.Log("laser dest hit");
                    }
                    
                    break;
                }
                else
                {
                    if(hitDest==true)
                    {
                        dest.laserMiss();
                        hitDest = false;
                        Debug.Log("laser missed diff obj hit");
                    }
                    break;
                }
            }
            else
            {
                if(isMirror)
                {
                    laserSight.SetPosition(laserSight.positionCount - 1, mirrorHitPoint + Vector2.Reflect(mirrorHitPoint , mirrorHitNormal)* maxRayDistance);
                    if (hitDest == true)
                    {
                        dest.laserMiss();
                        hitDest = false;
                        Debug.Log("laser missed mirr");
                    }
                    

                    break;
                }
                else
                {
                    laserSight.SetPosition(laserSight.positionCount - 1, transform.position + transform.right * maxRayDistance);

                    if (hitDest == true)
                    {
                        dest.laserMiss();
                        hitDest = false;
                        Debug.Log("laser missed non");
                    }

                    break;
                }
            }
            
            
            
        }
    }
}
