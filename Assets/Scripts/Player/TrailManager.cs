using System;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    [Serializable]
    public class TrailManager
    {
        [SerializeField] private float tailStartingLength = 0.1f;
        [SerializeField] private float tailLength = 0.1f;
        [SerializeField] private float tailIncrement = 0.05f;
        [SerializeField] public List<TrailRenderer> trails;


        public void HandleTrailLength()
        {
            tailLength += tailIncrement;
            ApplyTrailLength();
        }

        public void ResetTrails()
        {
            tailLength = tailStartingLength;
            ApplyTrailLength(reset: true);
        }

        void ApplyTrailLength(bool reset = false)
        {
            if (reset == false)
            {
                foreach (TrailRenderer trail in trails)
                {
                    trail.time += tailLength;
                }
            }
            else
            {
                foreach (TrailRenderer trail in trails)
                {
                    trail.time = tailLength;
                }
            }
        }
    }
}