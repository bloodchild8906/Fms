using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Fms.Domain.DbEntity.Entities.Common;

namespace Fms.Domain.DbEntity.Entities;

public sealed class User:Entity
{
    // public User()
    // {
    //     ApprovedByTickets = new HashSet<Ticket>();
    //     CreatedByTickets = new HashSet<Ticket>();
    //     RequestedByTickets = new HashSet<Ticket>();
    // }

    public string Username { get; set; }

    public string Password { get; set; }
    
    public Role RoleDetail { get; set; }
    public Guid RoleNavigator { get; set; }
    //
    // public Guid? PersonalDetails { get; set; }
    //
    // public Guid? EmploymentDetail { get; set; }
    //
    //
    // public string? UserType { get; set; }
    //
    // public ICollection<Ticket>? ApprovedByTickets { get; set; }
    //
    // public ICollection<Ticket>? CreatedByTickets { get; set; }
    //
    // public EmploymentDetails? EmploymentDetails1 { get; set; }
    //
    // public GeneralDetails? GeneralDetails { get; set; }
    //     
    // public ICollection<Ticket>? RequestedByTickets { get; set; }


}