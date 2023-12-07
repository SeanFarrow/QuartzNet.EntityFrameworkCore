namespace QuartzNet.EntityFrameworkCore.Entities;
/// <summary>
/// A class representing a calendar.
/// </summary>
public class Calendar
{
    /// <summary>
    /// The name of the scheduler for which this trigger was created.
    /// </summary>
    public string SchedulerName { get; }

    /// <summary>
    /// The name of this calendar.
    /// </summary>
    public string CalendarName { get; }

    /// <summary>
    /// The serialized representation of this <see cref="SerializedCalendar"/>.
    /// </summary>
    public string SerializedCalendar { get; }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="schedulerName">The scheduler to which this <see cref="SerializedCalendar"/> belongs.</param>
    /// <param name="calendarName">The name of this <see cref="SerializedCalendar"/></param>
    /// <param name="serializedCalendar">The serialized representation of this <see cref="SerializedCalendar"/>.</param>
    public Calendar(string schedulerName, string calendarName, string serializedCalendar)
    {
        if (schedulerName is null)
        {
            throw new ArgumentNullException(nameof(schedulerName));
        }
        
        if (schedulerName.Length is 0)
        {
            throw new ArgumentException("The schedulerName parameter cannot be an empty string.", nameof(schedulerName));
        }
        
        if (calendarName is null)
        {
            throw new ArgumentNullException(nameof(calendarName));
        }

        if (calendarName.Length is 0)
        {
            throw new ArgumentException("The calendarName parameter cannot be an empty string.", nameof(calendarName));
        }
        
        if (serializedCalendar is null)
        {
            throw new ArgumentNullException(nameof(serializedCalendar));
        }

        if (serializedCalendar.Length is 0)
        {
            throw new ArgumentException("The serializedCalendar parameter cannot be an empty string.", nameof(serializedCalendar));
        }
        
        SchedulerName =schedulerName;
        CalendarName =calendarName;
        SerializedCalendar =serializedCalendar;
    }
}