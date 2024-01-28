using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{
    [Serializable]
    public struct AnimationTruck
    {
        public string animationName;
        public AnimationClip animation;
    }

    [SerializeField] List<AnimationTruck> ANIMATION_TRUCKS = new List<AnimationTruck>(); 

    public AnimationClip GetAnimation(string animationName) { return ANIMATION_TRUCKS.Find(truck => truck.animationName == animationName).animation; }
    public void Play(string animationName) 
    {
        TryGetComponent(out Animation anim);
        anim.AddClip(GetAnimation(animationName), animationName);
        anim.clip = anim.GetClip(animationName);
        Debug.Log(anim.clip);
        anim.Play();
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
