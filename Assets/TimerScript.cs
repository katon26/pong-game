using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public int counter = 30; //variable counter
    public string gameOver = "Game Over!";
    public Text timerText;
    void Start()
    {
        // timerText.text = gameOver.ToString();
        timerText.text = counter.ToString();
        StartCoroutine(hitungmundur());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator hitungmundur(){
        while(counter>0){
			yield return new WaitForSeconds(1);
			counter -= 1;
			timerText.text = counter.ToString();
        }
		
		SceneManager.LoadScene("GameOverScene");
    }
}
