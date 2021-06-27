using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class GetHitByEnemy : MonoBehaviour
{
    [SerializeField] private AudioClip PlayClip;

    [SerializeField] private GameObject healthbarObject;
    private HealthBar healthBar;

    [SerializeField] private GameObject gameOverMenu;
    private GameOverHandler gameOverHandler;

    [SerializeField] private int maxHealth = 100;
    private int currentHealth;
   

    void Start()
    {
        healthBar = healthbarObject.GetComponent<HealthBar>();
        gameOverHandler = gameOverMenu.GetComponent<GameOverHandler>();

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void OnCollisionEnter(Collision collision)
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = PlayClip;

        Debug.Log(collision.gameObject.tag);

        switch (collision.gameObject.tag)
        {
            case "Goonki":
                TakeDamage(5);
                audio.Play();
                break;

            case "Krillon":
                TakeDamage(20);
                audio.Play();
                break;

            case "Nomu":
                TakeDamage(30);
                audio.Play();
                break;

            default:
                //dit doet niks
                break;
        }

        if (currentHealth != 0) { return; }

        audio.Play();
        gameOverHandler.StartGameOver();
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
}
