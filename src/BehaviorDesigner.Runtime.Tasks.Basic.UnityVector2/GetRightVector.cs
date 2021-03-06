using System;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityVector2
{
	[TaskCategory("Basic/Vector2"), TaskDescription("Stores the right vector value.")]
	public class GetRightVector : BehaviorDesigner.Runtime.Tasks.Action
	{
		[RequiredField, BehaviorDesigner.Runtime.Tasks.Tooltip("The stored result")]
		public SharedVector2 storeResult;

		public override TaskStatus OnUpdate()
		{
			this.storeResult.Value = Vector2.right;
			return TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.storeResult = Vector2.zero;
		}
	}
}
