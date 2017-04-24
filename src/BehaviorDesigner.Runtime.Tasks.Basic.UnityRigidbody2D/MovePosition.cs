using System;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityRigidbody2D
{
	[TaskCategory("Basic/Rigidbody"), TaskDescription("Moves the Rigidbody to the specified position. Returns Success.")]
	public class MovePosition : BehaviorDesigner.Runtime.Tasks.Action
	{
		[BehaviorDesigner.Runtime.Tasks.Tooltip("The GameObject that the task operates on. If null the task GameObject is used.")]
		public SharedGameObject targetGameObject;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("The new position of the Rigidbody")]
		public SharedVector2 position;

		private Rigidbody2D rigidbody2D;

		private GameObject prevGameObject;

		public override void OnStart()
		{
			GameObject defaultGameObject = base.GetDefaultGameObject(this.targetGameObject.Value);
			if (defaultGameObject != this.prevGameObject)
			{
				this.rigidbody2D = defaultGameObject.GetComponent<Rigidbody2D>();
				this.prevGameObject = defaultGameObject;
			}
		}

		public override TaskStatus OnUpdate()
		{
			if (this.rigidbody2D == null)
			{
				Debug.LogWarning("Rigidbody is null");
				return TaskStatus.Failure;
			}
			this.rigidbody2D.MovePosition(this.position.Value);
			return TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.targetGameObject = null;
			this.position = Vector2.zero;
		}
	}
}
