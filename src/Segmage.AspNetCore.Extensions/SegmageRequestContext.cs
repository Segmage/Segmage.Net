using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Segmage.AspNetCore.Extensions
{
	public static class SegmageRequestContext
	{
		private static readonly AsyncLocal<SgSession> _currentSession = new AsyncLocal<SgSession>();

		public static SgSession Current
		{
			get => _currentSession.Value;
			set => _currentSession.Value = value;
		}

		public static void Clear()
		{
			_currentSession.Value = null;
		}
	}
}
