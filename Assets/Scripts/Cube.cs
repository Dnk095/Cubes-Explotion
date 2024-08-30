using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(MeshRenderer))]
public class Cube : MonoBehaviour
{
    [SerializeField] private float _chanceSpawn;

    public float ChanceSpawn => _chanceSpawn;

    private Rigidbody _rigidbody;

    private Material _material;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _material = GetComponent<MeshRenderer>().material;
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    public void ReduceChance(float chance)
    {
        int divider = 2;
        _chanceSpawn = chance /= divider;
    }

    public void ExplotionForce(float force, float radius)
    {
        _rigidbody.AddExplosionForce(force, transform.position, radius);
    }

    public void Paint()
    {
        _material.color = new Color(Random.value, Random.value, Random.value);
    }
}
