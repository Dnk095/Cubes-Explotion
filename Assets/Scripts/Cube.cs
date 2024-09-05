using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(MeshRenderer))]
public class Cube : MonoBehaviour
{
    [SerializeField] private ParticleSystem _effect;
    [SerializeField] private float _chanceSpawn;
    [SerializeField] private float _multiple;

    private Rigidbody _rigidbody;

    private Material _material;

    public float ChanceSpawn => _chanceSpawn;

    public float Multiple => _multiple;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _material = GetComponent<MeshRenderer>().material;
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    public void Explode(Vector3 position, float force, float radius)
    {
        _rigidbody.AddExplosionForce(force, position, radius);
    }

    public void Init()
    {
        int divider = 2;

        _chanceSpawn /= divider;

        transform.localScale /= divider;

        _material.color = new Color(Random.value, Random.value, Random.value);

        _multiple *= divider;
    }

    public void Explode(float force, float radius)
    {
        float delay = 1f;

        ParticleSystem explodeEffect = Instantiate(_effect, transform.position, transform.rotation);

        Destroy(explodeEffect.gameObject, delay);
    }
    }
