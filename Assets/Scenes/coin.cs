
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] int value = 1;
    [SerializeField] GameObject collectParticle;

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        Debug.Log("Coin touched by player");

        if (GameManager.Instance != null)
            GameManager.Instance.AddScore(value);
        else
            Debug.LogError("GameManager Instance is NULL!");

        if (SfxPlayer.Instance != null)
            SfxPlayer.Instance.PlayPickupSound();
        else
            Debug.LogError("SfxPlayer Instance is NULL!");

        if (collectParticle != null)
        {
            GameObject effect = Instantiate(
                collectParticle,
                transform.position,
                Quaternion.identity
            );

            Destroy(effect, 2f);
        }

        Destroy(gameObject);
    }
}
