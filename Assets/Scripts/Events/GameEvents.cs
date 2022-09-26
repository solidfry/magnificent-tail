using UnityEngine;

namespace Events
{
    public class GameEvents : MonoBehaviour
    {
        public delegate void Collect();
        public delegate void PlayClip(AudioClip clip);
        public delegate void ResetTimer();

        public static Collect OnCollectablePickedUp;
        public static PlayClip OnAudioCollisionEvent;
        public static ResetTimer OnResetTimerEvent;
    }
}
