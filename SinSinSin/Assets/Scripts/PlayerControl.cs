using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

    //Public anim vars
    public float animSpeed = 0.2f;
    public Sprite[] walkSprites;
    //Public movement vars
    public float rotationModifier = 1;
    public float movementModifier = 1;

    //animation vars
    private SpriteRenderer spriteR;
    private int spriteIndex;
    private bool animRunning = false;
    private IEnumerator animCoroutine;
    private Sprite idleSprite;
    //movement vars
    private Rigidbody2D RB2D;
    

    // Use this for initialization
    void Start()
    {
        //anim initiation
        spriteR = this.GetComponent<SpriteRenderer>();
        idleSprite = spriteR.sprite;

        //movement initiation
        RB2D = this.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        #region walk control
        //get number of directional keys pressed

        if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            //turn left
            RB2D.transform.Rotate(0, 0, rotationModifier);
        }
        if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            RB2D.transform.Rotate(0, 0, -rotationModifier);
        }

        if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
        {
            //move
            RB2D.transform.position += transform.up * Time.deltaTime * movementModifier;
            //check anim status
            if (animRunning == false)
            {
                animRunning = true;
                animCoroutine = WalkForward();
                StartCoroutine(animCoroutine);
            }
        }

        if (Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W))
        {
            //move
            RB2D.transform.position -= transform.up * Time.deltaTime * movementModifier;
            //check anim status
            if (animRunning == false)
            {
                animRunning = true;
                animCoroutine = WalkForward();
                StartCoroutine(animCoroutine);
            }
        }

        //if coroutine runnning and no keys pressed, stop it.
        if (animRunning == true && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
        {
            animRunning = false;
            StopCoroutine(animCoroutine);
            spriteR.sprite = idleSprite;
        }
        #endregion
    }


    IEnumerator WalkForward()
    {
        while (true)
        {
            spriteR.sprite = walkSprites[spriteIndex];
            yield return new WaitForSeconds(animSpeed);
            spriteIndex++;
            if (spriteIndex == walkSprites.Length)
            {
                spriteIndex = 0;
            }
        }
    }
}
