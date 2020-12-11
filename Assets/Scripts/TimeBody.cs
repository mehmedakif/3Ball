using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

/* TimeBody nesnelerin zamana bagli govdelerini temsil etmektedir. Replay modunda gosterilecek davranislari yonetir.*/
public class TimeBody : MonoBehaviour
{
	bool isRewinding = false;
	bool isRecording = false;
	public float recordTime = 5f;
	public Toggle replayToggle;
	public Camera replayCamera;
	public Camera mainCamera;
	Vector3 startingPoint;

	List<PointInTime> pointsInTime;

	Rigidbody rb;

	void Start()
	{
		/*Nesnelerin zamandaki konumlarini liste halinde tutuyoruz. Boylecek uzerinde ileri geri islemler yapmak mumkun olur.*/
		pointsInTime = new List<PointInTime>();
		rb = GetComponent<Rigidbody>();
		startingPoint = rb.position;
	}

	void Update()
	{
		if (rb.velocity.magnitude < 0.1f && replayToggle.isOn && rb.position != startingPoint)
		{
			StartRewind();		
			isRecording = false;
		}
		
		if (Input.GetKeyDown(KeyCode.Space)) 
		{
			StopReplay();
			isRecording = true;
		}

		if(rb.velocity.magnitude > 0.1)
        {
			replayToggle.gameObject.SetActive(false);
        }
        else
        {
			replayToggle.gameObject.SetActive(true);
		}
	}

	void FixedUpdate()
	{
		if (isRewinding) 
		{
			Replay();
		}
        else 
		{
            if (isRecording) 
			{				
				Record();	
			}
		}
	}
	/*Nesnenin kaydedilmis zamandaki konumlarini geri saran fonksiyondur.*/
	void Replay()
	{
		if (pointsInTime.Count > 0)
		{
			
			PointInTime pointInTime = pointsInTime[0];
			transform.position = pointInTime.position;
			transform.rotation = pointInTime.rotation;
			pointsInTime.RemoveAt(0);

		}
		else
		{
			StopReplay();
		}

	}
	/*Nesnenin kaydedilmis zamandaki konumlarini kaydeden*/
	public void Record()
	{
		if (pointsInTime.Count > Mathf.Round(recordTime / Time.fixedDeltaTime))
		{
			pointsInTime.RemoveAt(pointsInTime.Count - 1);
		}
		pointsInTime.Add(new PointInTime(transform.position, transform.rotation));
	}

	public void StartRewind()
	{
		isRewinding = true;
		rb.isKinematic = true;
		replayCamera.enabled = true;
		mainCamera.enabled = false;
	}

	public void StopReplay()
	{
		isRewinding = false;
		rb.isKinematic = false;
		replayCamera.enabled = false;
		mainCamera.enabled = true;
		
	}
}