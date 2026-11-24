
using UnityEngine;

public class Guard : MonoBehaviour
{
    [Header("Guard Settings")]
    [SerializeField] float speed = 3f;
    [SerializeField] float chaseRange = 7f;
    [SerializeField] float stopDistance = 1.5f;

    [Header("Damage Settings")]
    [SerializeField] int damage = 1;

    [Header("3D Guard Sound")]
    [SerializeField] float soundVolume = 1f;
    [SerializeField] float minDistance = 2f;
    [SerializeField] float maxDistance = 12f;

    Transform player;
    Rigidbody rb;
    AudioSource guardAudio;

    Material blackMaterial;
    Material redMaterial;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        GameObject playerObject =
            GameObject.FindGameObjectWithTag("Player");

        if (playerObject != null)
        {
            player = playerObject.transform;
        }
        else
        {
            Debug.LogError("Player tag not found!");
        }

        CreateCharacter();
        SetupGuardSound();
    }

    void SetupGuardSound()
    {
        if (SfxPlayer.Instance == null)
            return;

        AudioClip clip = SfxPlayer.Instance.GetGuardSound();

        if (clip == null)
            return;

        guardAudio = gameObject.AddComponent<AudioSource>();

        guardAudio.clip = clip;
        guardAudio.playOnAwake = false;
        guardAudio.loop = true;
        guardAudio.volume = soundVolume;

        guardAudio.spatialBlend = 1f;
        guardAudio.rolloffMode = AudioRolloffMode.Logarithmic;
        guardAudio.minDistance = minDistance;
        guardAudio.maxDistance = maxDistance;

        guardAudio.Play();
    }

    void CreateCharacter()
    {
        MeshRenderer bodyRenderer = GetComponent<MeshRenderer>();

        if (bodyRenderer != null)
        {
            blackMaterial = bodyRenderer.sharedMaterial;
        }

        if (blackMaterial == null)
        {
            blackMaterial = CreateMaterial(Color.black);
        }

        redMaterial = CreateMaterial(Color.red);

        if (redMaterial.HasProperty("_EmissionColor"))
        {
            redMaterial.EnableKeyword("_EMISSION");
            redMaterial.SetColor(
                "_EmissionColor",
                Color.red * 3f
            );
        }

        CreatePart(
            PrimitiveType.Sphere,
            "Head",
            new Vector3(0f, 0.85f, 0f),
            new Vector3(0.7f, 0.7f, 0.7f),
            blackMaterial
        );

        CreatePart(
            PrimitiveType.Sphere,
            "Left Eye",
            new Vector3(-0.17f, 0.95f, 0.40f),
            new Vector3(0.19f, 0.19f, 0.13f),
            redMaterial
        );

        CreatePart(
            PrimitiveType.Sphere,
            "Right Eye",
            new Vector3(0.17f, 0.95f, 0.40f),
            new Vector3(0.19f, 0.19f, 0.13f),
            redMaterial
        );

        CreatePart(
            PrimitiveType.Capsule,
            "Left Arm",
            new Vector3(-0.58f, 0.05f, 0f),
            new Vector3(0.23f, 0.60f, 0.23f),
            blackMaterial,
            new Vector3(0f, 0f, 90f)
        );

        CreatePart(
            PrimitiveType.Capsule,
            "Right Arm",
            new Vector3(0.58f, 0.05f, 0f),
            new Vector3(0.23f, 0.60f, 0.23f),
            blackMaterial,
            new Vector3(0f, 0f, -90f)
        );

        CreatePart(
            PrimitiveType.Cube,
            "Left Foot",
            new Vector3(-0.2f, -0.75f, 0.05f),
            new Vector3(0.3f, 0.2f, 0.4f),
            blackMaterial
        );

        CreatePart(
            PrimitiveType.Cube,
            "Right Foot",
            new Vector3(0.2f, -0.75f, 0.05f),
            new Vector3(0.3f, 0.2f, 0.4f),
            blackMaterial
        );
    }

    Material CreateMaterial(Color color)
    {
        Shader shader = Shader.Find("Universal Render Pipeline/Lit");

        if (shader == null)
            shader = Shader.Find("Standard");

        Material mat = new Material(shader);
        mat.color = color;

        return mat;
    }

    void CreatePart(
        PrimitiveType type,
        string partName,
        Vector3 position,
        Vector3 scale,
        Material material,
        Vector3 rotation = default)
    {
        GameObject part = GameObject.CreatePrimitive(type);

        part.name = partName;
        part.transform.SetParent(transform, false);

        part.transform.localPosition = position;
        part.transform.localScale = scale;
        part.transform.localRotation =
            Quaternion.Euler(rotation);

        Destroy(part.GetComponent<Collider>());

        part.GetComponent<MeshRenderer>().sharedMaterial =
            material;
    }

    void FixedUpdate()
    {
        if (player == null || rb == null)
            return;

        Vector3 direction = player.position - rb.position;
        direction.y = 0f;

        float distance = direction.magnitude;

        if (distance <= chaseRange && distance > stopDistance)
        {
            Vector3 moveDirection = direction.normalized;

            Vector3 velocity = rb.linearVelocity;

            velocity.x = moveDirection.x * speed;
            velocity.z = moveDirection.z * speed;

            rb.linearVelocity = velocity;

            rb.MoveRotation(
                Quaternion.LookRotation(moveDirection)
            );
        }
        else
        {
            Vector3 velocity = rb.linearVelocity;

            velocity.x = 0f;
            velocity.z = 0f;

            rb.linearVelocity = velocity;
        }
    }

    void OnCollisionStay(Collision collision)
    {
        Health health =
            collision.collider.GetComponentInParent<Health>();

        if (health != null)
        {
            health.TakeDamage(damage);
        }
    }
}
