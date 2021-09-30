using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.InfiniteRunnerEngine;

// Made by Sarah V. Controls the fire's position so that it follows the player.
public class EncroachingFireController : MonoBehaviour
{
    /// <summary> Enum to indicate where the fire is in relation to the fire. </summary>
    public enum FirePosition
    {
        Far = 3,
        Medium = 2,
        Close = 1
    }
    /// <summary> The value associated with the enum that is closest to the player </summary>
    private const int minFirePositionValue = 1;
    /// <summary> The value associated with the enum that is furthest from the player </summary>
    private const int maxFirePositionValue = 3;

    /// <summary> Reference to the Starting Position object which is associated with the player location. </summary>
    public GameObject startingPosition;
    /// <summary> Reference to the Game Manager object that controls the player's lives. </summary>
    public GameObject gameManager;
    
    /// <summary> The amount of lives the player had when last checked. </summary>
    private int _lives;

    /// <summary> The amount to take off the x value of the Starting Position to determine the desired location of the fire when it is close to the player. </summary>
    private const float closeLocationMod = 6.6f;
    /// <summary> The amount to take off the x value of the Starting Position to determine the desired location of the fire when it is a medium distance from the player. </summary>
    private const float mediumLocationMod = 9.0f;
    /// <summary> The amount to take off the x value of the Starting Position to determine the desired location of the fire when it is far from the player. </summary>
    private const float farLocationMod = 11.9f;

    /// <summary> The initial desired starting position of the fire. </summary>
    private FirePosition firePosition = FirePosition.Far;

    /// <summary> The current location of the fire. </summary>
    private Vector3 _currentLocation;
    /// <summary> The desired location of the fire. </summary>
    private Vector3 _desiredLocation;

    /// <summary> The maximum speed of the fire when going towards the player. </summary>
    public const float closerSpeed = 1.2f;
    /// <summary> The maximum speed of the fire when going away from the player. </summary>
    public const float fartherSpeed = 0.8f;

    /// <summary> The amount of seconds the fire should remain close to the player. </summary>
    public int closeSeconds = 5;
    /// <summary> The amount of seconds the fire should remain at the medium position. </summary>
    public int mediumSeconds = 10;
    /// <summary> The amount of ticks the fire has been at the current position </summary>
    private float timeRemaining = 0;
    

    
    void Start()
    {
        // Save the intial value of lives based on the players current lives
        _lives = gameManager.GetComponent<GameManager>().CurrentLives;
        // Work out the best fire location based on player lives.
        CheckLives(false);
        // Work out the initial desired location.
        UpdateLocations();
    }


    void Update()
    {
        // check if the fire needs to move.
        if (_currentLocation != _desiredLocation)
        {
            // check if fire is moving towards the player.
            if (_currentLocation.x < _desiredLocation.x)
            {
                // fire is moving closer to player so move at Closer Speed
                this.transform.position = Vector3.MoveTowards(_currentLocation, _desiredLocation, closerSpeed * Time.deltaTime);
            }
            else
            {
                // fire is moving away from player so move at Farther Speed
                this.transform.position = Vector3.MoveTowards(_currentLocation, _desiredLocation, fartherSpeed * Time.deltaTime);
            }
            CheckLives(false);
        }
        else 
        {
            // fire does not need to move so check for new location based on player lives
            CheckLives(true);
        }

        // update the current and desired location
        UpdateLocations();
    }


    /// <summary>
    /// Works out the best position of the fire. 
    /// If the player is at full lives, then the fire is as far from the player as possible.
    /// If the player has lost lives, the fire gets as close to the player as posible.
    /// If the player regains lives, the fire moves far away from the player.
    /// If the player's lives have not changed since the last check, the  fire will gradually recede.
    /// </summary>
    /// <param name="creepBack">If creep back is enabled, flame will recede back. If disable, will only update when lives change.</param>
    void CheckLives(bool creepBack)
    {
        // refernce to the player's current lives
        int _currentLives = gameManager.GetComponent<GameManager>().CurrentLives;
        // reference to the player's maxiumim lives
        int _totalLives = gameManager.GetComponent<GameManager>().TotalLives;

        // see if current lives matches total lives.
        if (_currentLives == _totalLives)
        {
            // fire should be far away from the player
            firePosition = FirePosition.Far;
            // update lives to match curretn lives
            _lives = _currentLives;
            // exit funciton
            return;
        }

        // see if the player has lost lives since last checked.
        if (_currentLives < _lives)
        {
            // fire should get really close to the player.
            firePosition = FirePosition.Close;
            // update lives to match curretn lives
            _lives = _currentLives;
            // update the time remaining to the close time
            timeRemaining = closeSeconds;
            // exit funciton
            return;
        }

        // see if the player has gained lives.
        if (_currentLives > _lives)
        {
            // fire should be far away from the player
            firePosition = FirePosition.Far;
            // update lives to match curretn lives
            _lives = _currentLives;
            // exit funciton
            return;
        }

        // player has not gained or lost lives.
        if (_currentLives == _lives && creepBack)
        {
            // increment current ticks.
            timeRemaining -= Time.deltaTime;
            //Debug.Log("Current Ticks is " + currentTicks);
            switch (firePosition)
            {
                case FirePosition.Far:
                    // fire remains far away
                    break;
                case FirePosition.Medium:
                    // check if current ticks equals or exceeds medium ticks value
                    if (timeRemaining <= 0)
                    {
                        // fire should retract to far away
                        firePosition = FirePosition.Far;
                    }
                    break;
                case FirePosition.Close:
                    // check if current ticks equals or exceeds close ticks value
                    if (timeRemaining <= 0)
                    {
                        // fire should retract to medium distance
                        firePosition = FirePosition.Medium;
                        // update the time remaining to the medium time
                        timeRemaining = mediumSeconds;
                    }
                    break;
            }
        }
    }

    /*/// <summary>
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
    }*/

    /// <summary> Updates the current location with the location of the fire and the desired location based on the set fire position. </summary>
    void UpdateLocations()
    {
        // set the current location from the position of the fire
        _currentLocation = this.transform.localPosition;
        // set the desired location with teh Calc Desired Location based on the set fire position
        _desiredLocation = CalcDesiredLocation(firePosition);
    }

    /// <summary> Calculates the desired position of the fire based on the 'position' parameter and the Starting Position location. </summary>
    /// <param name="position">The enum value of the desired fire position.</param>
    /// <returns>The desired location as a vector.</returns>
    Vector3 CalcDesiredLocation(FirePosition position)
    {
        // get position of starting location
        Vector3 startPositionLocation = startingPosition.transform.localPosition;

        // initialize the desired location from the Start Position location
        Vector3 desiredLocation = startPositionLocation;
        // make sure y value is same as current location
        desiredLocation.y = _currentLocation.y;

        // work out the desired x value by subtracting the relevane Location Mod from the above desired locaiton
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

        // return the calculated desired location
        return desiredLocation;
    }
}
