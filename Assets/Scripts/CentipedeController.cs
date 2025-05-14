using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using DG.Tweening;
using CurvedPathGenerator;
using System;

public interface IDamageable
{
    void TakeDamage(int amount);
}

public class CentipedeController : MonoBehaviour
{
    //PUBLIC FIELDS
    public CentipedeSegment segmentPrefab;
    public CentipedeHead headPrefab;
    public int initialLength = 10;
    public float moveInterval = 0.5f;
    public float stepSize = 1f;


    //PRIVATE FIELDS
    private List<CentipedeSegment> segments = new();
    private Vector3 direction = Vector3.right;
    private float timer;
    private CentipedeHead _head;


    //PROPERTIES
    [SerializeField] private PathGenerator pathGenerator;
    [SerializeField] private float spawnInterval = 0.6f;


    //STATIC FIELDS
    public static CentipedeController instance;
    public static Action<CentipedeSegment> OnSegmentDie;



    //METHODS

    private void Awake()
    {
        instance = this;
        OnSegmentDie = null;
    }
    void Start()
    {
        StartCoroutine(SpawnCentipede());


        GameEvents.OnUpgrade += () => SetMotion(true);
        GameEvents.DoShowUpgradeUI += () => SetMotion(false);
    }


    private IEnumerator SpawnCentipede()
    {
        ////Spawn Head////////
        Vector3 spawnPos = pathGenerator.PathList[0] + Vector3.forward * segments.Count;
        var seg = Instantiate(headPrefab, spawnPos, Quaternion.identity, transform);
        seg.Init(this, pathGenerator);
        _head = seg;

        ////Spawn Body///////
        for (int i = 0; i < initialLength; i++)
        {
            yield return new WaitForSeconds(spawnInterval);
            SpawnSegment();
        }

    }

    public Transform GetSegmentInFront(CentipedeSegment segment)
    {
        for (int i = 0; i < segments.Count; i++)
        {
            if (segment == segments[i])
            {
                if (i != 0)
                    return segments[i - 1].transform;
                else
                    return _head.transform;
            }
        }
        return null;
    }

    void Update()
    {
    }

    void SpawnSegment()
    {
        Vector3 spawnPos = pathGenerator.PathList[0] + Vector3.forward * segments.Count;
        var seg = Instantiate(segmentPrefab, spawnPos, Quaternion.identity, transform);

        if (segments.Count == 0)
            seg.Init(this, _head.transform);
        else
            seg.Init(this, segments[^1].transform);
        segments.Add(seg);
    }

    public void KillSegment(CentipedeSegment seg)
    {
        int idx = segments.IndexOf(seg);
        if (segments.Contains(seg))
            segments.Remove(seg);

        Vector3 tempPos = seg.transform.position;
        GameEvents.OnDestroyBodyPart?.Invoke();
        SetMotion(false);
        StartCoroutine(UpdateSegmentsPosition(tempPos, idx));
        Destroy(seg.gameObject);

        if (segments.Count <= 0)
            GameEvents.OnEnemyDie?.Invoke();
    }

    void SetMotion(bool set)
    {
        _head.GetComponent<PathFollower>().IsMove = set;
        segments.ForEach((s) => s.SetMove(set));
    }


    private IEnumerator UpdateSegmentsPosition(Vector3 pos, int idx)
    {
        yield return new WaitForSeconds(1);
        for (int i = idx - 1; i >= 0; i--)
        {
            Vector3 tempPos = segments[i].transform.position;
            segments[i].transform.position = pos;
            pos = tempPos;

            if (i == 0)
                _head.transform.position = tempPos;
        }
        SetMotion(true);
    }


}
