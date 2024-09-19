using System;
using System.Collections.Generic;
using System.Linq;

namespace Threenine;

public readonly struct OperationResult<TResult>(TResult result, List<string> errors = null)
    : IEquatable<OperationResult<TResult>>, IComparable<OperationResult<TResult>>
{
    public TResult Result { get; } = result;
    public bool Success => Errors.Count == 0;
    public List<string> Errors { get; } = errors ?? [];

    public bool Equals(OperationResult<TResult> other)
    {
        if (!EqualityComparer<TResult>.Default.Equals(Result, other.Result))
            return false;

        if (Errors.Count != other.Errors.Count)
            return false;

        return !Errors.Where((t, i) => !t.Equals(other.Errors[i])).Any();
    }

    public override bool Equals(object obj)
    {
        return obj is OperationResult<TResult> other && Equals(other);
    }

    public override int GetHashCode()
    {
        unchecked 
        {
            var hash = 17;
            hash = hash * 31 + EqualityComparer<TResult>.Default.GetHashCode(Result);
            return Errors.Aggregate(hash, (current, error) => current * 31 + error.GetHashCode());
        }
    }

    public static bool operator ==(OperationResult<TResult> left, OperationResult<TResult> right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(OperationResult<TResult> left, OperationResult<TResult> right)
    {
        return !(left == right);
    }
    public int CompareTo(OperationResult<TResult> other)
    {
        // Compare Success property first
        var successComparison = Success.CompareTo(other.Success);
        if (successComparison != 0)
            return successComparison;

        // Compare Results if they implement IComparable
        if (Result is not IComparable<TResult> comparableResult) return Errors.Count.CompareTo(other.Errors.Count);
        var resultComparison = comparableResult.CompareTo(other.Result);
        return resultComparison != 0 ? resultComparison :
            // Compare the number of errors only if both have the same success state and Result
            Errors.Count.CompareTo(other.Errors.Count);
    }

    public TResult Match<T>(Func<TResult, TResult> onSuccess, Func<List<string>, TResult> onFailure)
    {
        return Success ? onSuccess(Result) : onFailure(Errors);
    }
}