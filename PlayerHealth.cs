using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
	public int startingHealth = 100;                            
	public int currentHealth;                                   
	public Slider healthSlider;                                 
	public Image damageImage;                                   
	public float flashSpeed = 5f;                               
	public Color flashColour = new Color(1f, 0f, 0f, 0.1f);     

	CharacterController charController;                             
	bool isDead;                                                
	bool damaged;                                               


	void Awake ()
	{
		charController = GetComponent <CharacterController> ();
		currentHealth = startingHealth;
		damaged = false;
	}


	void Update ()
	{	
		if(damaged)
		{
			damageImage.color = flashColour;
		}
		else
		{
			damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
		}
		damaged = false;
	}


	public void TakeDamage (int amount)
	{
		damaged = true;
		currentHealth -= amount;
		healthSlider.value = currentHealth;
		if(currentHealth <= 0 && !isDead)
		{
			Death ();
		}
	}


	void Death ()
	{
		isDead = true;

		charController.enabled = false;

	}  

	void OnCollisionEnter(Collision col){
		if (col.gameObject.CompareTag ("bullet")) {
			Destroy (col.gameObject);
			TakeDamage(10);
		}
	}
}

