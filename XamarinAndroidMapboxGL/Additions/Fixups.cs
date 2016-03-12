using System;
using Java.Text;
using Com.Mapbox.Mapboxsdk;
using Android.Runtime;
using Android.Content;
using Android.Content.PM;
using Java.Lang;
using Android.Util;
using Android.OS;

namespace Com.Mapbox.Mapboxsdk.Utils
{
	public class ApiAccess : Java.Lang.Object
	{
		public static string GetToken (Context context)
		{
			try 
			{
			    var ai = context.PackageManager.GetApplicationInfo(context.PackageName, PackageInfoFlags.MetaData);
			    var bundle = ai.MetaData;
				return bundle.GetString("com.mapbox.AccessToken");
			} 
			catch (Android.Content.PM.PackageManager.NameNotFoundException e) 
			{
			    Log.Error("Mapbox", "Failed to load meta-data, NameNotFound: " + e.Message);
			} 
			catch (NullPointerException e) 
			{
				Log.Error("Mapbox", "Failed to load meta-data, NullPointer: " + e.Message);			
			}

			return null;
		}
	}
}

namespace Com.Mapbox.Mapboxsdk.Annotations
{
	public partial class MarkerOptions
	{
		static IntPtr getThisPointer;
		protected override Java.Lang.Object RawThis {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.mapbox.mapboxsdk.annotations']/class[@name='MarkerOptions']/method[@name='getThis' and count(parameter)=0]"
			[Register ("getThis", "()Lcom/mapbox/mapboxsdk/annotations/MarkerOptions;", "GetGetThisHandler")]
			get {
				if (getThisPointer == IntPtr.Zero)
					getThisPointer = JNIEnv.GetMethodID (class_ref, "getThis", "()Lcom/mapbox/mapboxsdk/annotations/MarkerOptions;");
				try {
					return global::Java.Lang.Object.GetObject<global::Com.Mapbox.Mapboxsdk.Annotations.MarkerOptions> (JNIEnv.CallObjectMethod  (Handle, getThisPointer), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static IntPtr getMarkerPointer;
		protected override Java.Lang.Object RawMarker {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.mapbox.mapboxsdk.annotations']/class[@name='MarkerOptions']/method[@name='getMarker' and count(parameter)=0]"
			[Register ("getMarker", "()Lcom/mapbox/mapboxsdk/annotations/Marker;", "GetGetMarkerHandler")]
			get {
				if (getMarkerPointer == IntPtr.Zero)
					getMarkerPointer = JNIEnv.GetMethodID (class_ref, "getMarker", "()Lcom/mapbox/mapboxsdk/annotations/Marker;");
				try {
					return global::Java.Lang.Object.GetObject<global::Com.Mapbox.Mapboxsdk.Annotations.Marker> (JNIEnv.CallObjectMethod  (Handle, getMarkerPointer), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}
	}

    public partial class Marker
    {
        public override global::System.Int32 CompareTo (global::Java.Lang.Object another)
        {
            var annotation = another as Annotation;

            if (another != null)
            {
                return CompareTo(annotation);
            }

            return -1;
        }
    }

    public partial class Polygon
    {
        public override global::System.Int32 CompareTo (global::Java.Lang.Object another)
        {
            var annotation = another as Annotation;

            if (another != null)
            {
                return CompareTo(annotation);
            }

            return -1;
        }
    }

    public partial class Polyline
    {
        public override global::System.Int32 CompareTo (global::Java.Lang.Object another)
        {
            var annotation = another as Annotation;

            if (another != null)
            {
                return CompareTo(annotation);
            }

            return -1;
        }
    }
}

