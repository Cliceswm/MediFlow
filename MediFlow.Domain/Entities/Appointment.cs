using System;
using System.Collections.Generic;
using System.Text;

namespace MediFlow.Domain.Entities;
public class Appointment
{
    public int Id { get; set; }
    public int PatientId { get; set; }
    public Patient Patient { get; set; } = null!;
    public int PhysicianId { get; set; }
    public Physician Physician { get; set; } = null!;
    public DateTime StartUtc { get; set; }   // always store times in UTC
    public DateTime EndUtc { get; set; }
    public AppointmentStatus Status { get; set; } = AppointmentStatus.Scheduled;
    public string? CancellationReason { get; set; }
    public DateTime CreatedUtc { get; set; } = DateTime.UtcNow;
}

