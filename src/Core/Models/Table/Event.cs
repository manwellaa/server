﻿using System;
using System.ComponentModel.DataAnnotations;
using Bit.Core.Enums;
using Bit.Core.Models.Data;
using Bit.Core.Utilities;

namespace Bit.Core.Models.Table
{
    public class Event : ITableObject<Guid>, IEvent
    {
        public Event() { }

        public Event(IEvent e)
        {
            Date = e.Date;
            Type = e.Type;
            UserId = e.UserId;
            OrganizationId = e.OrganizationId;
            ProviderId = e.ProviderId;
            CipherId = e.CipherId;
            CollectionId = e.CollectionId;
            PolicyId = e.PolicyId;
            GroupId = e.GroupId;
            OrganizationUserId = e.OrganizationUserId;
            ProviderUserId = e.ProviderUserId;
            ProviderOrganizationId = e.ProviderOrganizationId;
            DeviceType = e.DeviceType;
            IpAddress = e.IpAddress;
            ActingUserId = e.ActingUserId;
        }

        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public EventType Type { get; set; }
        public Guid? UserId { get; set; }
        public Guid? OrganizationId { get; set; }
        public Guid? ProviderId { get; set; }
        public Guid? CipherId { get; set; }
        public Guid? CollectionId { get; set; }
        public Guid? PolicyId { get; set; }
        public Guid? GroupId { get; set; }
        public Guid? OrganizationUserId { get; set; }
        public Guid? ProviderUserId { get; set; }
        public Guid? ProviderOrganizationId { get; set; }
        public DeviceType? DeviceType { get; set; }
        [MaxLength(50)]
        public string IpAddress { get; set; }
        public Guid? ActingUserId { get; set; }

        public void SetNewId()
        {
            Id = CoreHelpers.GenerateComb();
        }
    }
}
