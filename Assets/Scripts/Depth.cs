using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Depth : MonoBehaviour
{

    private Renderer myRenderer;

    [SerializeField]
    private bool staticObject;

    void Start()
    {
        myRenderer = GetComponent<Renderer>();
        myRenderer.sortingOrder = -Mathf.RoundToInt(transform.position.y * 100);
    }

    void LateUpdate()
    {
        if (!staticObject)
        {
            myRenderer.sortingOrder = -Mathf.RoundToInt(transform.position.y * 100);
        }

    }
}
