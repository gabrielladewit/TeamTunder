using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class GyroCalibrator : MonoBehaviour {

    private Stopwatch stopwatch;
    private int updates = 0;
    private Vector3 totalInput;
    public Vector3 averageInput;
    public Quaternion gyroAttitude;
    private GameObject calibObj;

    // Use this for initialization
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        stopwatch = new Stopwatch();
        totalInput = new Vector3(0, 0, 0);
    }

    public void startstab()
    {
        updates = 0;
        totalInput = new Vector3(0, 0, 0);
        stopwatch.Start();
        StartCoroutine(Calibrate());
    }

    IEnumerator Calibrate()
    {
        while (stopwatch.ElapsedMilliseconds < 3000)
        {
            updates++;
            totalInput.x += Input.acceleration.x;
            totalInput.y += Input.acceleration.y;
            totalInput.z += Input.acceleration.z;
            UnityEngine.Debug.Log("Added intel");
            yield return new WaitForSeconds(0.2f);
        }
        stopwatch.Stop();
        stopwatch.Reset();
        gyroAttitude = Input.gyro.attitude;
        averageInput = (totalInput / updates);
        StopCoroutine("Calibrate");
    }
}
