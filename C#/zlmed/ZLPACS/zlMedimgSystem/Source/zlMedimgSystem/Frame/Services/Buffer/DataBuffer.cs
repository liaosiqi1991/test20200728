using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using zlMedimgSystem.Interface;

namespace zlMedimgSystem.Services
{
    /// <summary>
    /// 用于对需要从数据库缓存到本地磁盘的数据进行处理
    /// </summary>
    public class DataBuffer : DiskBuffer, IDataBuffer
    {
        //默认缓冲区版本
        private const int BUF_DEFAULT_VER_TAG = 0;       

        //是否需要进行加密的判断标记
        private const string BUF_SECURITY_TAG = "D827464D061248E580D93546472AEE6C";
        //不需要进行加密的判断标记
        private const string BUF_NOSECURITY_TAG = "895CABB40487438F8082F4D9CA31CC92";

        //用于加密缓冲区配置信息
        private const string BUF_DATA_ENCRYPT_KEY = "DEF9EFF1A06F410E90B51BEAB50E968A";     
        //用户加密缓冲区信息
        private const string BUF_CFG_ENCRYPT_KEY = "36720858D3FC4DB89C0855580C485D4C";

        #region 缓冲列字段名称定义

        private const string BUF_FIELD_KEY = "key";
        private const string BUF_FIELD_STATEMENT = "statement";
        private const string BUF_FIELD_TYPE = "type";
        private const string BUF_FIELD_PARS = "pars";
        private const string BUF_FIELD_VER = "version";
        private const string BUF_FIELD_SEC = "sec";

        #endregion

        private IDBQuery _db = null;      //数据库访问对象

        private DataTable _bufInf = null;
        private DataSet _memBuf= null;
                 
        #region 构造方法

        public DataBuffer(IDBQuery dataBase, string bufName)
            : this(dataBase, "", bufName)
        {
        }

        public DataBuffer(IDBQuery dataBase, string bufDir, string bufName)
            :base(bufDir,bufName)
        {
            if (dataBase == null)
            {
                throw new DBNullException();
            }

            _db = dataBase;

        }

        /// <summary>
        /// 创建保存缓冲区的表信息
        /// </summary>
        /// <returns></returns>
        private DataTable CreateBufTabInf()
        {
            DataTable dtBufinf = new DataTable("CacheInf");

            dtBufinf.Columns.Add(BUF_FIELD_KEY, typeof(System.String));
            dtBufinf.Columns.Add(BUF_FIELD_STATEMENT, typeof(System.String));
            dtBufinf.Columns.Add(BUF_FIELD_PARS, typeof(System.String));
            dtBufinf.Columns.Add(BUF_FIELD_TYPE, typeof(System.Int16));
            dtBufinf.Columns.Add(BUF_FIELD_VER, typeof(System.Int16));
            dtBufinf.Columns.Add(BUF_FIELD_SEC, typeof(System.String));

            return dtBufinf;
        }    

        #endregion

        #region 析构方法

        /// <summary>
        /// 释放托管资源
        /// </summary>
        protected override void DisposeHostedRes()
        {
            //清除注册信息
            if (_bufInf != null)
            {
                //_bufInf.WriteXml(_bufDir + BUF_CONFIG_FILE_NAME,   XmlWriteMode.IgnoreSchema);

                _bufInf.Clear();
                _bufInf.Dispose();
            }

            //清除缓冲数据
            if (_memBuf != null)
            {
                _memBuf.Clear();
                _memBuf.Dispose();
            }

            _db = null;

            base.DisposeHostedRes();
        }

        /// <summary>
        /// 释放非托管资源
        /// </summary>
        protected override void DisposeNotHostedRes()
        {
            base.DisposeNotHostedRes();
        }

        #endregion

        #region 注册缓冲信息

        /// <summary>
        /// 注册缓冲区信息
        /// </summary>
        /// <param name="key"></param>
        /// <param name="statment"></param>
        /// <returns></returns>
        public bool RegBufferInf(string key, string statment)
        {
            return RegBufferInf(key, statment, BufType.BufToDisk, false, null);
        }

        /// <summary>
        /// 缓冲区注册
        /// </summary>
        /// <param name="key"></param>
        /// <param name="statment"></param>
        /// <param name="pars"></param>
        /// <returns></returns>
        public bool RegBufferInf(string key, string statment, Dictionary<string, object> pars)
        {
            return RegBufferInf(key, statment, BufType.BufToDisk, false, pars);
        }

        /// <summary>
        /// 注册缓冲区信息
        /// </summary>
        /// <param name="key"></param>
        /// <param name="statment"></param>
        /// <returns></returns>
        public bool RegBufferInf(string key, string statment, Boolean isEncrypt)
        {
            return RegBufferInf(key, statment, BufType.BufToDisk, isEncrypt, null);
        }

        /// <summary>
        /// 缓冲区注册
        /// </summary>
        /// <param name="key"></param>
        /// <param name="statment"></param>
        /// <param name="pars"></param>
        /// <param name="isEncrypt"></param>
        /// <returns></returns>
        public bool RegBufferInf(string key, string statment, Boolean isEncrypt, Dictionary<string, object> pars)
        {
            return RegBufferInf(key, statment, BufType.BufToDisk, isEncrypt, pars);
        }

        /// <summary>
        /// 注册缓冲区信息
        /// </summary>
        /// <param name="key"></param>
        /// <param name="statment"></param>
        /// <param name="bufType"></param>
        /// <returns></returns>
        public bool RegBufferInf(string key, string statment, BufType bufType)
        {
            return RegBufferInf(key, statment, bufType, false, null);
        }

        /// <summary>
        /// 缓冲区注册
        /// </summary>
        /// <param name="key"></param>
        /// <param name="statment"></param>
        /// <param name="bufType"></param>
        /// <param name="pars"></param>
        /// <returns></returns>
        public bool RegBufferInf(string key, string statment, BufType bufType, Dictionary<string, object> pars)
        {
            return RegBufferInf(key, statment, bufType, false, pars);
        }

        /// <summary>
        /// 缓冲区注册
        /// </summary>
        /// <param name="key"></param>
        /// <param name="statment"></param>
        /// <param name="bufType"></param>
        /// <param name="isEncrypt"></param>
        /// <returns></returns>
        public bool RegBufferInf(string key, string statment, BufType bufType, Boolean isEncrypt)
        {
            return RegBufferInf(key, statment, bufType, isEncrypt, null);
        }

        /// <summary>
        /// 缓冲区注册
        /// </summary>
        /// <param name="key"></param>
        /// <param name="statment"></param>
        /// <param name="bufType"></param>
        /// <returns></returns>
        public bool RegBufferInf(string key, string statment, BufType bufType, Boolean isEncrypt, Dictionary<string, object> pars)
        {
            if (_bufInf == null)
            {
                _bufInf = CreateBufTabInf();

                ////如果存在缓冲区配置文件，则直接进行读取
                //if (File.Exists(_bufDir + BUF_CONFIG_FILE_NAME) == true)
                //{
                //    _bufInf.ReadXml(_bufDir + BUF_CONFIG_FILE_NAME);
                //}
            }

            //如果存在相同的值，则退出
            if (HasReg(key))
            {
                throw new UserException("该键值已经存在，不能重复注册。");
            }

            DataRow drBufInf = _bufInf.NewRow();
            string strPars = "";

            if (pars != null)
            {
                strPars = SerialObjectToString(pars);
            }

            drBufInf[BUF_FIELD_KEY] = key;
            drBufInf[BUF_FIELD_STATEMENT] = statment;
            drBufInf[BUF_FIELD_PARS] = strPars;
            drBufInf[BUF_FIELD_TYPE] = (int)bufType;
            drBufInf[BUF_FIELD_VER] = BUF_DEFAULT_VER_TAG;

            string sec = "";
            using (Encrypt crypt = new Encrypt(key + BUF_CFG_ENCRYPT_KEY))
            {
                if (isEncrypt == true)
                {
                    sec = crypt.EncryptStr(BUF_SECURITY_TAG);
                }
                else
                {
                    sec = crypt.EncryptStr(BUF_NOSECURITY_TAG);
                }

            }

            drBufInf[BUF_FIELD_SEC] = sec;

            _bufInf.Rows.Add(drBufInf);

            return true;
        }

        #endregion


        /// <summary>
        /// 判断是否包含key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool HasReg(string key)
        {
            if (_bufInf == null) return false;

            return (_bufInf.Select(BUF_FIELD_KEY +  "='" + key + "'").Length > 0) ? true : false;
        }

        /// <summary>
        /// 查询缓冲区数据
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public DataTable QueryBuffer(string key)
        {
            return QueryBuffer(key, BUF_DEFAULT_VER_TAG, true, null);
        }

        /// <summary>
        /// 查询缓冲区数据
        /// </summary>
        /// <param name="key"></param>
        /// <param name="hasCopy"></param>
        /// <returns></returns>
        public DataTable QueryBuffer(string key, bool hasCopy)
        {
            return QueryBuffer(key, BUF_DEFAULT_VER_TAG, hasCopy, null);
        }

        /// <summary>
        /// 查询缓冲区数据
        /// </summary>
        /// <param name="key"></param>
        /// <param name="bufVer"></param>
        /// <returns></returns>
        public DataTable QueryBuffer(string key, int bufVer)
        {
            return QueryBuffer(key, bufVer, true, null);
        }

        /// <summary>
        /// 查询缓冲区数据
        /// </summary>
        /// <param name="key"></param>
        /// <param name="bufVer"></param>
        /// <param name="hasCopy"></param>
        /// <returns></returns>
        public DataTable QueryBuffer(string key, int bufVer, bool hasCopy)
        {
            return QueryBuffer(key, bufVer, hasCopy, null);
        }

        /// <summary>
        /// 查询缓冲区数据
        /// </summary>
        /// <param name="key"></param>
        /// <param name="bufVer"></param>
        /// <param name="onRefreshBuffer"></param>
        /// <returns></returns>
        public DataTable QueryBuffer(string key, int bufVer, RefreshBufferEvent onRefreshBuffer)
        {
            return QueryBuffer(key, bufVer, true, onRefreshBuffer);
        }

        /// <summary>
        /// 从缓冲区查询数据
        /// </summary>
        /// <param name="key"></param>
        /// <param name="bufVer"></param>
        /// <param name="hasCopy"></param>
        /// <param name="onRefreshBuffer"></param>
        /// <returns></returns>
        public DataTable QueryBuffer(string key, int bufVer, bool hasCopy, RefreshBufferEvent onRefreshBuffer)
        {
            if (_bufInf == null)
            {
                throw new UserException("缓冲区信息对象无效，对象不能为 null。");
            }

            if (HasReg(key) == false)
            {
                throw new UserException("未注册的缓冲区数据查询。");
            }

            //取得对应的缓冲信息
            DataRow drBuf = _bufInf.Select(BUF_FIELD_KEY + "='" + key + "'")[0];

            BufType bufType = (BufType)Convert.ToInt16(drBuf[BUF_FIELD_TYPE]);
            int version = (int)Convert.ToInt16(drBuf[BUF_FIELD_VER]);
            string statment = Convert.ToString(drBuf[BUF_FIELD_STATEMENT]);
            string pars = Convert.ToString(drBuf[BUF_FIELD_PARS]);
            string sec = "";
            string bufFilePath = GetBufFilePath(key);

            //读取缓冲区的加密状态配置
            using (Encrypt crypt = new Encrypt(key + BUF_CFG_ENCRYPT_KEY))
            {
                sec = crypt.DecryptStr(Convert.ToString(drBuf[BUF_FIELD_SEC]));
            }

            if (bufType == BufType.BufToMem)
            {
                //从内存中读取数据
                //如果本地内存中不存在，或者缓冲版本与当前程序版本不同，则重新刷新缓冲区数据
                if ((_memBuf == null) || (_memBuf.Tables.Contains(key) == false))
                {
                    if (File.Exists(bufFilePath) == false || bufVer > version)
                    {
                        RefreshBuffer(key, bufVer, onRefreshBuffer);
                    }
                    else
                    {
                        //从本地读取缓冲数据
                        DataTable dtData = SecurityReadFileToDataBuf(key, sec, bufVer, onRefreshBuffer);

                        if (dtData == null) return null;

                        AddDataToMem(key, dtData);
                    }
                }

                //如果数据未缓冲到内存中，则返回null
                if ((_memBuf == null) || (_memBuf.Tables.Contains(key) == false)) return null;
            
                //使用clone方式，返回新的datatable对象
                if (hasCopy)
                {
                    return _memBuf.Tables[key].Copy();
                }
                else
                {
                    return _memBuf.Tables[key];
                }
            }
            else if (bufType == BufType.BufToDisk)
            {
                //从本地文件中读取数据
                //如果本地文件不存在，或者缓冲版本与当前程序版本不同，则重新刷新缓冲区数据
                if (File.Exists(bufFilePath) == false || bufVer > version)
                {
                    RefreshBuffer(key, bufVer, onRefreshBuffer);
                }

                //从本地文件读取数据
                return SecurityReadFileToDataBuf(key, sec, bufVer, onRefreshBuffer);
            }
            else
            {
                return ReadDataFromDB(statment, pars);
            }
        }

        /// <summary>
        /// 安全读取文件到缓冲
        /// </summary>
        /// <param name="key"></param>
        /// <param name="sec"></param>
        /// <param name="onRefreshBuf"></param>
        /// <returns></returns>
        private DataTable SecurityReadFileToDataBuf(string key, string sec, int bufVer, RefreshBufferEvent onRefreshBuffer)
        {
            try
            {
                return ReadFileToDataBuf(key, sec);
            }
            catch (Exception ex)
            {                
                Logger.OutputError(ex);
                Logger.OutputDebugStr("错误描述：缓冲数据读取失败，将从数据库中刷新后重新尝试加载。  \r\n  错误来源：" + ex.TargetSite);

                //如果文件读取失败，则重新刷新缓存
                RefreshBuffer(key, bufVer, onRefreshBuffer);

                return ReadFileToDataBuf(key, sec);
            }

        }

        /// <summary>
        /// 从文件中加载缓冲数据
        /// </summary>
        /// <param name="key"></param>
        /// <param name="sec"></param>
        /// <returns></returns>
        private DataTable ReadFileToDataBuf(string key, string sec)
        {
            //从磁盘读取缓存数据
            return ReadTableFormDiskBuf(key, ((sec == BUF_NOSECURITY_TAG) ? false : true));
        }

        /// <summary>
        /// 刷新缓冲区
        /// </summary>
        /// <param name="key"></param>
        public void RefreshBuffer(string key)
        {
            RefreshBuffer(key, BUF_DEFAULT_VER_TAG, null);
        }

        /// <summary>
        /// 刷新缓冲区
        /// </summary>
        /// <param name="key"></param>
        /// <param name="version"></param>
        public void RefreshBuffer(string key, int version)
        {
            RefreshBuffer(key, version, null);
        }

        /// <summary>
        /// 刷新缓冲区
        /// </summary>
        /// <param name="key"></param>
        /// <param name="onRefreshBuffer"></param>
        public void RefreshBuffer(string key, RefreshBufferEvent onRefreshBuffer)
        {
            RefreshBuffer(key, BUF_DEFAULT_VER_TAG, onRefreshBuffer);
        }

        /// <summary>
        /// 刷新缓冲区
        /// </summary>
        /// <param name="key"></param>
        /// <param name="version"></param>
        /// <param name="onRefreshBuffer"></param>
        public void RefreshBuffer(string key, int version, RefreshBufferEvent onRefreshBuffer)
        {
            if (_bufInf == null) return;

            //取得对应的缓冲信息
            DataRow drBuf = _bufInf.Select(BUF_FIELD_KEY + "='" + key + "'")[0];

            BufType bufType = (BufType)Convert.ToInt16(drBuf[BUF_FIELD_TYPE]);
            string statment = Convert.ToString(drBuf[BUF_FIELD_STATEMENT]);
            string pars = Convert.ToString(drBuf[BUF_FIELD_PARS]);
            string sec = "";

            //如果不缓冲，则退出
            if (bufType == BufType.BufNone) return;

            //读取缓冲区的加密状态配置
            using (Encrypt crypt = new Encrypt(key + BUF_CFG_ENCRYPT_KEY))
            {
                sec = crypt.DecryptStr(Convert.ToString(drBuf[BUF_FIELD_SEC]));
            }

            bool cusRead = false;
            DataTable dtData = null;

            if (onRefreshBuffer != null)
            {
                dtData = onRefreshBuffer(key, statment, _db, cusRead);
            }

            if (cusRead == false)
            {
                //从数据库读取数据
                dtData = ReadDataFromDB(statment, pars);
            }

            if (dtData == null) return;
            dtData.TableName = key;

            WriteTableToDiskBuf(key, dtData, ((sec == BUF_NOSECURITY_TAG) ? false : true));

            if (bufType == BufType.BufToMem)
            {
                AddDataToMem(key, dtData);
            }

            //更新缓冲区版本信息
            if (version != BUF_DEFAULT_VER_TAG)
            {
                //刷新数据后，回写缓冲区版本信息
                drBuf[BUF_FIELD_VER] = version;     
            }
        }

        /// <summary>
        /// 添加数据到内存
        /// </summary>
        /// <param name="key"></param>
        /// <param name="dtData"></param>
        private void AddDataToMem(string key, DataTable dtData)
        {
            if (_memBuf == null)
            {
                _memBuf = new DataSet("MemBuf");
            }

            //保存数据到内存
            if (_memBuf.Tables.Contains(key)) _memBuf.Tables.Remove(key);

            dtData.TableName = key;
            _memBuf.Tables.Add(dtData);
        }

        /// <summary>
        /// 读取数据
        /// </summary>
        /// <param name="statment"></param>
        /// <returns></returns>
        private DataTable ReadDataFromDB(string statment, string pars)
        {
            if (_db == null)
            {
                throw new DBNullException();
            }

            Dictionary<string, object> objPars = (Dictionary<string, object>)StringToSerialObject(pars);

            //判断是否包含select语句，如果不包含，则表示存储过程
            if (statment.ToUpper().IndexOf("SELECT") >= 0)
            {
                //执行查询语句
                return _db.ExecuteSQL(statment, objPars);
            }
            else
            {
               //执行存储过程
                return _db.ExecuteProcedureOneOutput(statment, objPars);
            }
        }

        /// <summary>
        /// 移除内存缓存数据
        /// </summary>
        /// <param name="key"></param>
        public void RemoveBufferData(string key)
        {
            if (_memBuf == null) return;

            if (_memBuf.Tables.Contains(key) == true)
            {
                _memBuf.Tables[key].Clear();
                _memBuf.Tables.Remove(key);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        public void UnRegBufferInf(string key)
        {
            if (HasReg(key) == false) return;

            //移除缓冲的数据
            RemoveBufferData(key);

            //移除buf配置信息
            DataRow[] drReg = _bufInf.Select(BUF_FIELD_KEY + "='" + key + "'");

            if (drReg.Length <= 0) return;
            _bufInf.Rows.Remove(drReg[0]);

            //删除buf磁盘文件
            File.Delete(GetBufFilePath(key));
        }
    }
}
