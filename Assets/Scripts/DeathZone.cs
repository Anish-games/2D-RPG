using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathZone : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    
    void Start()
    {

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    // Update is called once per frame
    void Update()
    {

        
    }
}
