using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
	PlayerUI playerUI;
	
	public float currHealth;
	public float maxHealth;
	
	public float currStamina;
	public float maxStamina;
	
	public bool isDead = false;
	

	
	void Start()
	{
		playerUI = GetComponent<PlayerUI> ();
		
		maxHealth = 100;
		currHealth = maxHealth;
		
		maxStamina = 100;
		currStamina = maxStamina;
		
		SetStats();
	}
	
	public void TakeDamage()
	{
        //Debug.Log("-1");
		currHealth -= 1;
        //SetStats();
	}	
	
	public void Die()
	{
		Debug.Log("You Died!");
		
	}
	
	void SetStats()
	{
		playerUI.healthAmount.text = currHealth.ToString();
		playerUI.staminaAmount.text = currStamina.ToString();
	}
	public void CheckHealth(){
		if (currHealth >= maxHealth){
			currHealth = maxHealth;
		}
		if (currHealth <= 0){
			currHealth = 0;
			SceneManager.LoadScene(SceneManager.GetActiveScene().name); //ENDING GAME WHEN YOU DIE
			isDead = true;
		}
		SetStats();
	}
	
	public void CheckStamina(){
		if (currStamina >= maxStamina){
			currStamina = maxStamina;
		}
		if (currStamina <= 0){
			currStamina = 0;
		}
		SetStats();
	}
}