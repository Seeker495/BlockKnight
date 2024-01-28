using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;

public class PlayerAttacker : MonoBehaviour
{
    GameController mController;
    bool mIsAttack;
    public bool IsAttack() { return mIsAttack; }

    private float mChargeTime;
    public bool IsCharged() { return mChargeTime >= 3.0f; }
    // Start is called before the first frame update
    void Start()
    {
        mController = new GameController();
        mController.Player.Attack.started += Attack;
        mController.Player.Attack.started += ChargeAttack;
        mController.Player.Attack.performed += ChargeAttack;
        mController.Enable();
        mIsAttack = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Attack(InputAction.CallbackContext context)
    {
        mIsAttack = true;
        StartCoroutine(Attacking());
    }

    IEnumerator Attacking()
    {
        yield return new WaitForFixedUpdate();
        mIsAttack = false;
        yield return new WaitForSeconds(1);
    }

    void ChargeAttack(InputAction.CallbackContext context)
    {
        mChargeTime = Mathf.Clamp(mChargeTime += Time.deltaTime, 0f, 3f);
    }

}
