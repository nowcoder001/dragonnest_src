using System;

namespace BehaviorDesigner.Runtime.Tasks.Basic.SharedVariables
{
	[TaskCategory("Basic/SharedVariable"), TaskDescription("Returns success if the variable value is equal to the compareTo value.")]
	public class CompareSharedTransform : Conditional
	{
		[Tooltip("The first variable to compare")]
		public SharedTransform variable;

		[Tooltip("The variable to compare to")]
		public SharedTransform compareTo;

		public override TaskStatus OnUpdate()
		{
			if (this.variable.Value == null && this.compareTo.Value != null)
			{
				return TaskStatus.Failure;
			}
			if (this.variable.Value == null && this.compareTo.Value == null)
			{
				return TaskStatus.Success;
			}
			return (!this.variable.Value.Equals(this.compareTo.Value)) ? TaskStatus.Failure : TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.variable = null;
			this.compareTo = null;
		}
	}
}
