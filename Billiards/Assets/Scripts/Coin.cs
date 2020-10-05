using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>() != null)
        {
            GAME_MANAGER.instance.AddScore(1);
            AudioManager.instance.Play("CoinPick");
            Destroy(gameObject);
        }
    }
}
