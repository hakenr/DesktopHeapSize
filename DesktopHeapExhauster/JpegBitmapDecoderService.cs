using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace DesktopHeapExhauster
{
	public class JpegBitmapDecoderService
	{
		public void ReadExifDataUsingJPEGDecoder(string filename)
		{
			using (FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read))
			{
				BitmapDecoder decoder = new JpegBitmapDecoder(fs, BitmapCreateOptions.None, BitmapCacheOption.None);
				if (decoder != null && decoder.Frames != null)
				{
					foreach (var frm in decoder.Frames)
					{
						if (frm != null && frm.Metadata != null)
						{
							var meta = frm.Metadata as BitmapMetadata;
							if (meta != null)
							{
								if (!String.IsNullOrWhiteSpace(meta.Title))
								{
									var title = meta.Title.Trim();
								}
								if (!String.IsNullOrWhiteSpace(meta.Comment))
								{
									var comment = meta.Comment.Trim();
								}
								DateTime taken;
								if (!String.IsNullOrWhiteSpace(meta.DateTaken) && DateTime.TryParse(meta.DateTaken, out taken))
								{
									// NOOP
								}
							}

						}
					}
				}
				fs.Close(); //not needed if using? 
			}
		}
	}
}