using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

[AddComponentMenu("Playground/Attributes/Health System")]
public class HealthSystemAttribute : MonoBehaviour
{
	public int health = 10;

	private UIScript ui;
	private int maxHealth;

	// Will be set to 0 or 1 depending on how the GameObject is tagged
	// it's -1 if the object is not a player
	private int playerNumber;

	private float loseEveryXSeconds  = 2f;
	
	
	public bool stuffy = false;
	public bool inDialogue = false;

	

	private void Start()
	{
		// Find the UI in the scene and store a reference for later use
		ui = GameObject.FindObjectOfType<UIScript>();

		// Set the player number based on the GameObject tag
		switch(gameObject.tag)
		{
			case "Player":
				playerNumber = 0;
				break;
			case "Player2":
				playerNumber = 1;
				break;
			default:
				playerNumber = -1;
				break;
		}

		if (AcrossScenes.instance != null) 
		{
			health = AcrossScenes.instance.health;
		}

		// Notify the UI so it will show the right initial amount
		if(ui != null
			&& playerNumber != -1)
		{
			ui.SetHealth(health, maxHealth, playerNumber);
		}

		maxHealth = health; //note down the maximum health to avoid going over it when the player gets healed
		
			InvokeRepeating(nameof(ConstantLoss), loseEveryXSeconds, loseEveryXSeconds);
		
		
	}


    // changes the energy from the player
    // also notifies the UI (if present)
    public void ModifyHealth(int amount)
    {
        //avoid going over the maximum health by forcin
        if (health + amount > maxHealth)
        {
            amount = maxHealth - health;
        }

        health += amount;

        // Notify the UI so it will change the number in the corner
        if (ui != null
            && playerNumber != -1)
        {
            ui.ChangeHealth(amount, maxHealth, playerNumber);
        }

        //DEAD
        if (health <= 0)
        {
            Destroy(gameObject);
        }
		if (AcrossScenes.instance != null) 
		{
			AcrossScenes.instance.health = health;
		}
    }
	
	private void ConstantLoss()
	{
		if (!stuffy && !inDialogue)
		{
			ModifyHealth(-1);
		}

		
	}

}
