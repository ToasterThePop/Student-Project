using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class circle : MonoBehaviour
{

    public UIDocument document;
    private Label ImpactLabel;
    public Rigidbody2D rb;

    private float acceleration;
    private float previousVelocity;

    private void Start()
    {
        ImpactLabel = document.rootVisualElement.Q<Label>("ImpactLabel");
    }

    private void Update()
    {
        // accleration = vf - vi / af - ai
        acceleration = (rb.angularVelocity - previousVelocity) / Time.deltaTime;
        previousVelocity = rb.angularVelocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "target")
        {
            ImpactLabel.text = $"{rb.mass * acceleration}";
        }
    }
}
