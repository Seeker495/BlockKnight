using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.InputSystem.XR;

/* AnimationPreview�V�[���p�̃X�N���v�g
 * 
 * 
 */
public class Animations : MonoBehaviour
{
    [Serializable]
    public struct AnimationTrack
    {
        public string animationName;
        public AnimationClip animation;
    }

    [SerializeField] List<AnimationTrack> ANIMATION_TRACKS;
    private const string STATE_NAME = "NewState";
    public AnimationClip GetAnimation(string animationName) { return ANIMATION_TRACKS.Find(truck => truck.animationName == animationName).animation; }
    private const int MAX_ANIMATION = 10;
    public List<string> GetAllAnimationName()
    {
        List<string> animationNames = new List<string>();
        ANIMATION_TRACKS.ForEach(track => animationNames.Add(track.animationName));

        return animationNames;
    }
    public void Play(string animationName) 
    {
        TryGetComponent(out Animator anim);
        AnimatorController controller = anim.runtimeAnimatorController as AnimatorController; // NewState�̂݊i�[����Ă���
        controller.layers[0].stateMachine.states[0].state.motion = GetAnimation(animationName); // Clip�����ւ�
        anim.Play(STATE_NAME);

    }
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
