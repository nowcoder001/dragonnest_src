using System;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityAnimator
{
	[TaskCategory("Basic/Animator"), TaskDescription("Stores the bool parameter on an animator. Returns Success.")]
	public class GetBoolParameter : BehaviorDesigner.Runtime.Tasks.Action
	{
		[BehaviorDesigner.Runtime.Tasks.Tooltip("The GameObject that the task operates on. If null the task GameObject is used.")]
		public SharedGameObject targetGameObject;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("The name of the parameter")]
		public SharedString paramaterName;

		[RequiredField, BehaviorDesigner.Runtime.Tasks.Tooltip("The value of the bool parameter")]
		public SharedBool storeValue;

		private Animator animator;

		private GameObject prevGameObject;

		public override void OnStart()
		{
			GameObject defaultGameObject = base.GetDefaultGameObject(this.targetGameObject.Value);
			if (defaultGameObject != this.prevGameObject)
			{
				this.animator = defaultGameObject.GetComponent<Animator>();
				this.prevGameObject = defaultGameObject;
			}
		}

		public override TaskStatus OnUpdate()
		{
			if (this.animator == null)
			{
				return TaskStatus.Failure;
			}
			this.storeValue.Value = this.animator.GetBool(this.paramaterName.Value);
			return TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.targetGameObject = null;
			this.paramaterName = string.Empty;
			this.storeValue = false;
		}
	}
}
