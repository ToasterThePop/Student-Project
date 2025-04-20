using UnityEngine;

public class drawline : MonoBehaviour
{

    public LineRenderer lineRenderer;
    public Rigidbody2D track;

    // Update is called once per frame
    void FixedUpdate()
    {
        lineRenderer.SetPosition(1, track.position);
    }
}
