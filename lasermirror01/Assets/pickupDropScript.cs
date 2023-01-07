using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupDrop : MonoBehaviour
{
    public Transform holdSpot;
    public LayerMask pickLayer;

    private GameObject itemHold;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (itemHold)
            {

            }
            else
            {
                Collider2D pickItem = Physics2D.OverlapCircle(transform.position, 0.4f, pickLayer);

                if (pickItem)
                {
                    itemHold = pickItem.gameObject;
                    itemHold.transform.position = holdSpot.position;
                    itemHold.transform.parent = transform;

                    if (itemHold.GetComponent<Rigidbody2D>())
                        itemHold.GetComponent<Rigidbody2D>().simulated = false;
                }
            }
        }
    }
}