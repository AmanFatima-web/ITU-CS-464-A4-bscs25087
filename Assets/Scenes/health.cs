
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int max = 3;
    [SerializeField] float iFrames = 1f;

    [Header("Heart Rotation")]
    [SerializeField] float rotationSpeed = 90f;

    [Header("Damage Particle")]
    [SerializeField] GameObject damageParticle;
    [SerializeField] Vector3 particleOffset = new Vector3(0f, 1f, 0f);

    public bool shielded;

    int current;
    float invulnerableUntil;

    public int Current => current;
    public int Max => max;

    void Awake()
    {
        current = max;
    }

    void Update()
    {
        transform.Rotate(
            0f,
            rotationSpeed * Time.deltaTime,
            0f
        );
    }

    public bool TakeDamage(int amount)
    {
        if (current <= 0 || Time.time < invulnerableUntil)
            return false;

        if (shielded)
        {
            shielded = false;
            invulnerableUntil = Time.time + iFrames;
            return false;
        }

        invulnerableUntil = Time.time + iFrames;
        current = Mathf.Max(0, current - amount);

        // DAMAGE PARTICLE
        Debug.Log("DAMAGE PARTICLE TRIGGERED");

        if (damageParticle != null)
        {
            GameObject effect = Instantiate(
                damageParticle,
                transform.position + particleOffset,
                Quaternion.identity
            );

            Debug.Log("Damage particle created successfully!");

            Destroy(effect, 3f);
        }
        else
        {
            Debug.LogError("Damage Particle is NOT assigned in Health Inspector!");
        }

        // DAMAGE SOUND
        if (SfxPlayer.Instance != null)
            SfxPlayer.Instance.PlayDamageSound();

        // UPDATE UI
        if (GameManager.Instance != null)
        {
            GameManager.Instance.UpdateUI();

            if (current <= 0)
                GameManager.Instance.PlayerDied();
        }

        return true;
    }

    public void Restore(float protection)
    {
        current = max;
        invulnerableUntil = Time.time + protection;

        if (GameManager.Instance != null)
            GameManager.Instance.UpdateUI();
    }

    public void RestoreOne(float protection)
    {
        current = Mathf.Min(current + 1, max);
        invulnerableUntil = Time.time + protection;

        if (GameManager.Instance != null)
            GameManager.Instance.UpdateUI();
    }
}
