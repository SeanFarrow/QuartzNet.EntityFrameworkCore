namespace QuartzNet.EntityFrameworkCore.Entities;

public class JobDetail
{
    public JobDetail(string schedulerName, string jobName, string jobGroup, string? description, string jobClassName, bool isDurable, bool isNonConcurrent, bool isUpdateData, bool requestsRecovery, string? jobData)
    {
        if (schedulerName is null)
        {
            throw new ArgumentNullException(nameof(schedulerName));
        }

        if (schedulerName.Length is 0)
        {
            throw new ArgumentException(nameof(schedulerName));
        }
        SchedulerName = schedulerName;

        if (jobName is null)
        {
            throw new ArgumentNullException(nameof(jobName));
        }

        if (jobName.Length is 0)
        {
            throw new ArgumentException(nameof(jobName));
        }
        JobName = jobName;

        if (jobGroup is null)
        {
            throw new ArgumentNullException(nameof(jobGroup));
        }

        if (jobGroup.Length is 0)
        {
            throw new ArgumentException(nameof(jobGroup));
        }
        JobGroup = jobGroup;
        
        if (jobClassName is null)
        {
            throw new ArgumentNullException(nameof(jobClassName));
        }

        if (jobClassName.Length is 0)
        {
            throw new ArgumentException(nameof(jobClassName));
        }
        JobClassName= jobClassName;

        IsDurable = isDurable;
        IsNonConcurrent = isNonConcurrent;
        IsUpdateData = isUpdateData;
        RequestsRecovery = requestsRecovery;
        Description = description;
        JobData = jobData;
    }
    
    public string SchedulerName { get; }
    public string JobName { get; }
    public string JobGroup { get; }
    public string? Description { get; }
    public string JobClassName { get; }
    public bool IsDurable { get; }
    public bool IsNonConcurrent { get; }
    public bool IsUpdateData { get; }
    public bool RequestsRecovery { get; }
    public string? JobData { get; }
}