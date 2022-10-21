using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AiAgent))]
public class StateMachine : MonoBehaviour
{
    //comma separated list of 
    public enum State
    {
        Patrol,
        Chase,
        Search,
        BerryPicking,
    }
    //The AI's current state
    [SerializeField] public State _state;
    private AiAgent _aiAgent;
    private void Start()
    {
        //Grab the first aiAgent it finds (or whatever is in the <>)
        //and stores it in the variable
        _aiAgent = GetComponent<AiAgent>();

        NextState();
    }

    private void NextState()
    {
        switch (_state)
        {
            case State.Patrol:
                StartCoroutine(PatrolState());
                break;
            case State.Chase:
                StartCoroutine(ChaseState());
                break;
            case State.BerryPicking:
                StartCoroutine(BerryPickingState());
                break;
            default:
                Debug.LogWarning("State does not exsit in NextState function, stopping statemachine");
                break;
        }

    }

    private IEnumerator PatrolState()
    {
        Debug.Log("Patrol: Enter");
        _aiAgent.search();
        while (_state == State.Patrol)
        {
            _aiAgent.Patrol();
            if (_aiAgent.IsPlayerInRange())
            {
                _state = State.Chase;
            }
            //our code
            yield return null; //wait a single frame

        }
        Debug.Log("Patrol: Exit");
        NextState();

    }
    private IEnumerator ChaseState()
    {
        Debug.Log("Chase: Enter");
        while (_state == State.Chase)
        {
            _aiAgent.ChasePlayer();
            if (!_aiAgent.IsPlayerInRange())
            {
                _state = State.Patrol;
            }
            yield return null; //wait a single frame
        }
        Debug.Log("Chase: Exit");
        NextState();
    }

    private IEnumerator BerryPickingState()
    {
        Debug.Log("BerryPicking: Enter");
        while (_state == State.BerryPicking)
        {
            yield return null; // wait a single frame 
        }
        Debug.Log("BerryPicking: Exit");
        NextState();
    }


}
