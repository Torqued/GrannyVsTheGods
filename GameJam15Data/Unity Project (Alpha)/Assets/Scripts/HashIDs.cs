using UnityEngine;
using System.Collections;

public class HashIDs : MonoBehaviour {

	public int idleState;
	public int movingState;
	public int jumpingState;
	public int landingState;
	public int punchingState;
	public int punching2State;
	public int shoeState;
	public int attackingState;
	public int deadTrigger;
	public int deadBool;

	public int movingBool;
	public int onGroundBool;
	public int jumpTrigger;
	public int punchTrigger;
	public int attackBool;
	public int hurtTrigger;
	
	void Awake () {
		idleState = Animator.StringToHash("Base Layer.Idle");
		movingState = Animator.StringToHash("Base Layer.Moving");
		jumpingState = Animator.StringToHash("Base Layer.Jumping");
		landingState = Animator.StringToHash("Base Layer.Landing");
		punchingState = Animator.StringToHash("Base Layer.Punching");
		punching2State = Animator.StringToHash("Base Layer.Punching2");
		shoeState = Animator.StringToHash("Base Layer.Shoe");
		attackingState = Animator.StringToHash("Base Layer.Attack");

		onGroundBool = Animator.StringToHash("OnGround");
		movingBool = Animator.StringToHash("Moving");
		jumpTrigger = Animator.StringToHash("JumpTrigger");
		punchTrigger = Animator.StringToHash("PunchTrigger");
		attackBool = Animator.StringToHash("Attacking");
		hurtTrigger = Animator.StringToHash("Hurt");
		deadTrigger = Animator.StringToHash("Dead Trigger");
		deadBool = Animator.StringToHash("Dead");
	
	}
}
