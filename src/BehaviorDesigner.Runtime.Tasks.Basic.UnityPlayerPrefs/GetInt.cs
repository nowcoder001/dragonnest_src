using System;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityPlayerPrefs
{
	[TaskCategory("Basic/PlayerPrefs"), TaskDescription("Stores the value with the specified key from the PlayerPrefs.")]
	public class GetInt : BehaviorDesigner.Runtime.Tasks.Action
	{
		[BehaviorDesigner.Runtime.Tasks.Tooltip("The key to store")]
		public SharedString key;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("The default value")]
		public SharedInt defaultValue;

		[RequiredField, BehaviorDesigner.Runtime.Tasks.Tooltip("The value retrieved from the PlayerPrefs")]
		public SharedInt storeResult;

		public override TaskStatus OnUpdate()
		{
			this.storeResult.Value = PlayerPrefs.GetInt(this.key.Value, this.defaultValue.Value);
			return TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.key = string.Empty;
			this.defaultValue = 0;
			this.storeResult = 0;
		}
	}
}
