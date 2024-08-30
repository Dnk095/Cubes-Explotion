using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private float _explodeRadius;
    [SerializeField] private float _explodeForce;

    public void Spawn(Cube cube)
    {
        List<Cube> _createdCubs = new List<Cube> ();

        int minChaceSpawn = 0;
        int maxChaceSpawn = 100;

        if (Random.Range(minChaceSpawn, maxChaceSpawn + 1) <= cube.ChanceSpawn)
        {
            int minQuantity = 2;
            int maxQuantity = 6;
            int quantityCubes = Random.Range(minQuantity, maxQuantity + 1);

            for (int i = 0; i < quantityCubes; i++)
                CreateCube(cube, ref _createdCubs);

            Explode(_createdCubs);

            _createdCubs.Clear();
        }

        cube.Destroy();
    }

    private Cube CreateCube(Cube cube, ref List<Cube> cubs)
    {
        Cube newCube = Instantiate(cube, cube.transform.position, cube.transform.rotation);

        newCube.Init();

        cubs.Add(newCube);

        return newCube;
    }

    private void Explode(List<Cube> cubs)
    {
        foreach (Cube cube in cubs)
            cube.Explode(_explodeForce, _explodeRadius);
    }
}