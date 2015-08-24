using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Log
{
    public class LoggerWriter
    {
        public static void AddLog(System.Diagnostics.StackTrace stackTrace)
        {
            /*
            string sFileName = stackTrace.GetFrame(0).GetFileName();
            int iFileLineNumber = stackTrace.GetFrame(0).GetFileLineNumber();
            int iFileColumnNumber = stackTrace.GetFrame(0).GetFileColumnNumber();
            string sMethod = stackTrace.GetFrame(0).GetMethod().Name;
            string sMsg = string.Format("在文件：{0}\t的第{1}行第{2}列\t执行{3}方法", sFileName, iFileLineNumber.ToString(), iFileColumnNumber.ToString(), sMethod);
            WriteLog(sMsg);
             */
            //当前堆栈信息
            System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(true);
            System.Diagnostics.StackFrame[] sfs = st.GetFrames();

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < sfs.Length; ++i)
            {
                StringBuilder _sbInner = new StringBuilder();
                //非用户代码,系统方法及后面的都是系统调用，不获取用户代码调用结束
                if (System.Diagnostics.StackFrame.OFFSET_UNKNOWN == sfs[i].GetILOffset()) break;
                var sf = sfs[i];
                System.Reflection.MethodBase method = sf.GetMethod();
                string sMethod = method.DeclaringType.FullName + "." + sf.GetMethod().Name;
                _sbInner.Append(string.Format("在文件{0}（嵌套层级{1}）的第{2}行执行{3}.{4}(", sf.GetFileName(), i.ToString(), sf.GetFileLineNumber().ToString(), method.DeclaringType.FullName, sf.GetMethod().Name));
                System.Reflection.ParameterInfo[] par = method.GetParameters();
                for (int j = 0; j < par.Length; j++)
                {
                    _sbInner.Append(par[j].ParameterType.FullName + " " + par[j].Name + " = 未知值");
                    if (j != par.Length - 1) sb.Append(',');
                }
                _sbInner.Append(")\n");
                sb.Append(_sbInner);
            }
            st = null;
            sfs = null;
            WriteLog(sb.ToString());
        }

        /// <summary>
        /// 获取当前堆栈的上级调用方法列表,直到最终调用者,只会返回调用的各方法,而不会返回具体的出错行数，可参考：微软真是个十足的混蛋啊！让我们跟踪Exception到行把！（不明真相群众请入） 
        /// </summary>
        /// <returns></returns>
        static string GetStackTraceModelName()
        {
            //当前堆栈信息
            System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(1, true);
            System.Diagnostics.StackFrame[] sfs = st.GetFrames();
            //过虑的方法名称,以下方法将不会出现在返回的方法调用列表中
            string _filterdName = "ResponseWrite,ResponseWriteError,";
            string _fullName = string.Empty, _methodName = string.Empty;
            for (int i = 1; i < sfs.Length; ++i)
            {
                //非用户代码,系统方法及后面的都是系统调用，不获取用户代码调用结束
                if (System.Diagnostics.StackFrame.OFFSET_UNKNOWN == sfs[i].GetILOffset()) break;
                _methodName = sfs[i].GetMethod().Name;//方法名称
                if (_filterdName.Contains(_methodName)) continue;
                _fullName = _methodName + "()->" + _fullName;
            }
            st = null;
            sfs = null;
            _filterdName = _methodName = null;
            return _fullName.TrimEnd('-', '>');
        }

        public static void WriteLog(string message)
        {
            string filePath = "D:/LogFolder";
            try
            {
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }
                string path = filePath + "\\" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
                StreamWriter streamWriter;
                if (!File.Exists(path))
                {
                    streamWriter = File.CreateText(path);
                }
                else
                {
                    streamWriter = File.AppendText(path);
                }
                streamWriter.WriteLine("\n" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff ") + ": \n " + message);
                streamWriter.Close();
            }
            catch
            {
            }
        }
    }
}
