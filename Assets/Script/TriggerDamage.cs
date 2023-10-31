using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDamage : MonoBehaviour
{
    public HeartSystem heart;
    public player1 player;

    [SerializeField] private float knockbackForce = 5f;
    private bool canDamage = true; // Variável de controle

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && canDamage)
        {
            canDamage = false; // Impede novas colisões temporariamente
            heart.vida--;
            player.animator.SetTrigger("damage");

            // Calcule a direção do knockback (do jogador para o inimigo)
            Vector2 knockbackDirection = (player.transform.position - transform.position).normalized;

            // Aplique a força de knockback no jogador
            player.ApplyKnockback(knockbackDirection * knockbackForce);

            // Agende uma chamada para reativar a detecção de colisão após um atraso
            StartCoroutine(ResetCanDamage());
        }
    }

    // Agendar uma chamada para reativar a detecção de colisão após um atraso
    IEnumerator ResetCanDamage()
    {
        yield return new WaitForSeconds(1.0f); // Ajuste o tempo de acordo com suas necessidades
        canDamage = true; // Permite novas colisões
    }
}
