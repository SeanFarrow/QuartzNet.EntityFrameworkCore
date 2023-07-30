namespace QuartzNet.EntityFrameworkCore.Entities;
/// <summary>
/// A class representing a trigger that uses a cron expression.
/// </summary>
public class CronTrigger
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
    /// The cron expression that determines when this <see cref="CronTrigger"/> will fire.
    /// </summary>
    public string CronExpression { get; }

    /// <summary>
    /// The id of the timezone in which this <see cref="CronTrigger"/> should be fired.
    /// </summary>
    public string? TimezoneID { get; }

    /// <summary>
    /// Instantiates a <see cref="CronTrigger"/>.
    /// </summary>
    /// <param name="schedulerName">The name of the schedule to which this <see cref="CronTrigger"/> is associated.</param>
    /// <param name="triggerName">The name of this <see cref="CronTrigger"/></param>
    /// <param name="triggerGroup">the group to which this <see cref="CronTrigger"/> belongs.</param>
    /// <param name="cronExpression">The expression that determines when this <see cref="CronTrigger"/> will be fired.</param>
    /// <param name="timezoneId"> the id of the timezone in which the <paramref name="cronExpression"/> will be interpreted.</param>
    /// <exception cref="ArgumentNullException">Thrown when the <paramref ="schedulerName"/>, <paramref ="triggerName"/>, <paramref ="triggerGroup"/> or <paramref ="cronExpression"/> are <c>null</c>.</exception>
    /// <exception cref="ArgumentException">Thrown when the <paramref ="schedulerName"/>, <paramref ="triggerName"/>, <paramref ="triggerGroup"/> or <paramref ="cronExpression"/> are empty strings.</exception>
    public CronTrigger(string schedulerName, string triggerName, string triggerGroup, string cronExpression, string timezoneId)
    {
        if (schedulerName is null)
        {
            throw new ArgumentNullException(nameof(schedulerName));
        }

        if (schedulerName.Length is 0)
        {
            throw new ArgumentException("The schedulerName parameter cannot be an empty string.", nameof(schedulerName));
        }
        SchedulerName =schedulerName;
        
        if (triggerName is null)
        {
            throw new ArgumentNullException(nameof(triggerName));
        }

        if (triggerName.Length is 0)
        {
            throw new ArgumentException("The triggerName parameter cannot be an empty string.", nameof(triggerName));
        }
        TriggerName = triggerName;
        
        if (triggerGroup is null)
        {
            throw new ArgumentNullException(nameof(triggerGroup));
        }

        if (triggerGroup.Length is 0)
        {
            throw new ArgumentException("The triggerGroup parameter cannot be an empty string.", nameof(triggerGroup));
        }
        TriggerGroup = triggerGroup;

        if (cronExpression is null)
        {
            throw new ArgumentNullException(nameof(cronExpression));
        }

        if (cronExpression.Length is 0)
        {
            throw new ArgumentException("The cronExpression parameter cannot be an empty string.", nameof(cronExpression));
        }

        CronExpression = cronExpression;

        TimezoneID = timezoneId;
    }
}