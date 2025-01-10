using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Stopwatch
{
    public class EventListener : MonoBehaviour
    {
        // Update is called once per frame
        void Update()
        {
            KeyStatus.Space = Input.GetKeyDown(KeyCode.Space);
            KeyStatus.R = Input.GetKeyDown(KeyCode.R);
            
            // if (KeyStatus.Space)
            //     Debug.Log("Space pressed 111");
            // if (KeyStatus.R)
            //     Debug.Log("R pressed 111");
        }
    }

    public static class KeyStatus
    {
        public static bool Space;
        public static bool R;
    }
}