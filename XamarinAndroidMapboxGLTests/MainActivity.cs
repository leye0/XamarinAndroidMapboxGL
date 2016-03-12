using System;
using System.Linq;
using Android.Animation;
using Android.App;
using Android.OS;
using Android.Views.Animations;
using Android.Widget;
using Com.Mapbox.Mapboxsdk.Annotations;
using Com.Mapbox.Mapboxsdk.Constants;
using Com.Mapbox.Mapboxsdk.Geometry;
using Com.Mapbox.Mapboxsdk.Maps;
using Com.Mapbox.Mapboxsdk.Utils;
using System.Collections.Generic;

namespace XamarinAndroidMapboxGLTests
{

	// DON'T FORGET to set your Mapbox API AccessToken in AndroidManifest.xml

	[Activity (Label = "XamarinAndroidMapboxGLTests", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		private MapboxMap _mapBox;

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			SetContentView (Resource.Layout.Main);
			var map = FindViewById<MapView> (Resource.Id.mapView);
			map.AccessToken = ApiAccess.GetToken (this);
			map.StyleUrl = Style.Light;
			map.OnCreate (savedInstanceState);

			var mapBox = new MapAsync();
			mapBox.MapReady += (s,e) =>
			{
				_mapBox = mapBox.Map;
				AnimateMarkers();
			}; 

			map.GetMapAsync(mapBox);
		}

		private List<Marker> _markers = new List<Marker>();

		private void AnimateMarkers()
		{
			Random random = new Random();
            var markerOptions = new MarkerOptions[20];
			markerOptions = markerOptions.Select(x => x = new MarkerOptions().SetPosition(new LatLng(random.NextDouble()*100, random.NextDouble()*100))).ToArray();
            var destinations = new LatLng[20];
			destinations = destinations.Select(x => x = new LatLng(random.NextDouble() * 100, random.NextDouble() * 100)).ToArray();
			var markerAnimator = ValueAnimator.OfInt(new int[1] {0});
            markerAnimator.SetDuration(1000);
            markerAnimator.RepeatCount = ValueAnimator.Infinite;
            markerAnimator.RepeatMode = ValueAnimatorRepeatMode.Restart;
            markerAnimator.SetInterpolator(new LinearInterpolator());

			_markers = _mapBox.AddMarkers(markerOptions).ToList();

			markerAnimator.Update += (s, e) =>
			{
				for (int i = 0; i < _markers.Count; i++)
				{
					var marker = _markers[i];
					var lat = marker.Position.Latitude - 1;
					var lng = marker.Position.Longitude - 1;
					_markers[i].Position = new LatLng(lat, lng);
				}	
			};
			markerAnimator.Start();
		}

		private class MapAsync : Java.Lang.Object, IOnMapReadyCallback
		{
			public MapboxMap Map { get; private set; }

  			public event EventHandler MapReady;

			void Com.Mapbox.Mapboxsdk.Maps.IOnMapReadyCallback.OnMapReady (Com.Mapbox.Mapboxsdk.Maps.MapboxMap map)
			{
				Map = map;
				var handler = MapReady;
				if (handler != null)
				{
					handler(this, EventArgs.Empty);
				}
			}
		}
	}
}