// Fix binding limitations and mimick Google Map method names
using Com.Mapbox.Mapboxsdk.Annotations;
using Com.Mapbox.Mapboxsdk.Geometry;


public static class MarkerExtensions
{
	public static MarkerOptions SetPosition(this MarkerOptions markerOptions, LatLng position)
	{
		return (MarkerOptions)markerOptions.Position(position);
	}
}