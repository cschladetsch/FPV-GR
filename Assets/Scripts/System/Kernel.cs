using Flow;

/// <summary>
/// Wrapper for placing a Flow.IKernel into a GameObject.
/// </summary>
public class Kernel : BaseObject
{
	public IKernel Kern;

	protected override void Construct()
	{
		base.Construct();

		Kern = Create.NewKernel();

		Kern.Root.Name = "Root";
	}

	protected override void Tick()
	{
		base.Tick();

		Kern.Step();
	}
}
