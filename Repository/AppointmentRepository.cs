﻿using Dal;
using DomainModel;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly ApplicationDbContext _context;

        public AppointmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Appointment>> ListAppointments()
        {
            return await _context.Appointments.Include(a => a.Nurse).Include(a => a.Patient).Include(a => a.Status).ToListAsync();
            //return await _context.Appointments.ToListAsync();
        }

        public async Task<Appointment> Details(Guid? id)
        {
            var appointment = await _context.Appointments
                                    .Include(a => a.Nurse)
                                    .Include(a => a.Patient)
                                    .Include(a => a.Status)
                                    .FirstOrDefaultAsync(m => m.Id == id);
            return appointment;
        }

        public async Task<Appointment> Create(Appointment appointment)
        {

            _context.Appointments.Add(appointment);
            await _context.SaveChangesAsync();

            return appointment;
        }

        public async Task Edit(Appointment appointment)
        {

            _context.Update(appointment);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Appointment appointment)
        {
            _context.Remove(appointment);
            await _context.SaveChangesAsync();
        }

        public bool Exists(Guid? id)
        {
            return _context.Appointments.Any(a => a.Id  == id);
        }
    }
}
