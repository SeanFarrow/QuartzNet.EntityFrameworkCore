﻿namespace QuartzNet.EntityFrameworkCore.Entities.Enumerations;
/// <summary>
/// A representation of all the available trigger states.
/// </summary>
public enum TriggerState
{
    /// <summary>
    /// Indicates that the <see cref="ITrigger" /> is in the "normal" state.
    /// </summary>
    Normal,

    /// <summary>
    /// Indicates that the <see cref="ITrigger" /> is in the "paused" state.
    /// </summary>
    Paused,

    /// <summary>
    /// Indicates that the <see cref="ITrigger" /> is in the "complete" state.
    /// </summary>
    /// <remarks>
    /// "Complete" indicates that the trigger has not remaining fire-times in
    /// its schedule.
    /// </remarks>
    Complete,

    /// <summary>
    /// Indicates that the <see cref="ITrigger" /> is in the "error" state.
    /// </summary>
    /// <remarks>
    /// <para>
    /// A <see cref="ITrigger" /> arrives at the error state when the scheduler
    /// attempts to fire it, but cannot due to an error creating and executing
    /// its related job. Often this is due to the <see cref="IJob" />'s
    /// class not existing in the classpath.
    /// </para>
    /// 
    /// <para>
    /// When the trigger is in the error state, the scheduler will make no
    /// attempts to fire it.
    /// </para>
    /// </remarks>
    Error,

    /// <summary>
    /// Indicates that the <see cref="ITrigger" /> is in the "blocked" state.
    /// </summary>
    /// <remarks>
    /// A <see cref="ITrigger" /> arrives at the blocked state when the job that
    /// it is associated with has a <see cref="DisallowConcurrentExecutionAttribute" /> and it is 
    /// currently executing.
    /// </remarks>
    /// <seealso cref="DisallowConcurrentExecutionAttribute" />
    Blocked,

    /// <summary>
    /// Indicates that the <see cref="ITrigger" /> does not exist.
    /// </summary>
    None
}