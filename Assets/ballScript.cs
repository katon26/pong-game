using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballScript : MonoBehaviour
{
    // public int speed = 30;
	
	public GameObject masterScript;
	
	public Animator animtr;
    // Start is called before the first frame update

    void Start()
    {
		int x = Random.Range(0, 2) * 2 - 1; // can return a value between -1 and 1
		int y = Random.Range(0, 2) * 2 - 1; // can return a value between -1 and 1
        int speed = Random.Range(16, 22); // speed value between 16 and 21
		GetComponent<Rigidbody2D>().velocity = new Vector2(x, y) * speed;
		GetComponent<Transform>().position = Vector2.zero;
		animtr.SetBool("isMove", true);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
		
		if(GetComponent<Rigidbody2D>().velocity.x > 0){ // Kecepatan bola bergerak ke kanan
			GetComponent<Rigidbody2D>().GetComponent<Transform>().localScale = new Vector3((float)0.3, (float)0.3, (float)0.5);
		}else{
			GetComponent<Rigidbody2D>().GetComponent<Transform>().localScale = new Vector3((float)-0.3, (float)0.3, (float)0.5);
		}
		
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.name == "WallVertical" || other.collider.name == "WallVertical1"){
			/* masterScript.GetComponent<ScoringScript>().UpdateScore(other.collider.name); */
			StartCoroutine(jeda()); // move the ball to center
        }
    }
	
	IEnumerator jeda(){
		GetComponent<Rigidbody2D>().velocity = Vector2.zero; // stop the ball
		animtr.SetBool("isMove", false); // change fire animation from move to steady
		GetComponent<Rigidbody2D>().GetComponent<Transform>().position = Vector2.zero; // change ball position
		
		yield return new WaitForSeconds(1);
		
		int x = Random.Range(0, 2) * 2 - 1; // can return a value between -1 or 1
		int y = Random.Range(0, 2) * 2 - 1; // can return a value between -1 or 1
		int speed = Random.Range(16, 22); // speed value between 16 and 21 
		GetComponent<Rigidbody2D>().velocity = new Vector2(x, y) * speed; // set speed
		animtr.SetBool("isMove", true); //  change fire animation from steady to moving left/right
	}
}


