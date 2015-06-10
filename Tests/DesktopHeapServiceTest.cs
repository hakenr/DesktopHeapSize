using System;
using Havit.DesktopHeapSize;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
	[TestClass]
	public class DesktopHeapServiceTest
	{
		[TestMethod]
		public void DesktopHeapService_GetCurrentDesktopHeapSize_ShouldReturnPositiveNumber()
		{
			DesktopHeapService service = new DesktopHeapService();

			ulong result = service.GetCurrentDesktopHeapSize();

			Assert.IsTrue(result > 0);
		}
	}
}
