using System.Collections.Generic;
using UnityEngine;

public class ExplodeManager : MonoBehaviour
{

    public void ExplodeForce(Cube cube, float force, float radius)
    {
        foreach (Cube explodedCube in GetExplodabledObject(cube, radius))
        {
            explodedCube.Explode(cube.transform.position,
                GetForceValue(cube, explodedCube, radius, force),
                radius);
        }
    }

    private List<Cube> GetExplodabledObject(Cube cube, float radius)
    {
        Collider[] hits = Physics.OverlapSphere(cube.transform.position, radius);

        List<Cube> forsedCubs = new();

        foreach (Collider cubeCollider in hits)
            if (cubeCollider.attachedRigidbody != null)
                forsedCubs.Add(cubeCollider.GetComponent<Cube>());

        return forsedCubs;
    }

    private float GetForceValue(Cube explodedCube, Cube forcedCube, float radius, float force)
    {
        Vector3 distanse = explodedCube.transform.position - forcedCube.transform.position;

        float proportion = 1.0f - (distanse / radius).magnitude;

        return force * proportion;
    }
}
