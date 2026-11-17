using System;
using System.Collections.Generic;
using System.Text;

namespace MediFlow.Domain.Entities;
public class Physician
{
    public int Id { get; set; }
    public string FullName { get; set; } = "";
    public string Specialty { get; set; } = "";
    public string? Email { get; set; }
    public string? UserId { get; set; }
}