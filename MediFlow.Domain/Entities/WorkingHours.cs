using System;
using System.Collections.Generic;
using System.Text;

namespace MediFlow.Domain.Entities;
public class WorkingHours
{
    public int Id { get; set; }
    public int PhysicianId { get; set; }
    public DayOfWeek Day { get; set; }
    public TimeOnly Start { get; set; }
    public TimeOnly End { get; set; }
}