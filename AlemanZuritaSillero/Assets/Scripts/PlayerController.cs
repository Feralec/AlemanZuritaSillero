using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterStates currentState;

    // Start is called before the first frame update
    void Start()
    {
        ChangeState(new GroundedState(this));
    }

    // Update is called once per frame
    void Update()
    {
        currentState.Execute();
    }
    public void ChangeState(CharacterStates newState)
    {
        if (newState != null)
        {
            if (currentState != null)
                currentState.OnFinish();
            currentState = newState;
            currentState.OnFinish();
        }
    }
}
