using api.common.Interface;
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
    public class SubjectDataAccess : ISubjectDataAccess
    {
        private readonly FaceAttendanceDbContext _dbContext;
        private readonly IMapper _mapper;
        public SubjectDataAccess(FaceAttendanceDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<Subject> AddSubjectAsync(Subject subject)
        {
            var data = await _dbContext.TblSubjects.AddAsync(_mapper.Map<TblSubject>(subject));
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<Subject>(subject);
        }

        public void DeleteSubjectAsync(Subject subject)
        {
            _dbContext.Remove(_mapper.Map<TblSubject>(subject));
            _dbContext.SaveChangesAsync(true);
        }

        public async Task<Subject> GetSubjectByIdAsync(int id)
        {
            var subject = await _dbContext.TblSubjects
                        .Where(s => s.SubjectId == id)
                        .AsNoTracking()
                        .FirstOrDefaultAsync();

            return _mapper.Map<Subject>(subject);
        }

        public async Task<IEnumerable<Subject>> GetSubjectListAsync()
        {
            var subjects = await _dbContext.TblSubjects
                        .AsNoTracking()
                        .ToListAsync();

            return _mapper.Map<IEnumerable<Subject>>(subjects);
        }

        public async Task<Subject> UpdateSubjectAsync(Subject subject)
        {
            var updateSubject = _dbContext.Update(_mapper.Map<Subject>(subject));
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<Subject>(updateSubject.Entity);
        }
    }
}
