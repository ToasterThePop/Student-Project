using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class hinge : MonoBehaviour
{

    public HingeJoint2D Joint2D;
    private bool activated = false;
    private bool release = false;

    public GameObject newcircle;

    public GameObject box1;
    public GameObject box2;
    public GameObject box3;
    public GameObject box4;
    public GameObject box5;
    public GameObject box6;
    public GameObject box7;
    public GameObject box8;

    public UIDocument document;
    public Label SpeedLabel;
    public Label MassLabel;


    private float motorspeed; 

    private void Start()
    {
        SpeedLabel = document.rootVisualElement.Q<Label>("SpeedLabel");
        MassLabel = document.rootVisualElement.Q<Label>("MassLabel");

        JointMotor2D motor = Joint2D.motor;
        motorspeed = 200;
        motor.motorSpeed = motorspeed;
        SpeedLabel.text = $"{motor.motorSpeed}";

        MassLabel.text = $"{newcircle.GetComponent<Rigidbody2D>().mass}";
    }


    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.Space) && !activated)
        {

            Joint2D.useMotor = true;
            activated = true;
        }

        if (!activated)
        {

            if (Input.GetKey(KeyCode.Q))
            {
                JointMotor2D motor = Joint2D.motor;
                motorspeed += Time.deltaTime * 10;
                motor.motorSpeed = motorspeed;
                SpeedLabel.text = $"{motor.motorSpeed}";
            }
            else if (Input.GetKey(KeyCode.W))
            {
                JointMotor2D motor = Joint2D.motor;
                motorspeed -= Time.deltaTime * 10;
                motor.motorSpeed = motorspeed;
                SpeedLabel.text = $"{motor.motorSpeed}";
            }

            if (Input.GetKey(KeyCode.A))
            {
                box1.transform.Translate(new Vector3(Time.deltaTime, 0, 0));
                box2.transform.Translate(new Vector3(Time.deltaTime, 0, 0));
                box3.transform.Translate(new Vector3(Time.deltaTime, 0, 0));
                box4.transform.Translate(new Vector3(Time.deltaTime, 0, 0));
                box5.transform.Translate(new Vector3(Time.deltaTime, 0, 0));
                box6.transform.Translate(new Vector3(Time.deltaTime, 0, 0));
                box7.transform.Translate(new Vector3(Time.deltaTime, 0, 0));
                box8.transform.Translate(new Vector3(Time.deltaTime, 0, 0));

            }
            else if (Input.GetKey(KeyCode.S))
            {
                box1.transform.Translate(new Vector3(-Time.deltaTime, 0, 0));
                box2.transform.Translate(new Vector3(-Time.deltaTime, 0, 0));
                box3.transform.Translate(new Vector3(-Time.deltaTime, 0, 0));
                box4.transform.Translate(new Vector3(-Time.deltaTime, 0, 0));
                box5.transform.Translate(new Vector3(-Time.deltaTime, 0, 0));
                box6.transform.Translate(new Vector3(-Time.deltaTime, 0, 0));
                box7.transform.Translate(new Vector3(-Time.deltaTime, 0, 0));
                box8.transform.Translate(new Vector3(-Time.deltaTime, 0, 0));
            }

            if (Input.GetKey(KeyCode.Z)) {
                newcircle.GetComponent<Rigidbody2D>().mass += Time.deltaTime * 10;
                MassLabel.text = $"{newcircle.GetComponent<Rigidbody2D>().mass}";
            }
            else if (Input.GetKey(KeyCode.X))
            {
                newcircle.GetComponent<Rigidbody2D>().mass -= Time.deltaTime * 10;
                MassLabel.text = $"{newcircle.GetComponent<Rigidbody2D>().mass}";
            }
        }

        if (activated)
        {

            if (Input.GetKey(KeyCode.E) && !release)
            {
                Destroy(box1.GetComponent<BoxCollider2D>());
                Destroy(box2.GetComponent<BoxCollider2D>());
                Destroy(box3.GetComponent<BoxCollider2D>());
                Destroy(box4.GetComponent<BoxCollider2D>());
                Destroy(box5.GetComponent<BoxCollider2D>());
                Destroy(box6.GetComponent<BoxCollider2D>());
                Destroy(box7.GetComponent<BoxCollider2D>());
                Destroy(box8.GetComponent<BoxCollider2D>());

                release = true;
            }

            
        }

        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene("Assets/Scenes/SampleScene.unity");
        }
    }
}
