using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System;
using System.Runtime.InteropServices;

/// <summary>
/// Descripción breve de HiRes
/// </summary>

    internal class UnmanagedMethods
    {

        internal struct LARGE_INTEGER
        {
            public UInt32 lowpart;
            public UInt32 highpart;
        }

        [DllImport("kernel32.dll")]
        internal extern static UInt32 QueryPerformanceCounter(ref LARGE_INTEGER lpPerformanceCount);
        [DllImport("kernel32.dll")]
        internal extern static UInt32 QueryPerformanceFrequency(ref LARGE_INTEGER lpFrequency);
    }

    public class HiRes
    {
        private float period = 0;
        private float startTime = 0;
        private float timerFrequency = 0;
        private bool hasHiResCounter = false;

        public void Start()
        {
            UnmanagedMethods.LARGE_INTEGER res = new UnmanagedMethods.LARGE_INTEGER();
            UnmanagedMethods.QueryPerformanceCounter(ref res);
            startTime = (float)((res.highpart >> 32) + res.lowpart);
        }

        public void Stop()
        {
            UnmanagedMethods.LARGE_INTEGER res = new UnmanagedMethods.LARGE_INTEGER();
            UnmanagedMethods.QueryPerformanceCounter(ref res);
            float endTime = (float)((res.highpart >> 32) + res.lowpart);
            period = endTime - startTime;
        }

        public float ElapsedTime
        {
            get
            {
                return period / timerFrequency;
            }
        }

        public bool HasHiResCounter
        {
            get
            {
                return hasHiResCounter;
            }
        }

        public float Frequency
        {
            get
            {
                return timerFrequency;
            }
        }

        public HiRes()
        {
            UnmanagedMethods.LARGE_INTEGER res = new UnmanagedMethods.LARGE_INTEGER();
            UInt32 r = UnmanagedMethods.QueryPerformanceFrequency(ref res);
            if (r != 0)
            {
                hasHiResCounter = true;
                timerFrequency = (float)((res.highpart >> 32) + res.lowpart);
            }
        }
    }