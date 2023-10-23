using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BirdAgent : Agent
{
    public LogicScript logic;
    public BirdScrip bird;
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("logic").GetComponent<LogicScript>();
        bird = GameObject.FindGameObjectWithTag("bird").GetComponent<BirdScrip>();
    }

    public override void OnEpisodeBegin()
    {
        Debug.Log("Begin");
        if (!logic.isAlive)
        {
            logic.restartGame();
            Start();
        }
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        Debug.Log("Observations");

        sensor.AddObservation(bird.body.velocity.x);
        sensor.AddObservation(bird.body.velocity.y);

        var nextPipe = logic.nextPipe();

        // print in console
        Debug.Log(nextPipe.transform.position.x);
        Debug.Log(nextPipe.transform.position.y);

        sensor.AddObservation(nextPipe.transform.position.x);
        sensor.AddObservation(nextPipe.transform.position.y);
    }

    public override void OnActionReceived(ActionBuffers actionBuffers)
    {
        Debug.Log("Actions");

        // Action
        bool shouldJump = actionBuffers.ContinuousActions[0] > .5f;

        // Rewards
        if (shouldJump)
        {
            bird.jump();
        }

        // Fell off platform
        else if (!logic.isAlive)
        {
            EndEpisode();
        }
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        var continuousActionsOut = actionsOut.ContinuousActions;
        continuousActionsOut[0] = .75f;
    }
}