using UnityEngine;

/* PointInTime sinifi oyundaki toplarin her bir framede bulunduklari yer ve yon bilgisini tutmak icin olusturuldu.*/
public class PointInTime
{

	public Vector3 position;
	public Quaternion rotation;

	public PointInTime(Vector3 _position, Quaternion _rotation)
	{
		position = _position;
		rotation = _rotation;
	}

}