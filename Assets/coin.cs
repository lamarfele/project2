using UnityEngine;

public class coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            platform player = collision.GetComponent<platform>();
            player.coinCollected++;
            Debug.Log("coin collected!");
            Debug.Log("Player score:" +player.coinCollected);
            Destroy(gameObject);
        }
    }
}
