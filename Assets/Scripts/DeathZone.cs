using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Player>().enabled = false;

            if (GameManager.Instance != null)
            {
                GameManager.Instance.ShowLoseScreen();
            }
            else
            {
                Debug.LogWarning("GameManager.Instance is null in DeathZone!");
            }
        }
    }
}
