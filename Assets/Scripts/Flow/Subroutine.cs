// (C) 2009-2015 Christian.Schladetsch@gmail.com

using UnityEngine;

namespace Flow
{
	internal class Subroutine<TR> : TypedGenerator<TR>, ISubroutine<TR>
	{
		internal Func<IGenerator, TR> Sub;

		/// <inheritdoc />
		public override void Step()
		{
			if (!Active || !Running)
				return;

			if (Sub == null)
			{
				Complete();
				return;
			}

			Value = Sub(this);

			base.Step();
		}
	}
}