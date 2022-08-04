using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphicsTest : MonoBehaviour
{
    public Texture aTexture;
    void Start()
    {
        Graphics.DrawTexture(new Rect(0, 0, 100, 100), aTexture);
    }
    void Update()
    {
        
    }
}
