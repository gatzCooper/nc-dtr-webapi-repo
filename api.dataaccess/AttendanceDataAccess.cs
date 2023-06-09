﻿using api.common.Interface;
using api.common.model;
using api.dataaccess.entityframework.data;
using api.dataaccess.entityframework.model;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.dataaccess
{
    public class AttendanceDataAccess : IAttendanceDataAccess
    {
        private readonly FaceAttendanceDbContext _dbContext;
        private readonly IMapper _mapper;

        public AttendanceDataAccess(FaceAttendanceDbContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Attendance>> GetAllAttendanceAsync()
        {
            var attendance = await _dbContext.TblAttendances
                .AsNoTracking()
                .ToListAsync();

            return _mapper.Map<IEnumerable<Attendance>>(attendance);
        }

        public async Task<IEnumerable<Attendance>> GetAttendanceByUserIdAsync(int userId)
        {
            var attendance = await _dbContext.TblAttendances
                 .Where(x => x.UserId == userId).
                 ToListAsync();

            return _mapper.Map<IEnumerable<Attendance>>(attendance);
        }

        public async Task<Attendance> CreateAttendanceAsync(Attendance attendance)
        {
            var data = _dbContext.TblAttendances.AddAsync(_mapper.Map<TblAttendance>(attendance));
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<Attendance>(data); 
        }
    }
}
