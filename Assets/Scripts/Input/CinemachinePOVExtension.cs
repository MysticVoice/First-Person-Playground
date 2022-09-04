using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

namespace MysticVoice
{
    public class CinemachinePOVExtension : CinemachineExtension
    {


        private Vector3 startingRotation;
        protected override void Awake()
        {
            base.Awake();
        }

        protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
        {
            if (vcam.Follow)
            {
                if (stage == CinemachineCore.Stage.Aim)
                {
                    if (startingRotation == null) startingRotation = transform.localRotation.eulerAngles;

                    state.RawOrientation = Quaternion.Euler(-startingRotation.y, 0, 0);
                }
            }
        }
    }
}
