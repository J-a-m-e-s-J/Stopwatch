using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Stopwatch
{
    public class Stopwatch : MonoBehaviour
    {
        private int _stopwatchNumber;
        private TextMeshPro _stopwatch;
        private bool _isRunning;
        private long _startTime;
        private long _stopTime;
        private long _duration;
        private bool _getEvent;
        
        // Start is called before the first frame update
        void Start()
        {
            _stopwatchNumber = 0;
            _stopwatch = GetComponent<TextMeshPro>();
            _stopwatch.text = (0.1 * _stopwatchNumber).ToString(CultureInfo.InvariantCulture);
            _isRunning = false;
            _startTime = GetTimeStamp();
            _stopTime = 0;
            _duration = 10;
            _getEvent = false;
            Task.Run(() =>
            {
                while (true)
                {
                    while (_getEvent)
                    {
                        GetKeyEvents();
                        Debug.Log("Getting Key Events");
                        _getEvent = false;
                    }
                }
            });
        }

        // Update is called once per frame
        void Update()
        {
            _getEvent = true;
            Debug.Log("Main Thread Running");
            if (_isRunning)
            {
                _stopTime = GetTimeStamp();
                // Thread.Sleep(100);
            }

            if (TimeEnough(_startTime, _stopTime, _duration))
            {
                _stopwatchNumber++;
                _duration++;
            }
            
            _stopwatch.text = (0.1 * _stopwatchNumber).ToString(CultureInfo.InvariantCulture);
            // GetKeyEvents();
        }

        void GetKeyEvents()
        {
            if (KeyStatus.Space)
            {
                _isRunning = !_isRunning;
                Debug.Log("Space pressed");
            }

            if (KeyStatus.R)
            {
                _isRunning = false;
                _stopwatchNumber = 0;
                _duration = 1;
                Debug.Log("R pressed");
            }
            
            Debug.Log("GetKeyEvents called");
        }

        bool TimeEnough(long startTime, long stopTime, long duration)
        {
            if (stopTime - startTime >= 100 * duration)
            {
                return true;
            }

            return false;
        }
        
        long GetTimeStamp()
        {
            TimeSpan ts = DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return long.Parse(Convert.ToInt64(ts.TotalMilliseconds).ToString());
        }
    }

    public enum Keys
    {
        Space,
        R
    }
}