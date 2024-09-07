using UnityEngine;

public class ClickHandler : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private CubeSpawner _spawner;
    [SerializeField] private CubeExploder _exploder;

    private int _mousseButtonTrigger = 0;

    private void Update()
    {
        if (Input.GetMouseButtonDown(_mousseButtonTrigger))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, _layerMask))
            {
                if (hit.collider.TryGetComponent(out Cube cube))
                {
                    cube.REDFt(out bool canSpawn);

                    if (canSpawn)
                    {
                        _spawner.Spawn(cube);
                    }
                    else
                        _exploder.Explode(cube);
                }
            }
        }
    }
}