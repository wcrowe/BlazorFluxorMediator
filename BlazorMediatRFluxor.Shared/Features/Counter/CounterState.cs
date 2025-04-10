using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fluxor;

namespace BlazorMediatRFluxor.Shared.Features.Counter;

[FeatureState] // Marks this class for automatic discovery by Fluxor
public record CounterState {
public int CurrentCount { get; init; } // Use init for immutability

// Parameterless constructor needed for deserialization during state persistence
private CounterState() { }

// Optional: Constructor for initial state if needed directly
public CounterState(int currentCount)
{
    CurrentCount = currentCount;
}
}
