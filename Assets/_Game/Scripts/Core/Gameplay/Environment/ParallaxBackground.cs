using UnityEngine;

[ExecuteInEditMode]
public class ParallaxBackground : MonoBehaviour
{
    [SerializeField]
    [Range(-1, 1)]
    private float _speedMultiplier = 0.35f;

    private Camera _camera = default;

    private Vector2 _position = Vector2.zero;

    void LateUpdate()
    {
        if (_camera == null)
            _camera = FindObjectOfType<Camera>();

        _position.x = _camera.transform.position.x * _speedMultiplier;
        _position.y = _camera.transform.position.y * _speedMultiplier;

        transform.position = _position;
    }
}
