using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class TrackingTarget : MonoBehaviour
{
    private TrackableBehaviour track;
    [SerializeField]
    private objMove[] scripts;

    void Start()
    {
        scripts = GameObject.FindObjectsOfType<objMove>();
        track = GetComponent<TrackableBehaviour>();
        if (track) { track.RegisterOnTrackableStatusChanged(OnTrackableStatusChanged); }

    }

    void Update()
    {
        
    }

    void ScriptEnable(bool _enabled)
    {
        foreach (var script in scripts)
        {
            script.enabled = _enabled;
        }
    }

    public void OnTrackableStatusChanged(TrackableBehaviour.StatusChangeResult obj)
    {
        if (obj.NewStatus == TrackableBehaviour.Status.DETECTED ||
            obj.NewStatus == TrackableBehaviour.Status.TRACKED)
        {
            ScriptEnable(true);
        }
        else
        {
            ScriptEnable(false);
        }
    }

}
