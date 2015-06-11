using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Threading;

namespace DesktopHeapExhauster
{
	class Program
	{
		static void Main(string[] args)
		{
			var decoderService = new JpegBitmapDecoderService();
			int i = 0;
			do
			{
				i++;
				Thread t = new Thread(() => 
				{
					//Dispatcher dispatcher = Dispatcher.CurrentDispatcher;

					decoderService.ReadExifDataUsingJPEGDecoder(@"D:\Temp\IMG_0235.JPG");

					//dispatcher.InvokeShutdown();
				});
				t.Start();

				Console.WriteLine(i);
			}
			while (true);
		}
	}
}
