using UnityEngine;

public class Raycaster : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private CubeSpawner _spawner;
    [SerializeField] private LayerMask _layerMask;

    private int _mousseButtonTrigger = 0;

    private void Update()
    {
        if (Input.GetMouseButtonDown(_mousseButtonTrigger))
        {
           Ray _ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(_ray, out RaycastHit hit, Mathf.Infinity, _layerMask))
            {
                if (hit.collider.TryGetComponent(out Cube cube))
                {
                    _spawner.Spawn(cube);
                }
            }
        }
    }
}