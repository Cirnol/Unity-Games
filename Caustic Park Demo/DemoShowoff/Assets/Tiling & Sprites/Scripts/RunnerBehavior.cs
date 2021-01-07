using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerBehavior : MonoBehaviour
{
    public GameObject enemyTemplate;

    private EnemyStateController stateController;

    private ScriptableObject currentState;

    // Start is called before the first frame update
    void Start()
    {
        stateController = enemyTemplate.GetComponent<EnemyStateController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Freeze Rotation
        Vector3 parentRote = gameObject.GetComponentInParent<Transform>().localRotation.eulerAngles;
        transform.rotation = Quaternion.identity;

        // Animations
        currentState = stateController.CurrentState;

        if (currentState.name == "Wait_Runner")
            gameObject.GetComponent<Animator>().Play("Sleep");

        if(currentState.name == "WakeUp_Runner")
            gameObject.GetComponent<Animator>().Play("Awaken");

        if(currentState.name == "Chase_Runner")
            gameObject.GetComponent<Animator>().Play("Running");

        if(currentState.name == "Flee_Runner")
            gameObject.GetComponent<Animator>().Play("Hide");
    }
}
