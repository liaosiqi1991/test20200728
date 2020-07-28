using System;
using System.IO.Pipes;
using System.IO;
 

namespace zlMedimgSystem.Services
{
    public delegate void OnPipeReceiveEvent(string pipeData, ServerPipes pipeServer);

    public class ServerPipes : DisposeImp
    {
        //public const int INBUFFERSIZE = 4096;
        //public const int OUTBUFFERSIZE = 65535;
        public const string DEFAULT_PIPE_NAME = @"\ZLPACSSVRCENTER\CS\0FD1A47CBDF143298EBC3F03877CB94F";

        private bool _isRuning = false;
        private bool _isStop = false;
        private string _pipeName = "";
        private string _instanceId = "";

        private ILog _log;

        private NamedPipeServerStream _pipeServer = null;
        //private BackgroundWorker _pipeWorker = null;

        public event OnPipeReceiveEvent OnPipeRecevie;

        /// <summary>
        /// 允许状态
        /// </summary>
        public bool IsRuning
        {
            get { return _isRuning;}//_pipeWorker.IsBusy; }
        }

        public string  InstanceId
        {
            get { return _instanceId; }
            set { _instanceId = value; }
        }

        protected bool IsStop
        {
            get { return _isStop; }
        }
        
        public ServerPipes(ILog serverLog, string pipeName="")
        {
            _log = serverLog;
            _pipeName = pipeName;

            if (string.IsNullOrEmpty(_pipeName) == true)
            {
                _pipeName = DEFAULT_PIPE_NAME;
            }
            
            //_pipeWorker = new BackgroundWorker();

            //_pipeWorker.WorkerSupportsCancellation = true;
            //_pipeWorker.WorkerReportsProgress = true;
             
            //_pipeWorker.DoWork += PipeProcessWorker;

            _instanceId = Guid.NewGuid().ToString("N").ToUpper();
        }

        /// <summary>
        /// 调用管道服务接收事件 
        /// </summary>
        /// <param name="pipeData"></param>
        private void DoOnPipeReceive(string pipeData, ServerPipes pipeServer)
        {
            try
            {
                if (IsStop) return;

                if (OnPipeRecevie != null)
                {
                    int count = 0;
                    while (count < 3)
                    {
                        try
                        {
                            OnPipeRecevie(pipeData, pipeServer);

                            count = 3;
                        }
                        catch (Exception ex)
                        {
                            count = count + 1;
                            if (count == 3)
                            {
                                _log.WriteError(ex, "ServerPipes", "数据接收处理失败，已经重试 [" + count.ToString() + "] 次,将放弃处理,管道服务标识 [" + _instanceId + "]");
                            }
                            else
                            {
                                _log.WriteError(ex, "ServerPipes", "数据接收处理失败，开始第 [" + count.ToString() + "] 次重试执行,管道服务标识 [" + _instanceId + "]");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _log.WriteError(ex, "ServerPipes", "数据接收处理事件执行异常,管道服务标识 [" + _instanceId + "]");
            }
        }

        private void PipeAsyncCallback(IAsyncResult ar)
        {
            try
            {
                if (IsStop) return;
                NamedPipeServerStream curPipe = ar.AsyncState as NamedPipeServerStream;

                if (IsStop) return;
                curPipe.EndWaitForConnection(ar);

                if (IsStop) return;

                try
                {
                    using (StreamReader sr = new StreamReader(curPipe))
                    {
                        string data = sr.ReadToEnd();

                        _log.WriteLog(LogType.ltNormal, "接收到管道数据 [" + data + "]，将进行解析处理.");

                        if (data.Length > 0)
                        {
                            DoOnPipeReceive(data.Trim(), this);
                        }
                        else
                        {
                            _log.WriteLog(LogType.ltNormal, "数据为空，放弃处理.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    _log.WriteError(ex, "ServerPipes", "管道数据读取产生异常.");
                }

                curPipe.Close();
                curPipe.Dispose();
                curPipe = null;

                if (IsStop) return;

                //取消权限控制，运行任意客户端用户进行通信
                PipeSecurity pipeSa = new PipeSecurity();
                pipeSa.SetAccessRule(new PipeAccessRule("Everyone",
                               PipeAccessRights.FullControl,
                               System.Security.AccessControl.AccessControlType.Allow));

                if (IsStop) return;
                curPipe = new NamedPipeServerStream(
                                _pipeName,
                                PipeDirection.InOut,
                                NamedPipeServerStream.MaxAllowedServerInstances,
                                PipeTransmissionMode.Message,
                                PipeOptions.Asynchronous, 0, 0, pipeSa);

                if (IsStop)
                {
                    curPipe.Close();
                    curPipe.Dispose();
                    curPipe = null;
                    return;
                }
                curPipe.BeginWaitForConnection(PipeAsyncCallback, curPipe);

                _pipeServer = curPipe;
            }
            catch (Exception ex)
            {
                _log.WriteError(ex, "ServerPipes", "管道服务异步调用触发异常.");
            }            
        }

        /// <summary>
        /// 启用管道异步处理
        /// </summary>
        private void StartPipe()
        {
            //取消权限控制，运行任意客户端用户进行通信
            PipeSecurity pipeSa = new PipeSecurity();
            pipeSa.SetAccessRule(new PipeAccessRule("Everyone",
                           PipeAccessRights.FullControl,
                           System.Security.AccessControl.AccessControlType.Allow));


            if (_pipeServer == null) _pipeServer = new NamedPipeServerStream(
                            _pipeName,
                            PipeDirection.InOut,
                            NamedPipeServerStream.MaxAllowedServerInstances,
                            PipeTransmissionMode.Message,
                            PipeOptions.Asynchronous, 0, 0, pipeSa);

            _pipeServer.BeginWaitForConnection(PipeAsyncCallback, _pipeServer);
        }

        /// <summary>
        /// 停止管道
        /// </summary>
        private void StopPipe()
        {
            if (_pipeServer != null)
            {
                _pipeServer.Close();
                _pipeServer.Dispose();
                _pipeServer = null;
            }
        }

        //private void PipeProcessWorker(object sender, DoWorkEventArgs e)
        //{
        //    if (_pipeWorker.CancellationPending) return;

        //    try
        //    {
        //        while (true)
        //        {
        //            try
        //            {
        //                if (_pipeWorker.CancellationPending) return;
        //                using (NamedPipeServerStream curPipeServer = new NamedPipeServerStream(
        //                        _pipeName,
        //                        PipeDirection.InOut,
        //                        NamedPipeServerStream.MaxAllowedServerInstances,
        //                        PipeTransmissionMode.Message,
        //                        PipeOptions.None))
        //                {
        //                    curPipeServer.WaitForConnection();
        //                    if (_pipeWorker.CancellationPending) return;

        //                    using (StreamReader sr = new StreamReader(curPipeServer))
        //                    {
        //                        if (_pipeWorker.CancellationPending) return;
        //                        string data = sr.ReadToEnd();

        //                        if (_pipeWorker.CancellationPending) return;

        //                        ServerHelper.Log.WriteLog(LogType.ltNormal, "接收到管道数据 [" + data + "]，将进行解析处理.");
        //                        DoOnPipeReceive(data.Trim(), this);
        //                    }
        //                }

        //                if (_pipeWorker.CancellationPending) return;
        //            }
        //            catch (Exception ex)
        //            {
        //                ServerHelper.Log.WriteError(ex, "ServerPipes", "管道循环处理异常,管道服务标识 [" + _instanceId + "]");
        //            }
        //        }//end......while
        //    }
        //    catch (Exception ex)
        //    {
        //        ServerHelper.Log.WriteError(ex, "ServerPipes", "管道监听服务异常,管道服务标识 [" + _instanceId + "]");
        //    }
        //    finally
        //    {
        //        if (_pipeWorker.CancellationPending) e.Cancel = true;
        //    }
        //}

        //private void SendAbortCmd()
        //{
        //    using (NamedPipeClientStream pipeClient = new NamedPipeClientStream(DEFAULT_PIPE_NAME))
        //    {
        //        pipeClient.Connect();
        //    }
        //}


        /// <summary>
        /// 启动服务
        /// </summary>
        /// <returns></returns>
        public bool StartServer()
        {
            if (_isRuning) return true;

            _isStop = false;

            _log.WriteLog(LogType.ltNormal, "开始启动管道监听服务,管道服务标识 [" + _instanceId + "].");
            StartPipe();
            //_pipeWorker.RunWorkerAsync();
            _log.WriteLog(LogType.ltNormal, "管道监听服务完成启动,管道服务标识 [" + _instanceId + "].");

            _isRuning = true;
            return _isRuning;// _pipeWorker.IsBusy;
        }


        /// <summary>
        /// 停止服务
        /// </summary>
        public void StopServer()
        {
            _isStop = true;
            if (_isRuning == false) return;

            _log.WriteLog(LogType.ltNormal, "开始停止管道监听服务,管道服务标识 [" + _instanceId + "].");
            StopPipe();
            //_pipeWorker.CancelAsync();
            _log.WriteLog(LogType.ltNormal, "管道监听服务完成停止,管道服务标识 [" + _instanceId + "].");

            _isRuning = false;
            //int i = 0;
            //while (_pipeWorker.IsBusy)
            //{
            //    System.Threading.Thread.Sleep(10);

            //    i = i + 1;

            //    if (i > 300) break;
            //}

            //System.Threading.Thread.Sleep(50);
        }

        /// <summary>
        /// 释放托管资源
        /// </summary>
        protected override void DisposeHostedRes()
        {
            try
            {
                _isStop = true;

                OnPipeRecevie = null;

                if (_isRuning) StopServer();

                //if (_pipeWorker != null)
                //{
                //    if (_pipeWorker.IsBusy) StopServer();

                //    _pipeWorker.Dispose();
                //    _pipeWorker = null;
                //}
            }
            catch (Exception ex)
            {
                _log.WriteError(ex);
            }
        }

        /// <summary>
        /// 释放非托管资源
        /// </summary>
        protected override void DisposeNotHostedRes()
        {
            //......
        }
    }

}
