using System;
using System.Collections.Generic;

namespace Fsm.Domain.Entities;

public class GeneralDetails
{
    public GeneralDetails()
    {
        ReferencedUser = new User();
    }

    public Guid Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public DateTime DateOfBirth { get; set; }

    public string EmailAddress { get; set; }

    public string PhoneNumber { get; set; }

    public string Address { get; set; }

    public string EmergencyContactName { get; set; }

    public string EmergencyContactNumber { get; set; }

    public string EmergencyContactRelation { get; set; }

    public User ReferencedUser { get; set; }
}