using UnityEngine;
using System.Collections;
using MoreMountains.Tools;

namespace MoreMountains.CorgiEngine
{
    /// <summary>
    /// Add this component to a character and it'll be able to block
    /// Animator parameters : BLocking (bool)
    /// </summary>
    [AddComponentMenu("Corgi Engine/Character/Abilities/Character Block")]
    public class CharacterBlock : CharacterAbility
    {
        /// This method is only used to display a helpbox text at the beginning of the ability's inspector
        public override string HelpBoxText() { return "Add this component to a character and it'll be able to block attack of enemies" ;}

        [Header("Block")]

        protected Health health;

        // animation parameters
        protected const string _blockingAnimationParameterName = "Blocking";
        protected int _blockingAnimationParameter;
        protected override void Initialization()
        {
            base.Initialization();
            health = gameObject.GetComponent<Health>();
        }
        protected override void HandleInput()
        {
            if (_inputManager.BlockButton.State.CurrentState == MMInput.ButtonStates.ButtonDown || _inputManager.BlockButton.State.CurrentState == MMInput.ButtonStates.ButtonPressed)
            {
                health.DamageDisabled();
                _movement.ChangeState(CharacterStates.MovementStates.Blocking);
            }

            if (_inputManager.BlockButton.State.CurrentState == MMInput.ButtonStates.ButtonUp)
            { 
                health.DamageEnabled();
                _movement.ChangeState(CharacterStates.MovementStates.Idle);
            }
        }
        protected override void InitializeAnimatorParameters()
        {
            RegisterAnimatorParameter(_blockingAnimationParameterName, AnimatorControllerParameterType.Bool, out _blockingAnimationParameter);
        }

        public override void UpdateAnimator()
        {


            MMAnimatorExtensions.UpdateAnimatorBool(_animator, _blockingAnimationParameter, (_movement.CurrentState == CharacterStates.MovementStates.Blocking), _character._animatorParameters, _character.PerformAnimatorSanityChecks);
           
        }
    }
}


