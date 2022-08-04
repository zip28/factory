using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static float time;
    public static float tickTime;

    // Update is called once per frame
    void FixedUpdate()
    {
        time += Time.fixedDeltaTime;
        if (time >= tickTime)
        {
            time -= tickTime;

        }
    }
    void Tick()
    {
        ConvejerManager.solo.Tick();
    }
}
