using System;

namespace Assets.SDK
{
	public sealed class InitAndroidDoudouAttribute : JoyYouSDKAttribute
	{
		public override string NAME
		{
			get
			{
				return "__Android_Doudou__";
			}
		}

		public InitAndroidDoudouAttribute(int appId, string notifyObjName, string url4cb, bool isOriPortrait, bool isOriLandscapeLeft, bool isOriLandscapeRight, bool isOriPortraitUpsideDown, bool logEnable) : base(0, string.Empty, notifyObjName, true, true, 0, url4cb, isOriPortrait, isOriLandscapeLeft, isOriLandscapeRight, isOriPortraitUpsideDown, logEnable)
		{
		}
	}
}
