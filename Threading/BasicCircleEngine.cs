using System;
using System.Threading.Tasks;
using System.Threading;

namespace SyUtilsCore.Threading
{
    public class BasicCircleEngine : ICircleEngine
    {
        #region 变量
        private bool _IsStarted = false;
        private bool _stopping = false;
        private Exception _LastException = null;
        private int _DetectSpanInMilliseconds = 500;
        public event Action DoWork;
        #endregion

        #region 属性
        public bool IsStarted
        {
            get { return _IsStarted; }
        }

        public int DetectSpanInMilliseconds
        {
            get { return _DetectSpanInMilliseconds; }
            set { _DetectSpanInMilliseconds = value; }
        }
        public Exception LastException
        {
            get { return _LastException; }
        }
        #endregion

        #region 方法
        public void Start()
        {
            if (!_IsStarted)
            {
                new Task(DoWorking).Start();
                _IsStarted = true;
            }
        }

        public void Stop()
        {
            _stopping = true;
            _IsStarted = false;
        }

        private void DoWorking()
        {
            while (true)
            {
                try
                {
                    this.DoWork();
                    Thread.Sleep(_DetectSpanInMilliseconds);
                    if (_stopping)
                        break;
                }
                catch (Exception ex)
                {
                    _LastException = ex;
                }
            }
            _stopping = false;
        }
        #endregion
    }
}