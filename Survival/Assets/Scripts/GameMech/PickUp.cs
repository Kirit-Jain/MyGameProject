using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public enum PickUpType
    {
        Health,
        Hunger,
        Thrust,
    }

    public PickUpType pickUpType;
    public float amount = 25f;


    private void OnTriggerEnter(Collider other)
    {
        PlayerStats playersStats = other.GetComponent<PlayerStats>();

        if(playersStats != null)
        {
            switch (pickUpType)
            {
                case PickUpType.Health:
                    playersStats.Heal(amount);
                    break;
                case PickUpType.Hunger:
                    playersStats.Eat(amount);
                    break;
                case PickUpType.Thrust:
                    playersStats.Drink(amount);
                    break;
            }

            Destroy(gameObject);
        }
    }
}
