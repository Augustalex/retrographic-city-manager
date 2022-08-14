using UnityEngine;

public class FloppyPlug : MonoBehaviour
{
    public FloppyHole hole;

    private MeshRenderer _meshRenderer;
    private Color _targetColor;
    private float _setTarget;

    private const float TransitionTime = .25f;

    void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();

        hole.Inserted += TurnOn;
        hole.Ejected += TurnOff;
    }

    public void TurnOn()
    {
        _targetColor = Color.green;
        _setTarget = Time.time;
    }

    public void TurnOff()
    {
        _targetColor = Color.red;
        _setTarget = Time.time;
    }

    void Update()
    {
        var currentColor = _meshRenderer.material.color;
        var progress = Mathf.Clamp((Time.time - _setTarget) / TransitionTime, 0f, 1f);
        _meshRenderer.material.color = Color.Lerp(currentColor, _targetColor, progress);
    }
}