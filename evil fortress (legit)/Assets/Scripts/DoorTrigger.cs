using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public DoorSwitch[] switches;

    private bool _opened;
    private Animator _animator;

    private AudioSource _audioSource;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_opened)
        {
            bool SwitchesEnabled = true;
            foreach (DoorSwitch s in switches)
            {
                if (!s.SwitchEnabled)
                {
                    SwitchesEnabled = false;
                }
            }
            if (SwitchesEnabled)
            {
                _animator.SetBool("DoorActivate", true);
                _opened = true;

                _audioSource.Play();
            }
        }
    }
}
