using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "_AudioList", menuName = "List/New Audio List", order = 0)]
    public class AudioList : ScriptableObject
    {
        public new string name;
        public List<AudioClip> clips = new();

        public AudioClip GetRandomClip()
        {
            AudioClip clip = clips[Random.Range(0, clips.Count)];
            return clip;
        }
    }
}