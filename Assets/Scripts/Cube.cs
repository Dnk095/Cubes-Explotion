using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(MeshRenderer))]
public class Cube : MonoBehaviour
{
    [SerializeField] private float _chanceSpawn;
    [SerializeField] private float _multiple;
    [SerializeField] private float _explodeRadius;
    [SerializeField] private float _explodeForce;

    private Rigidbody _rigidbody;

    private Material _material;

    public float ChanceSpawn => _chanceSpawn;

    public float Multiple => _multiple;

    public float ExplodeRadius => _explodeRadius;

    public float ExplodeForce => _explodeForce;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _material = GetComponent<MeshRenderer>().material;
    }

    public void REDFt(out bool _canSpawn)
    {
        _canSpawn = false;

        int minChaceSpawn = 0;
        int maxChaceSpawn = 100;

        if (Random.Range(minChaceSpawn, maxChaceSpawn + 1) <= _chanceSpawn)
            _canSpawn = true;      
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    public void AddForce(Vector3 position, float force, float radius)
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
}
