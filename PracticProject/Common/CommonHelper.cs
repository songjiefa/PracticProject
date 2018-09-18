using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace Common
{
	/// <summary>
	/// 共用工具类
	/// </summary>
	public static class CommonHelper
	{
		public static String CalculateMD5(this String i_str)
		{
			var bytes = Encoding.UTF8.GetBytes(i_str);

			return CalculateMD5(bytes);
		}

		public static String CalculateMD5(this byte[] i_bytes)
		{
			using (var md5 = MD5.Create())
			{
				var computeBytes = md5.ComputeHash(i_bytes);
				String result = String.Empty;
				foreach (var computeByte in computeBytes)
				{
					result += computeByte.ToString("X").Length == 1
						? "0" + computeByte.ToString("X")
						: computeByte.ToString("X");
				}

				return result;
			}
		}

		public static String CalculateMD5(this Stream i_stream)
		{
			using (var md5 = MD5.Create())
			{
				var computeBytes = md5.ComputeHash(i_stream);
				String result = String.Empty;
				foreach (var computeByte in computeBytes)
				{
					result += computeByte.ToString("X").Length == 1
						? "0" + computeByte.ToString("X")
						: computeByte.ToString("X");
				}

				return result;
			}
		}

		public static String GenerateVerifyCode(Int32 i_length)
		{
			var chars = "1234567890qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM".ToCharArray();
			var results = String.Empty;
			var random = new Random();
			for (var i = 0; i < i_length; i++)
			{
				results += random.Next(chars.Length);
			}

			return results;
		}
	}
}
