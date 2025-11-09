using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    //Health Variables
    public float maxHealth = 100f;
    public float currentHealth;
    public Slider healthSlider;

    //Hunger Variables
    public float maxHunger = 100f;
    public float currentHunger;
    public float hungerDeplitionRate = 0.5f;
    public float hungerDamageRate = 2f;
    public Slider hungerSlider;

    //Thrust Variables
    public float maxThrust = 100f;
    public float currentThrust;
    public float thrustDeplitionRate = 1f;
    public float thrustDamageRate = 3f;
    public Slider thrustSlider;


    void Start()
    {
        //Start Variable
        currentHealth = maxHealth;
        currentHunger = maxHunger;
        currentThrust = maxThrust;

        //Start Method
        UpdateAllBar();
    }

    void Update()
    {
        //Using Time.deltaTime to make sure the depletion is frame rate independent
        currentHunger -= hungerDeplitionRate * Time.deltaTime;
        currentThrust -= thrustDeplitionRate * Time.deltaTime;

        //Clamping values to ensure they stay within valid ranges
        currentHunger = Mathf.Clamp(currentHunger, 0, maxHunger);
        currentThrust = Mathf.Clamp(currentThrust, 0, maxThrust);

        if (currentHunger <= 0)
        {
            TakeDamage(hungerDamageRate * Time.deltaTime);
        }

        if (currentThrust <= 0)
        {
            TakeDamage(thrustDamageRate * Time.deltaTime);
        }
        
        UpdateAllBar(); //Because we ant to show the deplition in real time

        //Test Inputs
        if (Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(10);
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            Heal(10);
        }
        
        if (Input.GetKeyDown(KeyCode.J))
        {
            Eat(20);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            Drink(30);
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(float amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
    }

    public void Eat(float amount)
    {
        currentHunger += amount;
        currentHunger = Mathf.Clamp(currentHunger, 0, maxHunger);
    }

    public void Drink(float amount)
    {
        currentThrust += amount;
        currentThrust = Mathf.Clamp(currentThrust, 0, maxThrust);
    }

    void UpdateAllBar()
    {
        if (healthSlider != null)
        {
            healthSlider.value = currentHealth / maxHealth;
        }

        if (hungerSlider != null)
        {
            hungerSlider.value = currentHunger / maxHunger;
        }
        
        if(thrustSlider != null)
        {
            thrustSlider.value = currentThrust / maxThrust;
        }
    }

    void Die()
    {
        Debug.Log("Player has died.");
    }
}
