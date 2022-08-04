using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraView : MonoBehaviour
{
    public static CameraView solo;
    public Vector2 cameraPose = new Vector2(0.5f, 0.5f);
    public float scale = 32; // cell in pixels
    public float speed = 2; // in cells

    private void Awake()
    {
        solo = this;
    }
    // Update is called once per frame
    void Update()
    {
        cameraPose += new Vector2(Input.GetAxis("Horizontal") * speed / Matrix.size, Input.GetAxis("Vertical") * speed / Matrix.size) * scale;
    }
}
