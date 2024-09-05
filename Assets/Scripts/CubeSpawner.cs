using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private float _explodeRadius;
    [SerializeField] private float _explodeForce;
    [SerializeField] private ExplodeManager _explodeManager;

    public void Spawn(Cube cube)
    {
        List<Cube> createdCubs = new();

        int minChaceSpawn = 0;
        int maxChaceSpawn = 100;

        if (Random.Range(minChaceSpawn, maxChaceSpawn + 1) <= cube.ChanceSpawn)
        {
            int minQuantity = 2;
            int maxQuantity = 6;
            int quantityCubes = Random.Range(minQuantity, maxQuantity + 1);

            Cube createdCube;

            for (int i = 0; i < quantityCubes; i++)
            {
                createdCube = CreateCube(cube);
                createdCubs.Add(createdCube);
            }

            Explode(createdCubs, cube);

            createdCubs.Clear();
        }
        else
        {
            cube.Explode(_explodeForce, _explodeRadius);
            _explodeManager.ExplodeForce(cube, _explodeForce*cube.Multiple, _explodeRadius * cube.Multiple);
        }

        cube.Destroy();
    }

    private Cube CreateCube(Cube cube)
    {
        Cube newCube = Instantiate(cube, cube.transform.position, cube.transform.rotation);

        newCube.Init();

        return newCube;
    }

    private void Explode(List<Cube> cubs, Cube parentCube)
    {
        foreach (Cube cube in cubs)
            cube.Explode(parentCube.transform.position, _explodeForce, _explodeRadius);
    }
}