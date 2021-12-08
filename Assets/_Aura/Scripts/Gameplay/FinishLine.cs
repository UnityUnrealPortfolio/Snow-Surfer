using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class handles the behaviour of the Finish line Game Object
/// such as spawning particle effects when crossed and triggering
/// win sound FX from the Audio Manager
/// </summary>
public class FinishLine : MonoBehaviour
{
    [Header("Particle Prefabs")]
    [SerializeField] GameObject winPFX;

    private void OnTriggerExit2D(Collider2D other)
    {
        if (winPFX != null)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                var pfx = Instantiate(winPFX, transform.position, Quaternion.identity);
                Destroy(pfx,2f);
            }
        }
    }
}
