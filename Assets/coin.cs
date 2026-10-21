using UnityEngine;

public class coin : MonoBehaviour
{
    private bool collected = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collected) return;

        if(collision.CompareTag("Player"))
        {
            platform player = collision.GetComponent<platform>();
            if (player == null) return;

            collected = true;
            player.coinCollected++;
            Debug.Log("Cherries collected!");
            Debug.Log("Player score: " + player.coinCollected);
            Destroy(gameObject);
        }
    }
}
