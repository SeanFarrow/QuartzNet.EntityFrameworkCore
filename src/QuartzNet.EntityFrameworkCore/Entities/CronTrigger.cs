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
    public string TimezoneID { get; }
}