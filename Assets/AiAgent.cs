using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiAgent : MonoBehaviour
{
    //private Unity and no other classes can access player 
    //public unity and all other classes can access player 
    //[serializefield] unity has speical access to this variable 
    [SerializeField] private GameObject _player;
    [SerializeField] private float _speed;

    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private int _waypointIndex = 0;
    //array
    //store many values as a single variable 
    //pros: fast
    //cons: cannot be resized 

    public bool IsPlayerInRange()
    {
        if(Vector2.Distance(transform.position, _player.transform.position) < 5f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void search()
    {
        int closestIndex = -1;
        float closestDistance = float.MaxValue;

        for (int index = 0; index <_waypoints.Length; index++)
        {
            float currentDistance = Vector2.Distance(_waypoints[index].position, transform.position);
            if (currentDistance < closestDistance)
            {
                closestDistance = currentDistance;
                closestIndex = index;
            }
        }
        _waypointIndex = closestIndex;
    }
    public void ChasePlayer()
    {
        MoveToPoint(_player.transform.position);
    }
    public void Patrol()
    {
        Vector2 waypointPosition = _waypoints[_waypointIndex].position;
        MoveToPoint(waypointPosition);
        if(Vector2.Distance(transform.position, waypointPosition) < 0.1f)
        {
            _waypointIndex++;
        }
        if(_waypointIndex >= _waypoints.Length)
        {
            _waypointIndex = 0;
        }

    }
    void MoveToPoint(Vector2 point)
    {
        Vector2 directionToPlayer = point - (Vector2)transform.position;
        if(directionToPlayer.magnitude > 0.1f)
        {
            directionToPlayer.Normalize();
            directionToPlayer *= _speed * Time.deltaTime;
            transform.position += (Vector3)directionToPlayer;
        }
    }
}
