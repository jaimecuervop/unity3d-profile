// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 4.0.30319.1
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System.IO;
using System.Xml;
using System.Text;
using System.Collections.Generic;

namespace Soomla.Profile
{
	#if UNITY_EDITOR
	[InitializeOnLoad]
	#endif
	public class ProfileManifestTools : ISoomlaManifestTools
	{
		#if UNITY_EDITOR
		static ProfileManifestTools instance = new ProfileManifestTools();
		static ProfileManifestTools ()
		{
			SoomlaManifestTools.ManTools.Add(instance);
		}
		
		public void UpdateManifest(){
			//general Manifest tags
			
			//platform specific tags
			HandleGoogleManifest ();
			HandleTwitterManifest ();
		}
		
		public void HandleGoogleManifest()
		{
			bool? enabled = false;
			bool value = ProfileSettings.IntegrationState.TryGetValue ("google", out enabled);

			//check if google+ is enabled in settings
			if (value && enabled.Value)
			{
				//google+ permissions
				SoomlaManifestTools.SetPermission("android.permission.INTERNET");
				SoomlaManifestTools.SetPermission("android.permission.GET_ACCOUNTS");
				SoomlaManifestTools.SetPermission("android.permission.USE_CREDENTIALS");
				
				//google+ activity
				SoomlaManifestTools.AddActivity("com.soomla.profile.social.google.SoomlaGooglePlus$SoomlaGooglePlusActivity",
				                                new Dictionary<string, string>() {
					{"theme", "@android:style/Theme.Translucent.NoTitleBar.Fullscreen"}
				});
				
				//google play services version
				SoomlaManifestTools.AddMetaDataTag("com.google.android.gms.version", "@integer/google_play_services_version");
			}
			else 
			{
				// NOTE: We don't remove permissions or general purpose meta-data tags b/c other modules might need them.
				// 		This is why they are commented out

//				SoomlaManifestTools.RemovePermission("android.permission.INTERNET");
//				SoomlaManifestTools.RemovePermission("android.permission.GET_ACCOUNTS");
//				SoomlaManifestTools.RemovePermission("android.permission.USE_CREDENTIALS");
				SoomlaManifestTools.RemoveActivity("com.soomla.profile.social.google.SoomlaGooglePlus$SoomlaGooglePlusActivity");
//				SoomlaManifestTools.RemoveApplicationElement("meta-data", "com.google.android.gms.version");
			}
		}
		
		public void HandleTwitterManifest()
		{
			bool? enabled = false;
			bool value = ProfileSettings.IntegrationState.TryGetValue ("twitter", out enabled);

			//check if twitter is enabled in settings
			if (value && enabled.Value)
			{
				//twitter activity
				SoomlaManifestTools.AddActivity("com.soomla.profile.social.twitter.SoomlaTwitter$SoomlaTwitterActivity",
				                                new Dictionary<string, string>() {
					{"theme", "@android:style/Theme.Translucent.NoTitleBar.Fullscreen"}
				});
			}
			else 
			{
				SoomlaManifestTools.RemoveActivity("com.soomla.profile.social.twitter.SoomlaTwitter$SoomlaTwitterActivity");
			}
		}
		#endif
	}
	
}