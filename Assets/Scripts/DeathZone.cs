using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathZone : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            restartLevel();
        }
    }

    public void restartLevel()
    {
        
       SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }

}