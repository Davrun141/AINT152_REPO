using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PondAnimation : MonoBehaviour {

    private SpriteRenderer spriteR;
    public Sprite[] pondSprites;
    public float frameDelay = 1f;
    private int spriteIndex;


	// Use this for initialization
	void Start () {
        spriteR = this.GetComponent<SpriteRenderer>();
        StartCoroutine(AnimationControl());
    }
	
	// Update is called once per frame
	IEnumerator AnimationControl () {
        while (true)
        {
            spriteR.sprite = pondSprites[spriteIndex];
            spriteIndex++;
            if (spriteIndex == pondSprites.Length)
            {
                spriteIndex = 0;
            }
            yield return new WaitForSeconds(frameDelay);
        }
    }
}
