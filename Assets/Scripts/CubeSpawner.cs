using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private float _explodeRadius;
    [SerializeField] private float _explodeForce;

    private List<Cube> _createdCubs;

    private void Awake()
    {
        _createdCubs = new List<Cube>();
    }

    public void Spawn(Cube cube)
    {
        int minChaceSpawn = 0;
        int maxChaceSpawn = 100;

        if (Random.Range(minChaceSpawn, maxChaceSpawn + 1) <= cube.ChanceSpawn)
        {
            int minQuantity = 2;
            int maxQuantity = 6;
            int quantityCubes = Random.Range(minQuantity, maxQuantity + 1);

            for (int i = 0; i < quantityCubes; i++)
                CreateCube(cube);

            ExplotionForce();

            _createdCubs.Clear();
        }

        cube.Destroy();
    }

    private Cube CreateCube(Cube cube)
    {
        int divider = 2;

        Cube newCube = Instantiate(cube, cube.transform.position, cube.transform.rotation);

        newCube.transform.localScale = cube.transform.localScale / divider;
        newCube.ReduceChance(cube.ChanceSpawn);
        newCube.Paint();

        _createdCubs.Add(newCube);

        return newCube;
    }

    private void ExplotionForce()
    {
        foreach (Cube cube in _createdCubs)
            cube.ExplotionForce(_explodeForce, _explodeRadius);
    }
}