
using System.Text;

using System.IO.Pipes;

namespace zlMedimgSystem.Services
{
    public class ClientPipes
    {
        private string _pipeName = "";

        public ClientPipes(string pipeName = "")
        {
            _pipeName = pipeName;

            if (string.IsNullOrEmpty(_pipeName) == true)
            {
                _pipeName = ServerPipes.DEFAULT_PIPE_NAME;
            }
        }

        /// <summary>
        /// 发送数据 
        /// </summary>
        /// <param name="pipeData">待发送的数据</param>
        /// <param name="timeOut">超时，单位毫秒</param>
        public void SendData(string pipeData, int timeOut=30000)
        {
            byte[] data = Encoding.UTF8.GetBytes(pipeData);

            using (NamedPipeClientStream pipeClient = new NamedPipeClientStream(".", _pipeName))
            {
                pipeClient.Connect(timeOut);
                pipeClient.Write(data, 0, data.Length);
                pipeClient.Flush();
                pipeClient.WaitForPipeDrain();
            }
        }
    }
}
