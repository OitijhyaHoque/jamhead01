using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 5f;

    Vector2 movement;
    public Rigidbody2D rb;

    public Animator animator;
    


    // Update is called once per frame
    void Update()
    {

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        
       
        
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("MoveSpeed", movement.sqrMagnitude);
    }

    private void FixedUpdate()
    {
     rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime * PlayerPrefs.GetFloat("sense", 0.5f));
    }
}
