//

using System;

namespace Flow
{
	internal class Timer : Periodic, ITimer
	{
		internal Timer(IKernel kernel, TimeSpan span)
			: base(kernel, span)
		{
			TimeEnds = kernel.Time.Now + span;
			Elapsed += self => Complete();
		}

		/// <inheritdoc />
		public DateTime TimeEnds { get; private set; }
	}
}