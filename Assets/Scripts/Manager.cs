using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MonitorState : MonoBehaviour
{
    
float FPS;
int count;
[SerializeField] Text txtFps,txtphysicsLOOP;

    // Start is called before the first frame update
    void Start()
    {
        FPS = 0.0f;
        count =0;
    }

    // Update is called once per frame
    void Update()
    {
        FPS = 1/Time.deltaTime;
        txtFps.text = "FPS: " + FPS.ToString("0.###");
        txtphysicsLOOP.text = "Physics Loop per Frame: " + count;
        count =0;

    }

    private void FixedUpdate() {
        count++;
    }
}
