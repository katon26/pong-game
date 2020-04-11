using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballScript : MonoBehaviour
{
    public int speed = 30;

	public Animator animtr;
    // Start is called before the first frame update

    void Start()
    {
        Debug.Log("hello world");
        GetComponent<Rigidbody2D>().velocity = new Vector2(1, -1) * speed;
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
			StartCoroutine(jeda());
		  //GetComponent<Transform>().position = new Vector2(0, 0);
        }
    }
	
	IEnumerator jeda(){
		GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		animtr.SetBool("isMove", false);
		GetComponent<Rigidbody2D>().GetComponent<Transform>().position = Vector2.zero;
		yield return new WaitForSeconds(1);
		GetComponent<Rigidbody2D>().velocity = new Vector2(-1,-1) * speed;
		animtr.SetBool("isMove", true);
	}
}


