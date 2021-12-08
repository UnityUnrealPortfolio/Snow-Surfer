using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Handles the crash events such as playing the crash vfx and 
/// alerting the Gamemanager that player has crashed.
/// </summary>
public class CrashBehaviour : MonoBehaviour
{
    [Header("Crash Partice Prefabs")]
    [SerializeField] GameObject crashPFX;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            PlayCrashLogic();
            GetComponent<Collider2D>().enabled = false;
        }
    }

    void PlayCrashLogic()
    {
        if (crashPFX != null)
        {
            var pfx = Instantiate(crashPFX,transform.position,Quaternion.identity);
            Destroy(pfx, 1.5f);
        }
        Invoke("ReloadScene", .9f);
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
