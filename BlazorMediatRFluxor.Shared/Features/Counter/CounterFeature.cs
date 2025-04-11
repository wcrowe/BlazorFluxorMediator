using Fluxor;

namespace BlazorMediatRFluxor.Shared.Features.Counter;

public class CounterFeature : Feature<CounterState>
{
    public CounterFeature()
    {
    }

    public override string GetName() => "Counter";

    protected override CounterState GetInitialState()
    {
        return new CounterState( currentCount: 0);
    }
}
