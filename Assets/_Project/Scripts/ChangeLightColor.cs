using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ChangeLightColor : MonoBehaviour
{

    [SerializeField] private MeshRenderer _redMesh;
    [SerializeField] private MeshRenderer _greenMesh;
    [SerializeField] private MeshRenderer _yellowMesh;
    [SerializeField] private TextMeshProUGUI _textMeshPro;
    [SerializeField] private float _delay;

    private Color _defaultColor;
    private float _lastUpdate;

    void Start()
    {
        _defaultColor = _redMesh.material.color;
        StartCoroutine(ChangeColor());
    }

    void Update()
    {
        float nextUpdate = _delay - Time.time + _lastUpdate;
        _textMeshPro.text = "Il semaforo si aggiorna tra " + nextUpdate;
    }

    IEnumerator ChangeColor()
    {
        while (true)
        {
            _yellowMesh.material.color = _defaultColor;
            _redMesh.material.color = Color.red;
            _lastUpdate = Time.time;
            yield return new WaitForSeconds(_delay);

            _greenMesh.material.color = Color.green;
            _redMesh.material.color = _defaultColor;
            _lastUpdate = Time.time;
            yield return new WaitForSeconds(_delay);

            _greenMesh.material.color = _defaultColor;
            _yellowMesh.material.color = Color.yellow;
            _lastUpdate = Time.time;
            yield return new WaitForSeconds(_delay);
        }
    }
}
