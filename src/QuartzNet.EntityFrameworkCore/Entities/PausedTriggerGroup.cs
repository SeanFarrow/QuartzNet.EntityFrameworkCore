namespace QuartzNet.EntityFrameworkCore.Entities;

public class PausedTriggerGroup
{
    public string SchedulerName { get; }
    public string TriggerGroup { get; }

    public PausedTriggerGroup(string schedulerName, string triggerGroup)
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

        if (triggerGroup is null)
        {
            throw new ArgumentNullException(nameof(triggerGroup));
        }

        if (triggerGroup.Length is 0)
        {
            throw new ArgumentException("The triggerGroup parameter cannot be an empty string.", nameof(triggerGroup));
        }
        TriggerGroup = triggerGroup;
    }
}