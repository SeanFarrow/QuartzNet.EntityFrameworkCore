namespace QuartzNet.EntityFrameworkCore.Entities;

public class SchedulerState
{
    public SchedulerState(string schedulerName, string instanceName, DateTimeOffset lastCheckinTime, TimeSpan checkinInterval)
    {
        if (schedulerName is null)
        {
            throw new ArgumentNullException(nameof(schedulerName));
        }

        if (schedulerName.Length is 0)
        {
            throw new ArgumentException("The schedulerName parameter cannot be an empty string.", nameof(schedulerName));
        }
        SchedulerName = schedulerName;

        if (instanceName is null)
        {
            throw new ArgumentNullException(nameof(instanceName));
        }

        if (instanceName.Length is 0)
        {
            throw new ArgumentException("The instanceName parameter cannot be an empty string.", nameof(instanceName));
        }
        InstanceName = instanceName;

        if (lastCheckinTime > DateTimeOffset.UtcNow)
        {
            throw new ArgumentException("The lastCheckinTime parameter must not be in the future.", nameof(lastCheckinTime));
        }
        LastCheckinTime = lastCheckinTime;
        
        if (checkinInterval == TimeSpan.Zero)
        {
            throw new ArgumentException("The checkinInterval parameter must not be 0.", nameof(lastCheckinTime));
        }
        CheckinInterval =checkinInterval;
    }

    public string SchedulerName { get; }

    public string InstanceName { get; }

    public DateTimeOffset LastCheckinTime { get;}
    
    public TimeSpan CheckinInterval { get; }
}