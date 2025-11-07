using UnityEngine;

public class ShowBounds : MonoBehaviour
{
    void Start()
    {
        
        var sr = GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            Vector3 size = sr.bounds.size;
            Debug.Log($"{name} (SpriteRenderer) -> width: {size.x:F2}, height: {size.y:F2}");
            return;
        }

        
        var rend = GetComponent<Renderer>();
        if (rend != null)
        {
            Vector3 size = rend.bounds.size;
            Debug.Log($"{name} (Renderer) -> width: {size.x:F2}, height: {size.y:F2}");
            return;
        }

        Debug.LogWarning($"{name} não tem SpriteRenderer nem Renderer. Coloque este script no objeto que tem o gráfico.");
    }
}
