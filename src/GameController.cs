using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    PlayerUI playerUI;

    public double currScore;



    public void Start()
    {
        playerUI = GetComponent<PlayerUI> ();


       currScore = 0;


       SetStats();
    }

    public void Update()
    {
        AddScore();
    }

    // Update is called once per frame
    public void  AddScore()
    {
        //yield return new WaitForSeconds(1f);
        currScore += .01;
        //SetStats();
        
        SetStats();
    }

    public void SetStats()
	{
		playerUI.scoreAmount.text = currScore.ToString("0.##");
	}

}
