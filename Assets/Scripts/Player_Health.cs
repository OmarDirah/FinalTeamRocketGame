﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player_Health : MonoBehaviour {
    public int maxHealth = 100;
    public int currentHealth = 0;
	public Text textHealth;

    // Use this for initialization
    void Start()
    {
		if (PlayerPrefs.GetInt ("Player Health") != null) {
			currentHealth = PlayerPrefs.GetInt ("Player Health");
			//PlayerPrefs.DeleteKey ("Player Health");
		} else {
			// everyone starts at 100% health at the start
			currentHealth = maxHealth;
		}
    }
	void Update(){
		textHealth.text = "Health: " + currentHealth + "%";
	}

    // notice we made this a public function; thats so death trigger can use it

    public void Hurt(int damage)
    {

       
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
		if (currentHealth <= 0)
		{
			//Destroy(gameObject);
			//move to the game over screen
			SceneManager.LoadScene(1);
		}
    }
	public int GetHealth(){
		return currentHealth;
	}
}
