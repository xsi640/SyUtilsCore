using System;

namespace SyUtilsCore.Threading
{
    public interface ICircleEngine
    {
        #region event
        event Action DoWork;
        #endregion

        #region property
        bool IsStarted { get; }
        int DetectSpanInMilliseconds { get; set; }
        Exception LastException { get; }
        #endregion

        #region function
        void Start();
        void Stop();
        #endregion
    }
}