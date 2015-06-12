using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Result
{
    /// <summary>
    /// 贯穿系统的返回参数
    /// </summary>
    /// <typeparam name="T">常用bool类型，返回方法是否成功</typeparam>
    /// <typeparam name="M">返回所需的结果</typeparam>
    public class Result<T, M>
    {
        private T _success;
        private M _erroemsg;

        public T Succsss
        {
            get { return _success; }
            set { _success = value; }
        }

        public M ErrorMsg
        {
            get { return _erroemsg; }
            set { _erroemsg = value; }
        }

        public Result()
        {
            this._success = default(T);
            this._erroemsg = default(M);
        }

        public Result(T _t)
        {
            _success = _t;
            _erroemsg = default(M);
        }

        public Result(M _m)
        {
            _success = default(T);
            _erroemsg = _m;
        }

        public Result(T _t, M _m)
        {
            _success = _t;
            _erroemsg = _m;
        }

    }
}
