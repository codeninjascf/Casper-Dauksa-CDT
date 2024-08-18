using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public DoorSwitch[] switches;

    private bool _opened;
    private Animator _animator;

    private AudioSource _audioSource;
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        if (!_opened)
        {
            bool SwitchEnabled = true;
            foreach 
            (DoorSwitch s in switches)
            {
                if (!s.SwitchEnabled)
                {
                    SwitchEnabled = false;
                }
                if (SwitchEnabled)
                {
                    _animator.SetBool("DoorActivate", true);
                    _opened = true;

                    _audioSource.Play();
                }
            }
        }
    }
}