using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TragedyMan : MonoBehaviour
{
    Rigidbody2D rgbd2d;
    Vector3 movementVector;
    [SerializeField] public Animator animator;
    [SerializeField] public Animator comedyAnimator;
    [SerializeField] public Animator footAnimator;
    [SerializeField] public GameObject feather;
    [SerializeField] public float movementspeed;

    bool killed = false;

    private void Awake()
    {
        rgbd2d = GetComponent<Rigidbody2D>();
        movementVector = new Vector3();
    }

    // Update is called once per frame
    void Update()
    {
        //animator.SetBool("Armed", false);  

        movementVector.x = Input.GetAxisRaw("Horizontal");
        if (movementVector.x == 0 )
        {
            animator.SetBool("Moving", false);
        } else
        {
            animator.SetBool("Moving", true);
        }
        if (movementVector.x < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        } else if(movementVector.x > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        movementVector *= movementspeed;
        rgbd2d.velocity = movementVector;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Knife")
        {
            Destroy(collision.gameObject);
            animator.SetBool("Armed", true);
        }
        if(collision.gameObject.tag == "Feet" && !killed)
        {
            killed = true;
            footAnimator.SetBool("Alive", false);
            Destroy(feather);
            comedyAnimator.SetBool("SAD", true);
        }
    }


}
