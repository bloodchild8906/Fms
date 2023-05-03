// using System;
// using System.Collections.Generic;
//
// namespace Fms.Domain.DbEntity.Entities;
//
// public class Activity
// {
//     public Activity()
//     {
//     }
//
//     public Guid Id { get; set; }
//
//     public string? Name { get; set; }
//
//     public string? Description { get; set; }
//
//     public ICollection<Skills> Skillsrequired { get; set; } = new List<Skills>();
//
//     public DateTime StartedOn { get; set; }
//
//     public string? Notes { get; set; }
//
//     public ICollection<Documents> RelatedDocuments { get; set; } = new List<Documents>();
//
//     public bool? IsComplete { get; set; }
//
//     public DateTime? CompletedOn { get; set; }
//
//     public ICollection<ActivityLog> TaskLog { get; set; } = new List<ActivityLog>();
// }