using UnityEngine;

public class Obstacle : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>() != null)
            GAME_MANAGER.instance.GameOver();
    }
}
