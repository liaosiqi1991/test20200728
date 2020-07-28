using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zlMedimgSystem.Services
{
    public class Dir
    {
        /// <summary>
        /// 获取APP根目录
        /// </summary>
        /// <returns></returns>
        static public string GetAppRootDir()
        {
            string tmpDir = System.Windows.Forms.Application.StartupPath + @"\";
            if (System.IO.Directory.Exists(tmpDir) == false) System.IO.Directory.CreateDirectory(tmpDir);

            return tmpDir;
        }

        /// <summary>
        /// 获取应用程序临时目录
        /// </summary>
        /// <returns></returns>
        static public string GetAppTempDir()
        {
            string tmpDir = System.Windows.Forms.Application.StartupPath + @"\temp";
            if (System.IO.Directory.Exists(tmpDir) == false) System.IO.Directory.CreateDirectory(tmpDir);

            return tmpDir;
        }

        /// <summary>
        /// 获取应用程序失败目录
        /// </summary>
        /// <returns></returns>
        static public string GetAppFailedDir()
        {
            string failedDir = System.Windows.Forms.Application.StartupPath + @"\failed";
            if (System.IO.Directory.Exists(failedDir) == false) System.IO.Directory.CreateDirectory(failedDir);

            return failedDir;
        }

        static public string GetAppDebugDir()
        {
            string debugDir = System.Windows.Forms.Application.StartupPath + @"\Solution\Debug";
            if (System.IO.Directory.Exists(debugDir) == false) System.IO.Directory.CreateDirectory(debugDir);

            return debugDir;
        }

        static public string GetAppCompileDir()
        {
            string compileDir = System.Windows.Forms.Application.StartupPath + @"\Solution\Compile";
            if (System.IO.Directory.Exists(compileDir) == false) System.IO.Directory.CreateDirectory(compileDir);

            return compileDir;
        }

        static public string GetAppTemplateDir()
        {
            string templateDir = System.Windows.Forms.Application.StartupPath + @"\Solution\Template";
            if (System.IO.Directory.Exists(templateDir) == false) System.IO.Directory.CreateDirectory(templateDir);

            return templateDir;
        }

        static public string GetAppProjectDir()
        {
            string projectDir = System.Windows.Forms.Application.StartupPath + @"\Solution\Project";
            if (System.IO.Directory.Exists(projectDir) == false) System.IO.Directory.CreateDirectory(projectDir);

            return projectDir;
        }

        /// <summary>
        /// 获取应用程序资源目录
        /// </summary>
        /// <returns></returns>
        static public string GetAppResourceDir()
        {
            string resourceDir = System.Windows.Forms.Application.StartupPath + @"\resource";
            if (System.IO.Directory.Exists(resourceDir) == false) System.IO.Directory.CreateDirectory(resourceDir);

            return resourceDir;
        }
    }
}
