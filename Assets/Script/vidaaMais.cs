using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vidaaMais : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Recupere o componente HeartSystem do jogador
            HeartSystem playerHealth = other.GetComponent<HeartSystem>();

            if (playerHealth != null)
            {
                // Regenere a vida do jogador (adicione 1 à vida atual)
                playerHealth.vida++;
                // Destrua o coletável
                Destroy(gameObject);
            }
        }
    }
}
