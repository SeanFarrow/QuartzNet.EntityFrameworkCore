namespace QuartzNet.EntityFrameworkCore.Entities;
/// <summary>
/// A class representing a simple trigger.
/// </summary>
public class SimpleTrigger
{
    /// <summary>
    /// The name of the scheduler for which this trigger was created.
    /// </summary>
    public string SchedulerName { get; }
    
    /// <summary>
    /// The name of this trigger.
    /// </summary>
    public string TriggerName { get; }

    /// <summary>
    /// The group to which this <see cref="CronTrigger"/> belongs.
    /// </summary>
    public string TriggerGroup { get; }
    
    /// <summary>
    /// Get or set the number of times this <see cref="SimpleTrigger" /> should
    /// repeat, after which it will be automatically deleted.
    /// </summary>
    public uint RepeatCount { get; }
    
    /// <summary>
    /// Get or set the time interval at which this <see cref="SimpleTrigger" /> should repeat.
    /// </summary>
    public TimeSpan RepeatInterval { get; }
    
    /// <summary>
    /// Get or set the number of times this <see cref="SimpleTrigger" /> has already
    /// fired.
    /// </summary>
    public uint TimesTriggered { get; }

    /// <summary>
    /// Instantiate a <see cref="SimpleTrigger"/> instance.
    /// </summary>
    /// <param name="schedulerName"></param>The name of the scheduler to which this <see cref="SimpleTrigger"/> is associated.
    /// <param name="triggerName">The name of the <see cref="SimpleTrigger"/>.</param>
    /// <param name="triggerGroup">The group to which this <see cref="SimpleTrigger"/> is associated.</param>
    /// <param name="repeatCount">the number of times this <see cref="SimpleTrigger" /> should repeat, after which it will be automatically deleted.</param>
    /// <param name="repeatInterval">The time interval at which this <see cref="SimpleTrigger" /> should repeat.</param>
    /// <param name="timesTriggered">The number of times this &lt;see cref="SimpleTrigger" /&gt; has already fired.</param>
    public SimpleTrigger(string schedulerName, string triggerName, string triggerGroup, uint repeatCount, TimeSpan repeatInterval, uint timesTriggered)
    {
        if (schedulerName is null)
        {
            throw new ArgumentNullException(nameof(schedulerName));
        }

        if (schedulerName.Length is 0)
        {
            throw new ArgumentException("The schedulerName parameter cannot be an empty string.", nameof(schedulerName));
        }

        if (triggerName is null)
        {
            throw new ArgumentNullException(nameof(triggerName));
        }

        if (triggerName.Length is 0)
        {
            throw new ArgumentException("The triggerName parameter cannot be an empty string.", nameof(triggerName));
        }

        if (triggerGroup is null)
        {
            throw new ArgumentNullException(nameof(triggerGroup));
        }

        if (triggerGroup.Length is 0)
        {
            throw new ArgumentException("The triggerGroup parameter cannot be an empty string.", nameof(triggerGroup));
        }

        if (repeatInterval == TimeSpan.Zero)
        {
            throw new ArgumentOutOfRangeException(nameof(repeatInterval), TimeSpan.Zero, "The repeatInterval cannot be zero.");
        }
        
        SchedulerName = schedulerName;
        TriggerName = triggerName;
        TriggerGroup = triggerGroup;
        RepeatCount = repeatCount;
        RepeatInterval = repeatInterval;
        TimesTriggered = timesTriggered;
    }
}