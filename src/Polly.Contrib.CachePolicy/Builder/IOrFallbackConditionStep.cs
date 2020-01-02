﻿using System;

using Polly.Contrib.CachePolicy.Models;

namespace Polly.Contrib.CachePolicy.Builder
{
    /// <summary>
    /// Or fallback to cache condition step within builder step pattern to build <see cref="AsyncCachePolicy{TResult}"/>
    /// </summary>
    /// <typeparam name="TResult">The type of return values this policy will handle.</typeparam>
    public interface IOrFallbackConditionStep<TResult> : IAsyncCachePolicyBuilder<TResult>
        where TResult : CacheValue
    {
        /// <summary>
        /// Specifies the type of exception that this policy can handle.
        /// </summary>
        /// <typeparam name="TException">The type of the exception to handle.</typeparam>
        /// <returns>The <see cref="AsyncCachePolicyBuilder{TResult}"/> instance for fluent chaining</returns>
        IOrFallbackConditionStep<TResult> OrFallbackToCacheWhenThrows<TException>()
            where TException : Exception;

        /// <summary>
        /// Specifies the type of return result that this policy can handle, and a result value which the policy will handle.
        /// </summary>
        /// <param name="result">The type of return values this policy will handle.</param>
        /// <returns>The <see cref="AsyncCachePolicyBuilder{TResult}"/> instance for fluent chaining</returns>
        IOrFallbackConditionStep<TResult> OrFallbackToCacheWhenReturns(TResult result);

        /// <summary>
        /// Specifies the type of exception that this policy can handle with additional filters on this exception type.
        /// </summary>
        /// <typeparam name="TException">The type of the exception to handle.</typeparam>
        /// <param name="exceptionPredicate">The exception predicate to filter the type of exception this policy can handle.</param>
        /// <returns>The <see cref="AsyncCachePolicyBuilder{TResult}"/> instance for fluent chaining</returns>
        IOrFallbackConditionStep<TResult> OrFallbackToCacheWhenThrows<TException>(Func<TException, bool> exceptionPredicate)
            where TException : Exception;

        /// <summary>
        /// Specifies the type of return result that this policy can handle with additional filters on the result.
        /// </summary>
        /// <param name="resultPredicate">The predicate to filter results this policy will handle.</param>
        /// <returns>The <see cref="AsyncCachePolicyBuilder{TResult}"/> instance for fluent chaining</returns>
        IOrFallbackConditionStep<TResult> OrFallbackToCacheWhenReturns(Func<TResult, bool> resultPredicate);
    }
}
