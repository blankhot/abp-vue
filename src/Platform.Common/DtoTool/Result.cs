﻿using System;
using System.Collections.Generic;
using System.Text;
using Platform.Enums;

namespace Platform.Common.DtoTool
{
    public class Result : IResult
    {
        /// <summary>
        /// 操作成功
        /// </summary>
        public const string SuccessCode = "Success";


        private string _message;

        /// <summary>
        /// 返回结果
        /// </summary>
        public Result()
        {

        }

        /// <summary>
        /// 返回结果
        /// </summary>
        /// <param name="code">状态码</param>
        /// <param name="message">提示信息</param>
        public Result(ResponseStatus code, string message = null)
        {
            Code = code;
            Message = message;
        }

        /// <summary>
        /// 结果状态码
        /// </summary>
        public ResponseStatus Code { get; set; }

        /// <summary>
        /// 提示信息
        /// </summary>
        /// <example>操作成功</example>
        public string Message
        {
            get { return _message ; }
            set { _message = value; }
        }

        /// <summary>
        /// 是否成功
        /// </summary>
        public bool Success => Code == ResponseStatus.OK;

        public DateTime Time { get; set; }

        #region 静态函数

        /// <summary>
        /// 返回指定 Code
        /// </summary>
        public static Result FromCode(ResponseStatus code, string message = null)
        {
            return new Result(code, message);
        }

        /// <summary>
        /// 返回指定 Code
        /// </summary>
        public static Result<T> FromCode<T>(ResponseStatus code, string message = null)
        {
            return new Result<T>(code, message);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="code"></param>
        /// <param name="message"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static Result<T> FromCode<T>(ResponseStatus code, T data, string message = null)
        {
            return new Result<T>(code, message, data);
        }

        /// <summary>
        /// 返回异常信息
        /// </summary>
        public static Result FromError(string message, ResponseStatus code = ResponseStatus.Fail)
        {
            return new Result(code, message);
        }

        /// <summary>
        /// 返回异常信息
        /// </summary>
        public static Result<T> FromError<T>(string message, ResponseStatus code = ResponseStatus.Fail)
        {
            return new Result<T>(code, message);
        }

        /// <summary>
        /// 返回数据
        /// </summary>
        public static Result<T> FromData<T>(T data)
        {
            return new Result<T>(data);
        }

        /// <summary>
        /// 返回数据
        /// </summary>
        public static Result<T> FromData<T>(T data, string message)
        {
            return new Result<T>(ResponseStatus.OK, message, data);
        }

        /// <summary>
        /// 返回成功
        /// </summary>
        public static Result Ok(string message = null)
        {
            return FromCode(ResponseStatus.OK, message);
        }

        /// <summary>
        /// 返回成功
        /// </summary>
        public static Result<T> Ok<T>(T data)
        {
            return FromData(data);
        }

        #endregion
    }
    /// <summary>
    /// 返回结果
    /// </summary>
    public class Result<TData> : Result, IResult<TData>
    {
        /// <summary>
        /// 返回结果
        /// </summary>
        public Result()
        {

        }

        /// <summary>
        /// 返回结果
        /// </summary>
        public Result(TData data)
            : base(ResponseStatus.OK)
        {
            Data = data;
        }

        /// <summary>
        /// 返回结果
        /// </summary>
        /// <param name="code">状态码</param>
        /// <param name="message">提示信息</param>
        public Result(ResponseStatus code, string message = null)
            : base(code, message)
        {

        }

        /// <summary>
        /// 返回结果
        /// </summary>
        /// <param name="code"></param>
        /// <param name="message"></param>
        /// <param name="data"></param>
        public Result(ResponseStatus code, string message = null, TData data = default(TData))
          : base(code, message)
        {
            Data = data;
        }

        /// <summary>
        /// 返回结果数据
        /// </summary>
        public TData Data { get; set; }
    }
}
