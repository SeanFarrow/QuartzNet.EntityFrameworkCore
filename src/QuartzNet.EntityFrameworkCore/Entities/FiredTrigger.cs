using QuartzNet.EntityFrameworkCore.Entities.Enumerations;

namespace QuartzNet.EntityFrameworkCore.Entities;

public class FiredTrigger
{
    public string SchedulerName { get; }
    public string EntryID { get; }
    public string TriggerName { get; }
    public string TriggerGroup { get; }
    public string InstanceName { get; }
    public DateTimeOffset FiredTime { get; }
    public DateTimeOffset ScheduledTime { get; }
    public uint Priority { get; }
    public TriggerState State { get; }
    public string? JobName { get; }
    public string? JobGroup { get; }
    public bool? IsNonConcurrent { get; }
    public bool? RequestsRecovery { get; }

    public FiredTrigger(string schedulerName, string entryId, string triggerName, string triggerGroup, string instanceName, DateTimeOffset firedTime, DateTimeOffset scheduledTime, uint priority, TriggerState state, string? jobName, string? jobGroup, bool? isNonConcurrent, bool? requestsRecovery)
    {
        if (schedulerName is null)
        {
            throw new ArgumentNullException(nameof(schedulerName));
        }

        if (schedulerName.Length is 0)
        {
            throw new ArgumentException(nameof(schedulerName));
        }

        if (entryId is null)
        {
            throw new ArgumentNullException(nameof(entryId));
        }

        if (entryId.Length is 0)
        {
            throw new ArgumentException(nameof(entryId));
        }

        if (triggerName is null)
        {
            throw new ArgumentNullException(nameof(triggerName));
        }

        if (triggerName.Length is 0)
        {
            throw new ArgumentException(nameof(triggerName));
        }

        if (triggerGroup is null)
        {
            throw new ArgumentNullException(nameof(triggerGroup));
        }

        if (triggerGroup.Length is 0)
        {
            throw new ArgumentException(nameof(triggerGroup));
        }
        
        if (instanceName is null)
        {
            throw new ArgumentNullException(nameof(instanceName));
        }

        if (instanceName.Length is 0)
        {
            throw new ArgumentException(nameof(instanceName));
        }

        if (firedTime < scheduledTime)
        {
            throw new ArgumentOutOfRangeException(nameof(firedTime), firedTime,"The fired time should not be less than the scheduled time.");
        }
        
        SchedulerName = schedulerName;
        EntryID = entryId;
        TriggerName = triggerName;
        TriggerGroup = triggerGroup;
        InstanceName = instanceName;
        FiredTime = firedTime;
        ScheduledTime = scheduledTime;
        Priority = priority;
        State = state;
        JobName = jobName;
        JobGroup = jobGroup;
        IsNonConcurrent = isNonConcurrent;
        RequestsRecovery = requestsRecovery;
    }
}