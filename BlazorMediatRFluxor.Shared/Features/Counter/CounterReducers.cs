using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fluxor;

namespace BlazorMediatRFluxor.Shared.Features.Counter;

public static class CounterReducers
{
    [ReducerMethod] // Marks this method for automatic discovery
    public static CounterState ReduceIncrementCounterAction(CounterState state, IncrementCounterAction action)
    {
        // Return a *new* state instance with the updated value
        return state with { CurrentCount = state.CurrentCount + 1 };
    }

}