using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

//this class stores all timelines in the current level so they can be activated/deactivated from other scripts
[RequireComponent(typeof(PlayableDirector))]
public class CameraTimelines : MonoBehaviour
{
    PlayableDirector director;
    [SerializeField] List<TimelineAsset> timelines;
    Dictionary<string, TimelineAsset> timelineDictionary = new Dictionary<string, TimelineAsset>();
    bool timelineIsActive;
    public bool TimelineIsActive { get; }

    private void Start()
    {
        director = GetComponent<PlayableDirector>();
        StoreTimelinesInDictionary();
    }

    //plays a timeline by passing in its name
    public void PlayTimeline(string timelineName)
    {
        director.Play(timelineDictionary[timelineName]);
        timelineIsActive = true;
    }

    //puts all the timelines in the dictionary - timelines are accessed using their names 
    private void StoreTimelinesInDictionary()
    {
        foreach (TimelineAsset timeline in timelines)
        {
            timelineDictionary.Add(timeline.name, timeline);
        }
    }
}
