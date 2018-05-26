using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using RennixCMS.Infrastructure.Extionsions;

namespace RennixCMS.Infrastructure.WebApi
{
	[Serializable]
	public class ResponseResult<TData>
	{
		[JsonProperty("data")]
		public virtual TData Data { get; set; }

		[JsonProperty("success")]
		public virtual bool Success => this.Code == 200;

		[JsonProperty("code")]
		public virtual int Code { get; set; }

		[JsonProperty("error_message")]
		public virtual string ErrorMessage { get; set; }
	}

	[Serializable]
	public class ResponseResult : ResponseResult<object>
	{
		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="TData"></typeparam>
		/// <param name="data"></param>
		/// <param name="error"></param>
		/// <param name="code"></param>
		/// <returns></returns>
		public static ResponseResult<TData> Create<TData>(TData data, string error = "", int code = 200)
		{
			return new ResponseResult<TData>
			{
				Code = code,
				Data = data,
				ErrorMessage = error
			};
		}

		public static ResponseResult CreateExceptionResult(Exception ex)
		{
			var message = ex?.GetFriendlyMessage();

			if (string.IsNullOrEmpty(message))
				message = "应用程序错误";

			return new ResponseResult
			{
				Code = 500,
				Data = null,
				ErrorMessage = message
			};
		}

		public static ResponseResult CreateVoidResult()
		{
			return new ResponseResult
			{
				Code = 200,
				Data = null,
				ErrorMessage = string.Empty
			};
		}

	}
}
