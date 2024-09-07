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

        for (int i = 0; i < quantityCubes; i++)
            createdCubs.Add(CreateCube(cube));

        AddForce(createdCubs, cube);

        createdCubs.Clear();
        cube.Destroy();
    }

    private Cube CreateCube(Cube cube)
    {
        Cube newCube = Instantiate(cube, cube.transform.position, cube.transform.rotation);

        newCube.Init();

        return newCube;
    }

    private void AddForce(List<Cube> cubs, Cube parentCube)
    {
        foreach (Cube cube in cubs)
            cube.AddForce(parentCube.transform.position, parentCube.ExplodeForce, parentCube.ExplodeRadius);
    }
}