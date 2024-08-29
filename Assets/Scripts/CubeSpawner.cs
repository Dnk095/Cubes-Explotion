using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _cubePrefab;
    [SerializeField] private Raycaster _raycaster;
    [SerializeField] private float _explodeRadius;
    [SerializeField] private float _explodeForce;

    private List<GameObject> _gameObjects;

    private float _chanceSpawn = 100f;

    private void OnEnable()
    {
        _raycaster.UseMouseOnObject += OnUseMouseOnObject;
    }

    private void OnDisable()
    {
        _raycaster.UseMouseOnObject -= OnUseMouseOnObject;
    }

    private void OnUseMouseOnObject()
    {
        float minChaceSpawn = 0f;
        float maxChaceSpawn = 100f;

        if (gameObject == _raycaster.Hit.collider.gameObject)
        {
            if (Random.Range(minChaceSpawn, maxChaceSpawn + 1) <= _chanceSpawn)
            {
                Spawn();
                ExplotionForce();
            }

            Destroy(gameObject);
        }
    }

    private void Spawn()
    {
        int minQuantity = 2;
        int maxQuantity = 6;
        int quantityCubes = Random.Range(minQuantity, maxQuantity + 1);

        for (int i = 0; i < quantityCubes; i++)
            CreateNewCube();
    }

    private GameObject CreateNewCube()
    {
        _gameObjects = new List<GameObject>();

        GameObject newCube = Instantiate(_cubePrefab);

        newCube.GetComponent<CubeSpawner>()._chanceSpawn /= 2;
        newCube.transform.localScale /= 2;
        newCube.GetComponent<MeshRenderer>().material.color = new Color(Random.value, Random.value, Random.value);

        _gameObjects.Add(newCube);

        return newCube;
    }

    private void ExplotionForce()
    {
        foreach (GameObject obj in _gameObjects)
            obj.GetComponent<Rigidbody>().AddExplosionForce(_explodeForce, transform.position, _explodeRadius);
    }
}
