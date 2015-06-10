using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Havit.DesktopHeapSize
{
	public class DesktopHeapService
	{
		public ulong GetCurrentDesktopHeapSize()
		{
#pragma warning disable CS0618 // Type or member is obsolete
			IntPtr desktopHandle = GetThreadDesktop((uint)AppDomain.GetCurrentThreadId());
#pragma warning restore CS0618 // Type or member is obsolete

			uint nLength = 4;
            byte[] result = new byte[nLength];
			uint lpnLengthNeeded;
            GetUserObjectInformation(desktopHandle, UOI_HEAPSIZE, result, nLength, out lpnLengthNeeded);

			return BitConverter.ToUInt32(result, 0);
		}


		/// <remarks>
		/// https://msdn.microsoft.com/en-us/library/windows/desktop/ms683232(v=vs.85).aspx
		/// http://www.pinvoke.net/default.aspx/user32.getthreaddesktop
		/// </remarks>
		[DllImport("user32.dll", SetLastError = true)]
		private static extern IntPtr GetThreadDesktop(uint dwThreadId);

		/// <remarks>
		/// https://msdn.microsoft.com/en-us/library/ms683238.aspx
		/// http://www.pinvoke.net/default.aspx/user32.getuserobjectinformation
		/// </remarks>
		[DllImport("user32.dll", SetLastError = true)]
		private static extern bool GetUserObjectInformation(IntPtr hObj, int nIndex, [Out] byte[] heapSize, uint nLength, out uint lpnLengthNeeded);

		private const int UOI_FLAGS = 1;
		private const int UOI_NAME = 2;
		private const int UOI_TYPE = 3;
		private const int UOI_USER_SID = 4;
		private const int UOI_HEAPSIZE = 5; //Windows Server 2003 and Windows XP/2000:  This value is not supported.
		private const int UOI_IO = 6;       //Windows Server 2003 and Windows XP/2000:  This value is not supported.


	}
}