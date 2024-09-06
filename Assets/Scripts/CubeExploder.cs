using System.Collections.Generic;
using UnityEngine;

public class CubeExploder : MonoBehaviour
{
    [SerializeField] private ParticleSystem _effect;

    public void Explode(Cube cube)
    {
        float delay = 1f;

        ParticleSystem explodeEffect = Instantiate(_effect, cube.transform.position, transform.rotation);

        Destroy(explodeEffect.gameObject, delay);

        ExplodeForce(cube);
    }

    public void ExplodeForce(Cube cube)
    {
        foreach (Cube explodedCube in GetExplodabledObject(cube))
        {
            explodedCube.AddForce(cube.transform.position,
                GetForceValue(cube, explodedCube), cube.ExplodeRadius * cube.Multiple);
        }
    }

    private List<Cube> GetExplodabledObject(Cube cube)
    {
        Collider[] hits = Physics.OverlapSphere(cube.transform.position, cube.ExplodeRadius * cube.Multiple);

        List<Cube> forsedCubs = new();

        foreach (Collider cubeCollider in hits)
            if (cubeCollider.TryGetComponent(out Cube component))
                forsedCubs.Add(component);

        return forsedCubs;
    }

    private float GetForceValue(Cube explodedCube, Cube forcedCube)
    {
        Vector3 distanse = explodedCube.transform.position - forcedCube.transform.position;

        float proportion = 1.0f - (distanse / (explodedCube.ExplodeRadius * explodedCube.Multiple)).magnitude;

        return explodedCube.ExplodeForce*explodedCube.Multiple * proportion;
    }
}
