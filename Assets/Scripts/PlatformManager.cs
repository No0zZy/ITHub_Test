using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    private enum Side { Top, Bottom }

    [SerializeField] private GameManager gameManager;
    [SerializeField] private PoolManager poolManager;
    [SerializeField] private GameObject platformGo;
    [SerializeField] private Transform unspawnPoint;

    [Range( 0, 100 )][SerializeField] private float holeChance;
    [SerializeField] private float holeSize;

    [SerializeField] private Platform firstTopPlatform;
    [SerializeField] private Platform firstBottomPlatform;
    [SerializeField] private int platformsOnSideCount;

    //Spawned platforms
    private List<Platform> platformsTop;
    private List<Platform> platformsBottom;

    private void Awake()
    { 
        platformsTop = new List<Platform>();
        platformsBottom = new List<Platform>();
    }


    public void OnPrepare()
    {
        for (int i = 0; i < platformsTop.Count; )
        {
            UnspawnPlatform(platformsTop[0], Side.Top);
            UnspawnPlatform(platformsBottom[0], Side.Bottom);
        }

        platformsTop.Add(firstTopPlatform);
        platformsBottom.Add(firstBottomPlatform);

        for (int i = 0; i < platformsOnSideCount; i++)
        {
            SpawnPlatformNoHole(Side.Top);
            SpawnPlatformNoHole(Side.Bottom);
        }

        platformsTop.RemoveAt(0);
        platformsBottom.RemoveAt(0);
    }

    private void Update()
    {
        if (gameManager.State != GameState.Play)
            return;

        CheckPlatformsPositions();

        foreach (var p in platformsTop)
            p.Move();

        foreach (var p in platformsBottom)
            p.Move();
    }

    private void CheckPlatformsPositions()
    { 
        if (platformsTop[0].transform.position.x < unspawnPoint.position.x)
        {
            UnspawnPlatform(platformsTop[0], Side.Top);

            if (Random.Range(0, 100) < holeChance)
                SpawnPlatformWithHole(Side.Top);
            else
                SpawnPlatformNoHole(Side.Top);
        }

        if (platformsBottom[0].transform.position.x < unspawnPoint.position.x)
        {
            UnspawnPlatform(platformsBottom[0], Side.Bottom);

            if (Random.Range(0, 100) < holeChance)
                SpawnPlatformWithHole(Side.Bottom);
            else
                SpawnPlatformNoHole(Side.Bottom);
        }
    }

    private void UnspawnPlatform(Platform platform, Side side)
    {
        platform.Hole.Off();
        poolManager.Unspawn(platform.gameObject);
        switch (side)
        {
            case Side.Top:
                platformsTop.Remove(platform);
                break;
            case Side.Bottom:
                platformsBottom.Remove(platform); 
                break;
        }
    }

    private void SpawnPlatformNoHole(Side side)
    {
        Platform newPlatform = poolManager.Spawn(platformGo).GetComponent<Platform>();

        switch(side)
        {
            case Side.Top:
                newPlatform.transform.position = platformsTop[platformsTop.Count - 1].EndPoint.position - (newPlatform.BeginPoint.localPosition * newPlatform.transform.localScale.x);
                platformsTop.Add(newPlatform);
                break;
            case Side.Bottom:
                newPlatform.transform.position = platformsBottom[platformsBottom.Count - 1].EndPoint.position - (newPlatform.BeginPoint.localPosition * newPlatform.transform.localScale.x);
                platformsBottom.Add(newPlatform);
                break;
        }
    }

    private void SpawnPlatformWithHole(Side side)
    {
        Platform newPlatform = poolManager.Spawn(platformGo).GetComponent<Platform>();
        newPlatform.Hole.On();

        switch (side)
        {
            case Side.Top:
                newPlatform.transform.position = platformsTop[platformsTop.Count - 1].EndPoint.position - (newPlatform.BeginPoint.localPosition * newPlatform.transform.localScale.x * holeSize);
                platformsTop.Add(newPlatform);
                break;
            case Side.Bottom:
                newPlatform.transform.position = platformsBottom[platformsBottom.Count - 1].EndPoint.position - (newPlatform.BeginPoint.localPosition * newPlatform.transform.localScale.x * holeSize);
                platformsBottom.Add(newPlatform);
                break;
        }
    }
} 