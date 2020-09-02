using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrajectoryRenderer : MonoBehaviour
{
    //public GameObject water;

    //private LineRenderer lineRenderer;

    //private void Start()
    //{
    //    lineRenderer = GetComponent<LineRenderer>();
    //}

    //public void ShowTrajectory(Vector2 origin, Vector2 speed)
    //{
    //    GameObject obj = Instantiate(water, origin, Quaternion.identity);
    //    obj.GetComponent<Rigidbody2D>().AddForce(speed, ForceMode2D.Impulse);

    //    Physics2D.autoSimulation = false;

    //    Vector3[] points = new Vector3[100];

    //    for (int i = 0; i < points.Length; i++)
    //    {
    //        float time = i * 0.1f;
    //        Physics2D.Simulate(0.1f);

    //        points[i] = obj.transform.position;

    //        //points[i] = origin + speed * time + Physics2D.gravity * time * time / 2f;
    //    }

    //    lineRenderer.SetPositions(points);

    //    Physics2D.autoSimulation = false;
    //    Destroy(obj);
    //}

    //public void ClearRenderer()
    //{
    //    lineRenderer.positionCount = 0;
    //}
















	[SerializeField] int dotsNumber;
	[SerializeField] GameObject dotsParent;
	[SerializeField] GameObject dotPrefab;
	[SerializeField] float dotSpacing;
	[SerializeField] [Range(0.01f, 0.3f)] float dotMinScale;
	[SerializeField] [Range(0.3f, 1f)] float dotMaxScale;

	Transform[] dotsList;

	Vector2 pos;
	//dot pos
	float timeStamp;

	//--------------------------------
	void Start()
	{
		//hide trajectory in the start
		Hide();
		//prepare dots
		PrepareDots();
	}

	void PrepareDots()
	{
		dotsList = new Transform[dotsNumber];
		dotPrefab.transform.localScale = Vector3.one * dotMaxScale;

		float scale = dotMaxScale;
		float scaleFactor = scale / dotsNumber;

		for (int i = 0; i < dotsNumber; i++)
		{
			dotsList[i] = Instantiate(dotPrefab, null).transform;
			dotsList[i].parent = dotsParent.transform;

			dotsList[i].localScale = Vector3.one * scale;
			if (scale > dotMinScale)
				scale -= scaleFactor;
		}
	}

	public void UpdateDots(Vector3 ballPos, Vector2 forceApplied)
	{
		timeStamp = dotSpacing;
		for (int i = 0; i < dotsNumber; i++)
		{
			pos.x = (ballPos.x + forceApplied.x * timeStamp);
			pos.y = (ballPos.y + forceApplied.y * timeStamp) - (Physics2D.gravity.magnitude * timeStamp * timeStamp) / 2f;

			//you can simlify this 2 lines at the top by:
			//pos = (ballPos+force*time)-((-Physics2D.gravity*time*time)/2f);
			//
			//but make sure to turn "pos" in Ball.cs to Vector2 instead of Vector3	

			dotsList[i].position = pos;
			timeStamp += dotSpacing;
		}
	}

	public void Show()
	{
		dotsParent.SetActive(true);
	}

	public void Hide()
	{
		dotsParent.SetActive(false);
	}
}
