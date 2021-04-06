using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class graphsize: MonoBehaviour
{
    // Start is called before the first frame update
    public void Awake()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Screen.SetResolution(1280, 720, false);
    }
}
