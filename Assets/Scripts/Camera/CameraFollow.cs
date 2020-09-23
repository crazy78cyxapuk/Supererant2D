using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CameraFollow : MonoBehaviour
{
    public float damping = 1.5f;
    public Vector2 offset = new Vector2(2f, 1f);
    public bool faceLeft;
    [SerializeField] private Transform player;
    private int lastX;

    [SerializeField] public float minPositionY = 2.5f;

    [HideInInspector] public bool stopPosition = false;

    private float positionCameraX;

    private static CameraFollow instance;
    public static CameraFollow Instance => instance;

    public Transform GetLowestBall
    {
        get
        {
            var lowest = (from t in WaterSpawner.Instance.objs orderby t.transform.position.y select t).ToList()[0];

            return lowest.transform;
        }
        set { }
    }

    private void Awake()
    {
        InitSingleton();
    }

    private void InitSingleton()
    {
        if (instance != null && instance != this) Destroy(gameObject);
        else instance = this;
    }

    void Start()
    {
        positionCameraX = transform.position.x;

        player = GetLowestBall;

        offset = new Vector2(Mathf.Abs(offset.x), offset.y);
    }

    void Update()
    {
        if (PlayerPrefs.GetString("camera") == "auto")
        {
            if (transform.position.y > minPositionY && stopPosition == false)
            {
                if (player)
                {
                    int currentX = Mathf.RoundToInt(player.position.x);
                    if (currentX > lastX) faceLeft = false; else if (currentX < lastX) faceLeft = true;
                    lastX = Mathf.RoundToInt(player.position.x);

                    Vector3 target;
                    if (faceLeft)
                    {
                        //target = new Vector3(player.position.x - offset.x, player.position.y + offset.y, transform.position.z);
                        target = new Vector3(positionCameraX, player.position.y + offset.y, transform.position.z);
                    }
                    else
                    {
                        //target = new Vector3(player.position.x + offset.x, player.position.y + offset.y, transform.position.z);
                        target = new Vector3(positionCameraX, player.position.y + offset.y, transform.position.z);
                    }
                    Vector3 currentPosition = Vector3.Lerp(transform.position, target, damping * Time.deltaTime);
                    transform.position = currentPosition;

                    player = GetLowestBall;
                }
            }
        }
    }

    public void FindPlayer(bool playerFaceLeft)
    {
        //player = GameObject.FindGameObjectWithTag("Player").transform;
        lastX = Mathf.RoundToInt(player.position.x);
        if (playerFaceLeft)
        {
            //transform.position = new Vector3(player.position.x - offset.x, player.position.y + offset.y, transform.position.z);
            transform.position = new Vector3(positionCameraX, player.position.y + offset.y, transform.position.z);
        }
        else
        {
            //transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, transform.position.z);
            transform.position = new Vector3(positionCameraX, player.position.y + offset.y, transform.position.z);
        }
    }
}
