using System;
using System.Collections.Generic;
using System.Text;

namespace MediFlow.Domain.Entities;

public class Patient
{
    public int Id { get; set; }
    public string FullName { get; set; } = "";
    public DateOnly DateOfBirth { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? UserId { get; set; }   // login account, if the patient has one
}
