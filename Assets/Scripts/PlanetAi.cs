using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public Text healthText;
    public int health;
    public int maxHealth = 100;

    void Start()
    {
        healthText.text = $"hp: {health}";
    }

    public void Damage(int damageAmmount)
    {
        if(health - damageAmmount < 0)
        {
            health = 0;
        }
        else
        {
            health -= damageAmmount;
        }
        healthText.text = "hp:" + health;
    }
    public void Heal(int healAmmount)
    {
        if(health + healAmmount > maxHealth)
        {
            health = maxHealth;
        }
        else
        {
            health += healAmmount;
        }
        healthText.text = "hp:" + health;
    }
}
