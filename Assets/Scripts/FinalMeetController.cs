using UnityEngine;
using System.Collections;

public class FinalMeetByAnchors : MonoBehaviour
{
    [Header("Felpudo")]
    public Transform felpudoRoot;   
    public Transform felpudoAnchor; 

    [Header("Fofura")]
    public Transform fofuraRoot;   
    public Transform fofuraAnchor;  

    [Header("Alvos (mundo)")]
    public Transform stopLeft;      
    public Transform stopRight;     

    [Header("UI opcional")]
    public CanvasGroup winPanel;         
    public HeartSpawnerUI heartSpawner;  

    [Header("Movimento")]
    public float speed = 3f;       
    public float tolerance = 0.02f; 

    [Header("Compatibilidade")]
    public bool neutralizeRigidbodies = true;
    public bool disableAnimators = true;

    bool started, finished;

    void Start()
    {
        // validação
        if (!felpudoRoot || !felpudoAnchor || !fofuraRoot || !fofuraAnchor || !stopLeft || !stopRight)
        {
            Debug.LogError("[FinalMeetByAnchors] Preencha todas as referências (roots, anchors e stops).");
            enabled = false;
            return;
        }
        if (winPanel) winPanel.alpha = 0f;

        if (neutralizeRigidbodies) { MakeKinematicIfAny(felpudoRoot); MakeKinematicIfAny(fofuraRoot); }
        if (disableAnimators) { DisableAnimatorIfAny(felpudoRoot); DisableAnimatorIfAny(fofuraRoot); }

        // log diagnóstico
        Debug.Log($"[FinalMeetByAnchors] FelpudoAnchorX={felpudoAnchor.position.x:F2} -> alvo {stopLeft.position.x:F2} | " +
                  $"FofuraAnchorX={fofuraAnchor.position.x:F2} -> alvo {stopRight.position.x:F2}");

        started = true;
    }

    void Update()
    {
        if (!started || finished) return;

        
        MoveRootSoAnchorChegue(felpudoRoot, felpudoAnchor, stopLeft.position.x);
        
        MoveRootSoAnchorChegue(fofuraRoot, fofuraAnchor, stopRight.position.x);

        bool f1ok = Mathf.Abs(felpudoAnchor.position.x - stopLeft.position.x) <= tolerance;
        bool f2ok = Mathf.Abs(fofuraAnchor.position.x - stopRight.position.x) <= tolerance;

        if (f1ok && f2ok)
        {
            finished = true;
            StartCoroutine(Sequence());
        }
    }

    void MoveRootSoAnchorChegue(Transform root, Transform anchor, float targetAnchorX)
    {
        
        float desiredRootX = root.position.x + (targetAnchorX - anchor.position.x);
        float newX = Mathf.MoveTowards(root.position.x, desiredRootX, speed * Time.deltaTime);

        
        Vector3 p = root.position;
        p.x = newX;
        root.position = p;
    }

    IEnumerator Sequence()
    {
        yield return new WaitForSeconds(0.2f);
        if (heartSpawner) heartSpawner.StartSpawning();

        yield return new WaitForSeconds(0.6f);
        if (winPanel)
        {
            float t = 0f, dur = 0.8f;
            while (t < dur)
            {
                t += Time.deltaTime;
                winPanel.alpha = Mathf.Lerp(0f, 1f, t / dur);
                yield return null;
            }
            winPanel.alpha = 1f;
        }
    }

    
    void MakeKinematicIfAny(Transform t)
    {
        if (!t) return;
        var rb2d = t.GetComponent<Rigidbody2D>();
        if (rb2d) { rb2d.linearVelocity = Vector2.zero; rb2d.angularVelocity = 0f; rb2d.bodyType = RigidbodyType2D.Kinematic; }
        var rb3d = t.GetComponent<Rigidbody>();
        if (rb3d) { rb3d.linearVelocity = Vector3.zero; rb3d.angularVelocity = Vector3.zero; rb3d.isKinematic = true; }
    }
    void DisableAnimatorIfAny(Transform t)
    {
        if (!t) return;
        var anim = t.GetComponent<Animator>();
        if (anim) { anim.applyRootMotion = false; anim.enabled = false; }
    }
}
