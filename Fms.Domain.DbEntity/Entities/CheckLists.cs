// using System;
// using System.Collections.Generic;
//
// namespace Fms.Domain.DbEntity.Entities;
//
// public class CheckLists
// {
//     public CheckLists()
//     {
//     }
//
//     public Guid Id { get; set; }
//
//     public string? Name { get; set; }
//
//     public string? Notes { get; set; }
//
//     public ICollection<Documents> RelatedDocuments { get; set; } = new List<Documents>();
//
//     public bool? IsComplete { get; set; }
//
//     public DateTime? CompletedOn { get; set; }
//
//     public ICollection<Activity> ActivityList { get; set; } = new List<Activity>();
// }