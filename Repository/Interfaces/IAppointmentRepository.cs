﻿using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IAppointmentRepository
    {
        public Task<IEnumerable<Appointment>> ListAppointments();

        public Task<Appointment> Details(Guid? id);

        public Task<Appointment> Create(Appointment appointment);

        public Task Edit(Appointment appointment);
        public Task Delete(Appointment appointment);
        public bool Exists(Guid? id);
    }
}
