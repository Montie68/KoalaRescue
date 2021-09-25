using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.InfiniteRunnerEngine;

public class EncroachingFireController : MonoBehaviour
{
    public enum FirePosition
    {
        Far = 3,
        Medium = 2,
        Close = 1
    }
    private int minFirePositionValue = 1;
    private int maxFirePositionValue = 3;

    // fire position based on starting position (player location)
    public GameObject startingPosition;
    // the game manager to get lives
    public GameObject gameManager;
    // the amount of lives when last chacked.
    private int _lives;

    // the x modifiers of the fire location
    private float closeLocationMod = 6.6f;
    private float mediumLocationMod = 9.0f;
    private float farLocationMod = 11.9f;

    // ideal current location of fire, starts off as far
    public FirePosition firePosition = FirePosition.Far;


    private Vector3 _currentLocation;
    private Vector3 _desiredLocation;
    private float speed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        UpdateLocations();
        _lives = gameManager.GetComponent<GameManager>().CurrentLives;
        CheckLives();
    }

    // Update is called once per frame
    void Update()
    {
        if (_currentLocation != _desiredLocation)
        {
            this.transform.position = Vector3.MoveTowards(_currentLocation, _desiredLocation, speed * Time.deltaTime);
        }
        else 
        {
            CheckLives();
            //ChangeFireDistance(Mathf.RoundToInt(Random.Range(-5, 5)));
        }

        UpdateLocations();
    }

    void CheckLives()
    {
        int _currentLives = gameManager.GetComponent<GameManager>().CurrentLives;
        int _totalLives = gameManager.GetComponent<GameManager>().TotalLives;

        if (_currentLives == _totalLives)
        {
            firePosition = FirePosition.Far;
            _lives = _currentLives;
            return;
        }

        if (_currentLives < _lives)
        {
            firePosition = FirePosition.Close;
            _lives = _currentLives;
            return;
        }

        if (_currentLives > _lives)
        {
            firePosition = FirePosition.Far;
            _lives = _currentLives;
            return;
        }

        if (_currentLives == _lives)
        {
            firePosition = FirePosition.Medium;
            _lives = _currentLives;
            return;
        }
    }

    /// <summary>
    /// When triggered will make changes to the that affect teh desired position of the fire.
    /// </summary>
    /// <param name="change">Negative values makes fire go closer to the player.
    ///  Positive values makes the fire go further away from the player.</param>
    void ChangeFireDistance(int change)
    {
        FirePosition newFirePosition = firePosition;
        if (change < 0)
        {
            int refNumber = Mathf.Clamp((int)firePosition - 1, minFirePositionValue, maxFirePositionValue);
            newFirePosition = (FirePosition)refNumber;
        }
        if (change > 0)
        {
            int refNumber = Mathf.Clamp((int)firePosition + 1, minFirePositionValue, maxFirePositionValue);
            newFirePosition = (FirePosition)refNumber;
        }

        firePosition = newFirePosition;
    }

    /// <summary>
    /// Updates the current location with the location of the fire and the desired location
    ///  based on the set fire position.
    /// </summary>
    void UpdateLocations()
    {
        _currentLocation = this.transform.localPosition;
        _desiredLocation = CalcDesiredLocation(firePosition);
    }

    Vector3 CalcDesiredLocation(FirePosition position)
    {
        // get position of starting location
        Vector3 startPositionLocation = startingPosition.transform.localPosition;

        // make sure y value is same as current location
        Vector3 desiredLocation = startPositionLocation;
        desiredLocation.y = _currentLocation.y;

        // work out the desired x value
        switch (position)
        {
            case FirePosition.Far:
                desiredLocation.x -= farLocationMod;
                break;
            case FirePosition.Medium:
                desiredLocation.x -= mediumLocationMod;
                break;
            case FirePosition.Close:
                desiredLocation.x -= closeLocationMod;
                break;
        }

        return desiredLocation;
    }
}
