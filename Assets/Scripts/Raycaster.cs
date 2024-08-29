using System;
using UnityEngine;

public class Raycaster : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Button _button;
    [SerializeField] private LayerMask _layerMask;

    public event Action UseMouseOnObject;

    public RaycastHit Hit { get; private set; }

    private Ray _ray;

    private void OnEnable()
    {
        _button.UseMouseButton += OnUseMouseButton;
    }

    private void OnDisable()
    {
        _button.UseMouseButton -= OnUseMouseButton;
    }

    private void OnUseMouseButton()
    {
        _ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(_ray, out RaycastHit hit, Mathf.Infinity, _layerMask))
        {
            Hit = hit;
            UseMouseOnObject?.Invoke();
        }
    }
}
