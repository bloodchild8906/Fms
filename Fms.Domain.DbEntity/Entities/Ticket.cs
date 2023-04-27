using System;
using System.Collections.Generic;

namespace Fms.Domain.DbEntity.Entities;

public class Ticket
{
    public Ticket()
    {
        ActiveEmploymentDetails = new HashSet<EmploymentDetails>();
        CheckListsCollection = new HashSet<CheckLists>();
        SkillsCollection = new HashSet<Skills>();
    }

    public Guid Id { get; set; }

    public string Referencenumber { get; set; }

    public ICollection<Skills> Skillsrequired { get; set; } = new List<Skills>();
    public ICollection<CheckLists> CheckLists { get; set; } = new List<CheckLists>();

    public string Client { get; set; }

    public DateTime? Approvedon { get; set; }

    public Guid? CanBeApprovedByRoles { get; set; }

    public Guid? ApprovedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? Requestedon { get; set; }

    public Guid? RequestedBy { get; set; }

    public string Notes { get; set; }

    public string Status { get; set; }

    public ICollection<CheckLists> CheckListsCollection { get; set; }
    public ICollection<Skills> SkillsCollection { get; set; }
        
    public ICollection<EmploymentDetails> ActiveEmploymentDetails { get; set; }

    public User ApprovedByUser { get; set; }

    public Role CanBeApprovedBysRole { get; set; }

    public User CreatedByUser { get; set; }

    public User RequestedByUser { get; set; }
}