using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    public void Spawn(Cube cube)
    {
        List<Cube> createdCubs = new();

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

    private Cube CreateCube(Cube cube)
    {
        Cube newCube = Instantiate(cube, cube.transform.position, cube.transform.rotation);

        newCube.Init();

        return newCube;
    }

    private void Explode(List<Cube> cubs, Cube parentCube)
    {
        foreach (Cube cube in cubs)
            cube.AddForce(parentCube.transform.position, parentCube.ExplodeForce, parentCube.ExplodeRadius);
    }
}