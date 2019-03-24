using System;
using System.Diagnostics;
using Facepunch;
using SapphireEngine;

namespace RakNet
{
    public class TimeWarning : IDisposable
    {
        public static bool Enabled;

        public static bool EnableScopeCalls;

        public static Action<string> OnBegin;

        public static Action OnEnd;

        private readonly Stopwatch _stopwatch = new Stopwatch();

        private bool _disposed;

        private int _gcCount;

        private double _warningMs;

        private string _warningName;

        void IDisposable.Dispose()
        {
            if (_disposed)
            {
                return;
            }

            _disposed = true;
            if (OnEnd != null)
            {
                OnEnd();
            }

            if (Enabled && _stopwatch.Elapsed.TotalMilliseconds > _warningMs)
            {
                var flag = _gcCount != GC.CollectionCount(0);
                object[] totalSeconds = {_warningName, null, null, null};
                totalSeconds[1] = _stopwatch.Elapsed.TotalSeconds;
                totalSeconds[2] = _stopwatch.Elapsed.TotalMilliseconds;
                totalSeconds[3] = !flag ? string.Empty : " [GARBAGE COLLECT]";
                ConsoleSystem.LogWarning(string.Format("TimeWarning: {0} took {1:0.00} seconds ({2:0} ms){3}",
                    totalSeconds));
            }

            var timeWarning = this;
            Pool.Free(ref timeWarning);
        }

        public static void BeginSample(string name)
        {
            if (OnBegin != null)
            {
                OnBegin(name);
            }
        }

        public static void EndSample()
        {
            if (OnEnd != null)
            {
                OnEnd();
            }
        }

        public static TimeWarning New(string name, float maxSeconds = 0.1f)
        {
            if (!Enabled && !EnableScopeCalls)
            {
                return null;
            }

            var timeWarning = Pool.Get<TimeWarning>();
            timeWarning.Start(name, maxSeconds);
            return timeWarning;
        }

        public static TimeWarning New(string name, long maxMilliseconds)
        {
            if (!Enabled && !EnableScopeCalls)
            {
                return null;
            }

            var timeWarning = Pool.Get<TimeWarning>();
            timeWarning.Start(name, maxMilliseconds);
            return timeWarning;
        }

        private void Start(string name, float maxSeconds = 0.1f)
        {
            if (Enabled)
            {
                _warningName = name;
                _warningMs = maxSeconds * 1000f;
                _stopwatch.Reset();
                _stopwatch.Start();
                _gcCount = GC.CollectionCount(0);
            }

            _disposed = false;
            if (OnBegin != null)
            {
                OnBegin(name);
            }
        }

        private void Start(string name, long maxMilliseconds)
        {
            if (Enabled)
            {
                _warningName = name;
                _warningMs = maxMilliseconds;
                _stopwatch.Reset();
                _stopwatch.Start();
                _gcCount = GC.CollectionCount(0);
            }

            _disposed = false;
            if (OnBegin != null)
            {
                OnBegin(name);
            }
        }
    }
}