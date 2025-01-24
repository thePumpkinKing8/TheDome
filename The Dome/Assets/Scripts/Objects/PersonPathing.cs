using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class PersonPathing : MonoBehaviour
{
    [SerializeField] private PathState _pathState;
    public PathState PathingState 
    { get { return _pathState; } 
      set
      {
            if(_pathState != value)
            {
                _pathState = value;

                switch(_pathState)
                {
                    case PathState.Patrol:
                        ChangeState(Patrol());
                        break;
                    case PathState.Hang:
                        //ChangeState(Hang());
                        break;
                    case PathState.Wander:
                        ChangeState(Wander());
                        break;
                    case PathState.Follow:
                        //ChangeState(Follow());
                        break;
                    case PathState.Waiting:
                        //ChangeState(Waiting());
                        break;
                }
            }
      }
    }

    private Coroutine _currentState;

    #region A*Scripts
    private AIPath _path;
    private AIDestinationSetter _destinationSetter;
    private Seeker _seeker;
    #endregion

    #region WanderingSettings
    [Header("WanderSettings")]
    [SerializeField] private float _wanderingRange = 5f;

    #endregion

    #region Behavior
    [Header("BehaviorSettings")]
    [SerializeField] private float _downTime;
    [SerializeField] private float _distanceFromTarget;
    #endregion

    private void Awake()
    {
        _path = GetComponent<AIPath>();
        _destinationSetter = GetComponent<AIDestinationSetter>();
        _seeker = GetComponent<Seeker>();
    }
    private void Start()
    {
        ChangeState(Wander());
    }


    IEnumerator Waiting()
    {
        _destinationSetter.target = null;
        while (true)
        {
            yield return new WaitForFixedUpdate();
        }
    }
    IEnumerator Patrol()
    {
        GameObject pointOne;
        GameObject pointTwo;
        //find locations to patrol between

        while(true)
        {
            yield return new WaitForFixedUpdate();
        }
    }

    IEnumerator Wander()
    {
        while(true)
        {
            yield return new WaitForFixedUpdate();
            //get random point
            Vector2 randomPoint = Random.insideUnitCircle * _wanderingRange;
            Vector2 point =  randomPoint + (new Vector2(transform.position.x,transform.position.y));
            Debug.Log(point);
            _destinationSetter.target = null;
            _destinationSetter.targetPos = point;
            yield return new WaitForFixedUpdate();
            yield return new WaitUntil(() => _path.reachedEndOfPath == true);
            yield return new WaitForSeconds(_downTime);
        }
    }

    private void ChangeState(IEnumerator newState)
    {
        if(_currentState != null)
        {
            StopCoroutine(_currentState);
        }
        _currentState = StartCoroutine(newState);
    }
}

public enum PathState
{
    Patrol,
    Hang,
    Wander,
    Follow,
    Waiting
}


