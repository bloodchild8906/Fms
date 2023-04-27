using System;
using System.Collections.Generic;

namespace Fms.Domain.DbEntity.Entities;

public class User
{
    public User()
    {
        ApprovedByTickets = new HashSet<Ticket>();
        CreatedByTickets = new HashSet<Ticket>();
        RequestedByTickets = new HashSet<Ticket>();
    }

    public Guid Id { get; set; }

    public string Username { get; set; }

    public string Password { get; set; }

    public Guid PersonalDetails { get; set; }

    public Guid EmploymentDetails { get; set; }

    public Guid Role { get; set; }

    public string UserType { get; set; }

    public ICollection<Ticket> ApprovedByTickets { get; set; }

    public ICollection<Ticket> CreatedByTickets { get; set; }

    public EmploymentDetails EmploymentDetails1 { get; set; }

    public GeneralDetails GeneralDetails { get; set; }
        
    public ICollection<Ticket> RequestedByTickets { get; set; }

    public Role Role1 { get; set; }
}